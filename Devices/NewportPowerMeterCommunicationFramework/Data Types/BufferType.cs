namespace NewportPowerMeterCommunicationFramework.DataTypes
{
    /// <summary>
    /// Possible Power Meter Buffer Type
    /// </summary>
    public enum BufferType
    {
        /// <summary>
        /// Unknown buffer type / Can not determine
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Fixed Size Buffer
        /// </summary>
        Fixed = 0,

        /// <summary>
        /// Continuous ring buffer, oldest values overwritten when buffer fills
        /// </summary>
        Ring  = 1
    }
}
