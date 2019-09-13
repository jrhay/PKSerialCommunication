using System;
using System.Collections.Generic;
using System.Text;

namespace SerialCommunicationFramework
{
    /// <summary>
    /// Abstract interface for a class that can enumerate serial ports on particular hardware
    /// </summary>
    public interface ISerialPortEnumerator
    {
        /// <summary>
        /// Get a list of all serial ports currently known
        /// </summary>
        /// <returns>List of serial port name strings</returns>
        IEnumerable<String> EnumerateSerialPortNames();

        /// <summary>
        /// Does a particular string match a currently known system COM port name?
        /// </summary>
        /// <param name="Portname">String to check</param>
        /// <returns>TRUE if the string represents a current system COM port, FALSE otherwise</returns>
        Boolean IsSystemSerialPort(String Portname);
    }
}
