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
        public const string Spot = "PICKUP_TYPE_SPOT";

        /// <summary>
        /// Tipo de coleta dedicada.
        /// </summary>
        public const string Dedicated = "PICKUP_TYPE_DEDICATED ";

        /// <summary>
        /// Tipo de coleta drop off.
        /// </summary>
        public const string DropOff = "PICKUP_TYPE_DROP_OFF ";

        /// <summary>
        /// Tipo de coleta grade fixa.
        /// </summary>
        public const string MilkRun = "PICKUP_TYPE_MILK_RUN";

        /// <summary>
        /// Tipo de coleta sem etiqueta.
        /// </summary>
        public const string NotLabelled = "PICKUP_TYPE_SPOT_NOT_LABELLED ";

        /// <summary>
        /// Tipo de coleta cross border.
        /// </summary>
        public const string CrossBorder = "PICKUP_TYPE_CROSS_BORDER ";
    }
}