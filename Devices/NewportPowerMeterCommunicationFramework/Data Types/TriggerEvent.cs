namespace NewportPowerMeterCommunicationFramework.DataTypes
{
    /// <summary>
    /// Possible trigger events for the power meter
    /// </summary>
    public enum TriggerEvent
    {
        /// <summary>
        /// No trigger event - continuous measurement
        /// </summary>
        None = 0,

        /// <summary>
        /// Occurs when an appripriate edge is seen on the external trigger
        /// </summary>
        TiggerIn = 1,

        /// <summary>
        /// Occurs when a designated soft key is pressed
        /// </summary>
        SoftKey = 2,

        /// <summary>
        /// Occurs when a software command is received
        /// </summary>
        Command = 3,

        /// <summary>
        /// Occurs when a specified value is measured (only valid for Trigger Stop events)
        /// </summary>
        MeasuredValue = 4,

        /// <summary>
        /// Occurs a number of ms after trigger is started (only valid for Trigger Stop events)
        /// </summary>
        Interval = 5
    }
}
