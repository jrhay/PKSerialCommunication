using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace SerialCommunicationFramework
{
    /// <summary>
    /// .NET Core implementation of an ISerialPort in Windows
    /// </summary>
    public class WindowsSerialPort : BaseSerialPort
    {
        System.IO.Ports.SerialPort SystemPort = null;

        #region ISerialPort Interface

        /// <summary>
        /// Convert from the ISerialPort parity value to the System.IO.Ports parity value
        /// </summary>
        System.IO.Ports.Parity ConvertParity(Parity parity)
        {
            switch (parity)
            {
                case Parity.Even: return System.IO.Ports.Parity.Even;
                case Parity.Mark: return System.IO.Ports.Parity.Mark;
                case Parity.None: return System.IO.Ports.Parity.None;
                case Parity.Odd: return System.IO.Ports.Parity.Odd;
                case Parity.Space: return System.IO.Ports.Parity.Space;
            }

            return System.IO.Ports.Parity.None;
        }

        /// <summary>
        /// Convert from the ISerialPort stop bits value to the System.IO.Ports stop bits value
        /// </summary>
        System.IO.Ports.StopBits ConvertStopBits(StopBits stopBits)
        {
            switch (stopBits)
            {
                case StopBits.One: return System.IO.Ports.StopBits.One;
                case StopBits.OnePointFive: return System.IO.Ports.StopBits.OnePointFive;
                case StopBits.Two: return System.IO.Ports.StopBits.Two;
            }
            return System.IO.Ports.StopBits.One;
        }

        /// <summary>
        /// Close the serial port
        /// </summary>
        public override void Close()
        {
            if (SystemPort != null)
            {
                SystemPort.DataReceived -= SystemPort_DataReceived;
                IsConnected = false;

                SystemPort.Close();
                SystemPort.Dispose();
                SystemPort = null;
            }
        }

        /// <summary>
        /// Open the serial port with the given parameters
        /// </summary>
        /// <param name="Port">COM port to open ("COM1", "COM2", etc)</param>
        /// <param name="Baud">Baud Rate</param>
        /// <param name="DataBits">Data Bits (usualy 8)</param>
        /// <param name="Stop">Stop Bits (usually 1)</param>
        /// <param name="ParityBits">Parity to use (usually N)</param>
        public override void Open(string Port, int Baud, int DataBits, StopBits Stop, Parity ParityBits)
        {
            Connect(Port, Baud, DataBits, Stop, ParityBits, true);
            if ((SystemPort != null) && SystemPort.IsOpen)
            {
                this.IsConnected = true;
                SystemPort.ErrorReceived += SystemPort_ErrorReceived;
                SystemPort.DataReceived += SystemPort_DataReceived;
            }
        }

        /// <summary>
        /// Attempt to open a serial port, retrying if needed to give Windows time to enable the driver of
        /// some virtual serial ports
        /// </summary>
        private void Connect(string Port, int Baud, int DataBits, StopBits Stop, Parity ParityBits, Boolean Retry)
        {
            try
            {
                if (SystemPort != null)
                    Close();

                SystemPort = new SerialPort(Port, Baud, ConvertParity(ParityBits), DataBits, ConvertStopBits(Stop));
                SystemPort.ReadTimeout = 100;
                SystemPort.WriteTimeout = 100;
                SystemPort.Open();
            }
            catch (Exception ex)
            {
                if (Retry)
                {
                    System.Threading.Thread.Sleep(500);
                    Connect(Port, Baud, DataBits, Stop, ParityBits, false);
                }
                else
                    throw ex;
            }

        }

        /// <summary>
        /// Event Handler called when an error is received at the COM port
        /// </summary>
        private void SystemPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            SerialError err = e.EventType;
        }

        /// <summary>
        /// Event handler called when data is received at the COM port
        /// </summary>
        private void SystemPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int BlockLimit = 1024;
            Queue<byte> DataBytes = new Queue<byte>();

            if ((SystemPort != null) && (SystemPort.IsOpen))
            {
                byte[] Buffer = new byte[BlockLimit];
                int BytesRead = SystemPort.BaseStream.Read(Buffer, 0, BlockLimit);
                if (BytesRead > 0)
                {
                    for (int i = 0; i < BytesRead; i++)
                        DataBytes.Enqueue(Buffer[i]);
                    TriggerDataIn(DataBytes);
                }
            }
        }

        /// <summary>
        /// Send a stream of bytes to the serial port
        /// </summary>
        /// <param name="SendData">Bytes to send</param>
        public override void Send(Queue<byte> SendData)
        {
            if (SendData == null)
                return;

            if ((SystemPort == null) || (!SystemPort.IsOpen))
                return;

            foreach (byte DataByte in SendData)
                SystemPort.BaseStream.WriteByte(DataByte);

            TriggerDataOut(SendData);
        }

        /// <summary>
        /// Flush any data in the send buffer to the connected device
        /// </summary>
        public override void Flush()
        {
            if ((SystemPort == null) || (!SystemPort.IsOpen))
                return;

            SystemPort.BaseStream.Flush();
        }

        #endregion
    }
}
