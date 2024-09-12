namespace Loggi.NetSDK.Models.Shipments.Fluent
{
    /// <summary>
    /// Interface para definir os tipos de coleta do Shipment via FluentAPI.
    /// </summary>
    public interface ICanSetShipmentPickupType
    {
        /// <summary>
        /// Define os tipos de coleta para o <see cref="Shipment"/>.
        /// </summary>
        /// <returns>Uma interface para usar o tipo de coleta do <see cref="Shipment"/>.</returns>
        public ICanUseShipmentPickupType SetPickupTypes();
    }
}