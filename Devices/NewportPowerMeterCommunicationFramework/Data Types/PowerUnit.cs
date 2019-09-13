namespace NewportPowerMeterCommunicationFramework.DataTypes
{
    /// <summary>
    /// Possible units for power readings from the meter
    /// </summary>
    public enum PowerUnit : byte
    {
        /// <summary>
        /// Power in Amps
        /// </summary>
        Amperes = 0,

        /// <summary>
        /// Power in Watts
        /// </summary>
        Watts = 2,

        /// <summary>
        /// Power in W/cm2
        /// </summary>
        WattsPerSquareCentimeter = 3,

        /// <summary>
        /// Power in DBm
        /// </summary>
        DecibalMilliwattts = 6,

        /// <summary>
        /// Unknown power unit
        /// </summary>
        Unknown = 0x0FF
    }
}
