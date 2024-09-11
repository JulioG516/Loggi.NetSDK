namespace Loggi.NetSDK.Models.Enums
{
    /// <summary>
    /// Contém os tipos de entrega feito pela Loggi.
    /// </summary>
    public static class DeliveryTypes
    {
        /// <summary>
        /// Entrega diretamente na porta do destinatário.
        /// </summary>
        public const string CustomerDoor = "DELIVERY_TYPE_CUSTOMER_DOOR";

        /// <summary>
        /// Entrega no centro de distribuição da Loggi.
        /// </summary>
        public const string CrossDocking = "DELIVERY_TYPE_LOGGI_CROSSDOCKING";
    }
}