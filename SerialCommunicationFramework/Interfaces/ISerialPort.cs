using System;
using System.Collections.Generic;

namespace SerialCommunicationFramework
{
    /// <summary>
    /// Event generated when data is sent or received on an ISerialPort
    /// </summary>
    /// <param name="Sender">ISerialPort instance generating this event</param>
    /// <param name="DataBytes">Bytes Transmitted</param>
    public delegate void DataInOutHandler(ISerialPort sender, Queue<byte> DataBytes);

    /// <summary>
    /// Event generated when the .IsConnected property of an ISerialPort changes state
    /// </summary>
    /// <param name="Sender">ISerialPort instance generating this event</param>
    public delegate void ConnectionStateChanged(ISerialPort sender);

    /// <summary>
    /// Parity to use for the serial port
    /// </summary>
    public enum Parity
    {
        None = 0,
        Odd,
        Even,
        Mark,
        Space
    }

    /// <summary>
    /// Stop bits to use for the serial port
    /// </summary>
    public enum StopBits
    {
        One = 0,
        OnePointFive,
        Two
    }

    /// <summary>
    /// Abstract interface for a serial port
    /// </summary>
    public interface ISerialPort : IDisposable
    {
        /// <summary>
        /// Event Handler called when data is received from the serial port
        /// </summary>
        event DataInOutHandler DataIn;

        /// <summary>
        /// Event Handler called when data is ssent to the serial port
        /// </summary>
        event DataInOutHandler DataOut;

        /// <summary>
        /// Event Handler called when .IsConnected changes state
        /// </summary>
        event ConnectionStateChanged ConnectionChanged;

        /// <summary>
        /// Is the serial port in the "connected" state (was an attempt to open successful with no close?)
        /// </summary>
        Boolean IsConnected { get; }

        /// <summary>
        /// Close the serial port without flushing any unsent data, freeing all resources associated with it
        /// </summary>
        void Close();

        /// <summary>
        /// Attempt to open a serial port with the specified parameters, should throw
        /// an exception on any error connecting
        /// </summary>
        /// <param name="Port">Serial port to open</param>
        /// <param name="Baud">Baud rate</param>
        /// <param name="DataBits">Number of data bits</param>
        /// <param name="Stop">Number of stop bits</param>
        /// <param name="ParityBits">Parity to use</param>
        void Open(String Port, int Baud, int DataBits, StopBits Stop, Parity ParityBits);

        /// <summary>
        /// Send raw bytes to the connected device
        /// </summary>
        /// <param name="SendData">Bytes to send</param>
        void Send(Queue<byte> SendData);

        /// <summary>
        /// Send raw bytes to the connected device
        /// </summary>
        /// <param name="SendData">Bytes to send</param>
        void Send(byte[] SendData);

        /// <summary>
        /// Flush any data in the send buffer to the connected device
        /// </summary>
        void Flush();

    }
}
