namespace NewportPowerMeterCommunicationFramework.DataTypes
{
    /// <summary>
    /// Possible external trigger signals for the power meter
    /// </summary>
    public enum TriggerEdge
    {
        /// <summary>
        /// External trigger is a falling edge
        /// </summary>
        Falling = 0, 

        /// <summary>
        /// External trigger is a rising edge
        /// </summary>
        Rising = 1
    }
}
