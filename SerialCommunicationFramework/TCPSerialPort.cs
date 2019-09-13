using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SerialCommunicationFramework
{
    /// <summary>
    /// Emulate a serial port interface over a TCP Socket connection.  
    /// Will attempt an auto reconnect if an error is encountered on send (socket disconnected, etc) 
    /// before sending disconnect event.
    /// Defaults to connecting on Port 23 (Telnet), but does not implement Telenet protocol negotiation commands.
    /// </summary>
    public class TCPSerialPort : ISerialPort
    {
        /// <summary>
        /// Timeout for socket operations, in milliseconds
        /// </summary>
        public int SocketTimeoutMS = 2500;

        #region TCP Socket Communication

        private const int DefaultPort = 23; // Default to Telent port

        private class RecvState
        {
            public const int BufferSize = 256;
            public byte[] RecvBuffer = new byte[BufferSize];
            public Socket IPSocket = null;
        }

        // Internal events to signal completion
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        private static String LastSocketOperation = String.Empty;
        private static Exception LastSocketError = null;

        private static ConcurrentQueue<byte> InBuffer = new ConcurrentQueue<byte>();

        /// <summary>
        /// Attempt to connect to a remote TCP port
        /// </summary>
        /// <param name="Hostname">Hostname/IP address to connect to</param>
        /// <param name="Port">TCP port number on specified host to connect to</param>
        /// <returns>Socket instance of connection in progress, or null if unable to find host</returns>
        private static Socket Connect(String Hostname, int Port)
        {
            try
            {
                LastSocketOperation = "Connect to " + Hostname + ":" + Port;

                IPAddress[] AddressList = Dns.GetHostAddresses(Hostname);
                if (AddressList.Length > 0)
                {
                    IPAddress IP = AddressList[0];
                    IPEndPoint RemoteEndpoint = new IPEndPoint(IP, Port);

                    Socket IPSocket = new Socket(IP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    IPSocket.BeginConnect(RemoteEndpoint, new AsyncCallback(ConnectCallback), IPSocket);
                    return IPSocket;
                }
                else
                {
                    LastSocketError = new Exception("Unable to find host \"" + Hostname + "\"");
                    return null;
                }
            }
            catch (Exception ex)
            {
                LastSocketError = ex;
                return null;
            }
        }

        private static void Disconnect(Socket IPSocket)
        {
            if (IPSocket != null)
            {
                IPSocket.Disconnect(false);
            }
        }

        private static void Send(Socket IPSocket, String Data)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(Data);
            IPSocket.BeginSend(dataBytes, 0, dataBytes.Length, SocketFlags.None, new AsyncCallback(SendCallback), IPSocket);
        }

        private static void Receive(Socket IPSocket)
        {
            try
            {
                RecvState State = new RecvState();
                State.IPSocket = IPSocket;

                IPSocket.BeginReceive(State.RecvBuffer, 0, RecvState.BufferSize, SocketFlags.None, new AsyncCallback(RecvCallback), State);
            }
            catch (Exception ex)
            {
                LastSocketOperation = "Receive";
                LastSocketError = ex;
            }
        }

        private static void ConnectCallback(IAsyncResult asyncResult)
        {
            try
            {
                Socket IPSocket = (Socket)asyncResult.AsyncState;
                IPSocket.EndConnect(asyncResult);
            }
            catch (Exception ex)
            {
                LastSocketError = ex;
                return;
            }
            finally
            {
                connectDone.Set();
            }
        }

        private static void SendCallback(IAsyncResult asyncResult)
        {
            try
            {
                Socket IPSocket = (Socket)asyncResult.AsyncState;
                sendDone.Set();
            }
            catch (Exception ex)
            {
                LastSocketOperation = "Send data";
                LastSocketError = ex;
                return;
            }
            finally
            {
                sendDone.Set();
            }
        }

        private static void RecvCallback(IAsyncResult asyncResult)
        {
            try
            {
                RecvState State = (RecvState)asyncResult.AsyncState;
                Socket IPSocket = State.IPSocket;

                int bytesRead = IPSocket.EndReceive(asyncResult);
                for (int i = 0; ((i < bytesRead) && (i < RecvState.BufferSize)); i++)
                    InBuffer.Enqueue(State.RecvBuffer[i]);
            }
            catch (Exception ex)
            {
                LastSocketOperation = "Recevie data";
                LastSocketError = ex;
                return;
            }
            finally
            {
                receiveDone.Set();
            }
        }

        #endregion

        #region ISerialPort Interface

        public event DataInOutHandler DataIn;
        public event DataInOutHandler DataOut;
        public event ConnectionStateChanged ConnectionChanged;

        private String ConnectedHost;
        private int ConnectedPort;

        private Socket SystemSocket = null;
        private Thread RecvThread = null;

        public bool IsConnected
        {
            get { return (SystemSocket != null); }
        }

        public void Disconnect(Boolean CauseEvent)
        {
            RecvThread.Abort();
            RecvThread = null;

            Disconnect(SystemSocket);
            SystemSocket.Dispose();
            SystemSocket = null;

            if (CauseEvent)
                ConnectionChanged?.Invoke(this);
        }

        public void Close()
        {
            Disconnect(true);
        }

        public void Flush()
        {
            if (SystemSocket != null)
            {
                Send(SystemSocket, "\r\n");
                sendDone.WaitOne();
            }
        }

        private void Open(string Hostname, int Port, Boolean CauseEvent)
        {
            SystemSocket = Connect(Hostname, Port);
            if (SystemSocket != null)
            {
                ConnectedHost = Hostname;
                ConnectedPort = Port;

                if (!connectDone.WaitOne(SocketTimeoutMS))
                    SystemSocket = null;

                RecvThread = new Thread(new ThreadStart(ReadLoop));

                if (CauseEvent)
                    ConnectionChanged?.Invoke(this);

                RecvThread.Start();
            }
        }

        public void Open(string Hostname, int Port = DefaultPort)
        {
            Open(Hostname, Port, true);
        }

        public void Open(string Port, int Baud, int DataBits, StopBits Stop, Parity ParityBits)
        {
            Open(Port, (Baud >= 0) ? DefaultPort : Baud, true);
        }

        private void AttemptReconnect()
        {
            if (SystemSocket != null)
            {
                Disconnect(false);
                Open(ConnectedHost, ConnectedPort, false);
            }
        }

        private void ReadLoop()
        {
            Boolean Aborted = false;
            while (!Aborted)
            {
                try
                {
                    System.Threading.Thread.Sleep(50);

                    Receive(SystemSocket);
                    if (receiveDone.WaitOne(SocketTimeoutMS))
                    {
                        byte Data;
                        Queue<byte> NewData = new Queue<byte>();

                        while (InBuffer.TryDequeue(out Data))
                            NewData.Enqueue(Data);

                        if (NewData.Count > 0)
                            DataIn?.Invoke(this, NewData);
                    }
                }
                catch (ThreadAbortException)
                {
                    Aborted = true;
                }
                catch
                {
                    // Continue
                }
            }
        }

        private void SendWithReconnect(Queue<byte> SendData, bool DoReconnect)
        {
            try
            {
                if (SystemSocket != null)
                {
                    Send(SystemSocket, Encoding.ASCII.GetString(SendData.ToArray()));
                    if (sendDone.WaitOne(SocketTimeoutMS))
                        DataOut?.Invoke(this, SendData);
                }
            }
            catch
            {
                if (DoReconnect)
                {
                    AttemptReconnect();
                    SendWithReconnect(SendData, false);
                }
                else
                    ConnectionChanged?.Invoke(this);
            }
        }

        public void Send(Queue<byte> SendData)
        {
            SendWithReconnect(SendData, true);
        }

        public void Send(byte[] SendData)
        {
            SendWithReconnect(new Queue<byte>(SendData), true);
        }

        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Disconnect(SystemSocket);
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SocketSerialPort() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
