using System;

namespace NewportPowerMeterCommunicationFramework.Exceptions
{
    /// <summary>
    /// Exception indicating an error parsing a command or response from the Newport Power Meter
    /// (These errors are errors in communicating with the meter)
    /// Exception message will contain the command attempted
    /// </summary>
    public class NewportMeterCommandException : Exception
    {
        public NewportMeterCommandException() : base()
        {
        }

        public NewportMeterCommandException(string message) : base(message)
        {
        }

        public NewportMeterCommandException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}
