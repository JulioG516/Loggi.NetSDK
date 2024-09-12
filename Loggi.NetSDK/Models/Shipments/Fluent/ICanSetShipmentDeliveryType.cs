namespace Loggi.NetSDK.Models.Shipments.Fluent
{
    /// <summary>
    /// Interface para definir os tipos de entrega do Shipment via FluentAPI.
    /// </summary>
    public interface ICanSetShipmentDeliveryType
    {
        /// <summary>
        /// Entrega diretamente na porta do destinatário.
        /// </summary>
        /// <returns>Uma interface para definir as propriedades do Shipment.</returns>
        public ICanSetShipmentProperties CustomerDoor();


        /// <summary>
        /// Entrega no centro de distribuição da Loggi.
        /// </summary>
        /// <returns>Uma interface para definir as propriedades do <see cref="Shipment"/>.</returns>
        public ICanSetShipmentProperties CrossDocking();
    }
}