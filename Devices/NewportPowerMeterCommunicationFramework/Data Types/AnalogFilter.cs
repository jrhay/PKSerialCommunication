namespace NewportPowerMeterCommunicationFramework.DataTypes
{
    /// <summary>
    /// Possible Analog Filter Values
    /// </summary>
    public enum AnalogFilter
    {
        /// <summary>
        /// No Filter
        /// </summary>
        None = 0,
     
        /// <summary>
        /// 12.5 kHz
        /// </summary>
        TwelveAndAHalfkHz = 1,
        
        /// <summary>
        /// 1 kHz
        /// </summary>
        OnekHz = 2,
        
        /// <summary>
        /// 5 Hz
        /// </summary>
        FiveHz = 3
    }
}
