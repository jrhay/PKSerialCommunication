using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCommunicationFramework
{
    /// <summary>
    /// Enumerate attached system serial ports
    /// </summary>
    public class WindowsSerialPortEnumerator : ISerialPortEnumerator
    {
        /// <summary>
        /// Get a list of all serial ports currently known
        /// </summary>
        /// <returns>List of serial port name strings</returns>
        public IEnumerable<String> EnumerateSerialPortNames()
        {
            return System.IO.Ports.SerialPort.GetPortNames();
        }

        /// <summary>
        /// Does a particular string match a currently known system COM port name?
        /// </summary>
        /// <param name="Portname">String to check</param>
        /// <returns>TRUE if the string represents a current system COM port, FALSE otherwise</returns>
        public Boolean IsSystemSerialPort(String Portname)
        {
            return (EnumerateSerialPortNames().Any(i => i.Equals(Portname, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}
