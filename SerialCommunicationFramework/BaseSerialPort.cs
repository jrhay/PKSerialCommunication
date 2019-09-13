using System;
using System.Collections.Generic;
using System.Text;

namespace SerialCommunicationFramework
{
    /// <summary>
    /// Base virtual implementation of an ISerialPort interface.
    /// Implements event handling and IDisposable interface, and virtual ISerialPort interface methods
    /// that mostly throw NotImplemented exceptions. 
    /// 
    /// Platform-specific code can derives from this and override the virtual methods as needed.
    /// </summary>
    public class BaseSerialPort : ISerialPort
    {
        public event DataInOutHandler DataIn;
        public event DataInOutHandler DataOut;
        public event ConnectionStateChanged ConnectionChanged;

        /// <summary>
        /// Platform-specific subclasses can call this to trigger the DataIn event
        /// </summary>
        /// <param name="DataBytes">Data received</param>
        protected void TriggerDataIn(Queue<byte> DataBytes)
        {
            DataIn?.Invoke(this, DataBytes);
        }

        /// <summary>
        /// Platform-specific subclasses can call this to trigger the DataOut event
        /// </summary>
        /// <param name="DataBytes">Data sent</param>
        protected void TriggerDataOut(Queue<byte> DataBytes)
        {
            DataOut?.Invoke(this, DataBytes);
        }

        /// <summary>
        /// Null Constructor to create a new instance
        /// </summary>
        public BaseSerialPort()
        {
        }

        /// <summary>
        /// Is the serial port in the "connected" state (was an attempt to open successful with no close?)
        /// </summary>
        public Boolean IsConnected
        {
            get
            {
                return _IsConnected;
            }
            protected set
            {
                if (_IsConnected != value)
                {
                    _IsConnected = value;
                    ConnectionChanged?.Invoke(this);
                }
            }
        }
        private Boolean _IsConnected;


        #region Dummy ISerialPort interface; platforms should override these

        public virtual void Close()
        {
            throw new NotImplementedException();
        }

        public virtual void Flush()
        {
            throw new NotImplementedException();
        }

        public virtual void Open(string Port, int Baud, int DataBits, StopBits Stop, Parity ParityBits)
        {
            throw new NotImplementedException();
        }

        public virtual void Send(Queue<byte> SendData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Send a stream of bytes to the serial port
        /// </summary>
        /// <param name="SendData">Bytes to send</param>
        public virtual void Send(byte[] SendData)
        {
            Send(new Queue<byte>(SendData));
        }


        #endregion

        #region IDisposable Pattern; platforms only need override Dispose() if non-managed resources are allocated

        ~BaseSerialPort()
        {
            Dispose(false);
        }

        public virtual void Dispose()
        {
            try
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            finally
            {
                // Call base Dispose(), if needed
                // base.Dispose();
            }
        }

        public void Dispose(Boolean FreeManagedObjects)
        {
            Close();
            if (FreeManagedObjects)
            {

            }
        }

        #endregion
    }
}
