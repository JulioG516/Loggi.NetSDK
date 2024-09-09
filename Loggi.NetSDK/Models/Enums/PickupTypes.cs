namespace Loggi.NetSDK.Models.Enums
{
    /// <summary>
    /// Contém os tipos de coleta realizado pela Loggi.
    /// </summary>
    public static class PickupTypes
    {
        /// <summary>
        /// Tipo de coleta pulverizada.
        /// </summary>
        public const string PickupTypeSpot = "PICKUP_TYPE_SPOT";

        /// <summary>
        /// Tipo de coleta dedicada.
        /// </summary>
        public const string PickupTypeDedicated = "PICKUP_TYPE_DEDICATED ";

        /// <summary>
        /// Tipo de coleta drop off.
        /// </summary>
        public const string PickupTypeDropOff = "PICKUP_TYPE_DROP_OFF ";

        /// <summary>
        /// Tipo de coleta grade fixa.
        /// </summary>
        public const string PickupTypeMilkRun = "PICKUP_TYPE_MILK_RUN";

        /// <summary>
        /// Tipo de coleta sem etiqueta.
        /// </summary>
        public const string PickupTypeNotLabelled = "PICKUP_TYPE_SPOT_NOT_LABELLED ";

        /// <summary>
        /// Tipo de coleta cross border.
        /// </summary>
        public const string PickupTypeCrossBorder = "PICKUP_TYPE_CROSS_BORDER ";
    }
}