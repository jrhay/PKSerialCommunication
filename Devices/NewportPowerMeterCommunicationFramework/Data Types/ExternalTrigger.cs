namespace NewportPowerMeterCommunicationFramework.DataTypes
{
    /// <summary>
    /// Possible external trigger configurations for the power meter
    /// </summary>
    public enum ExternalTrigger
    {
        /// <summary>
        /// External trigger is disabled
        /// </summary>
        None = 0,

        /// <summary>
        /// External trigger enabled on Channel A only
        /// </summary>
        ChannelA = 1,

        /// <summary>
        /// External trigger enabled on Channel B only
        /// </summary>
        ChannelB = 2,

        /// <summary>
        /// External trigger enabled on both Channel A and Channel B
        /// </summary>
        ChannelAB = 3
    }
}
