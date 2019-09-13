namespace NewportPowerMeterCommunicationFramework.DataTypes
{
    /// <summary>
    /// Possible acquisition modes for the power meter
    /// </summary>
    public enum AcquisitionMode
    {
        /// <summary>
        /// Unknown Mode / Can't Determine
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// DC Continuous
        /// </summary>
        Continuous = 0,

        /// <summary>
        /// DC Single
        /// </summary>
        Single   = 1,

        /// <summary>
        /// Peak-to-peak Continuous
        /// </summary>
        ContinuousPeakToPeak = 3,

        /// <summary>
        /// Peak-to-peak Single
        /// </summary>
        SinglePeakToPeak = 4,

        /// <summary>
        /// RMS
        /// </summary>
        RMS = 7
    }
}
