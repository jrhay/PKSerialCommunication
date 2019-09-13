using System;

namespace NewportPowerMeterCommunicationFramework.Exceptions
{
    /// <summary>
    /// Exception indicating an error executing a command on the Newport Power Meter
    /// These errors are reported from the meter intself
    /// </summary>
    public class NewportMeterException : Exception
    {
        /// <summary>
        /// The Newport error code for this exception
        /// </summary>
        public int ErrorCode { get; internal set; }

        public NewportMeterException() : base()
        {
        }

        public NewportMeterException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public NewportMeterException(string message) : base(message)
        {
        }

        public NewportMeterException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}
