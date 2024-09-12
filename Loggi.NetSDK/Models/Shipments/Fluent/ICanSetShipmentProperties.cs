namespace Loggi.NetSDK.Models.Shipments.Fluent
{
    /// <summary>
    /// Interface para que possa ser utilizada a FluentAPI para o <see cref="ShipmentBuilder"/>
    /// </summary>
    public interface ICanSetShipmentProperties
    {
        /// <summary>
        /// Define o ID externo para o <see cref="Shipment"/>.
        /// </summary>
        /// <param name="id">O ID externo</param>
        /// <returns>Uma interface para definir as propriedades do <see cref="Shipment"/>.</returns>
        public ICanSetShipmentProperties SetExternalId(string id);

        /// <summary>
        /// Define o endereço de origem para o <see cref="Shipment"/>.
        /// </summary>
        /// <param name="shipFrom">O endereço de origem.</param>
        /// <returns>Uma interface para definir as propriedades do <see cref="Shipment"/>.</returns>
        public ICanSetShipmentProperties SetShipFrom(ShipFrom shipFrom);

        /// <summary>
        /// Define o endereço de destino para o <see cref="Shipment"/>.
        /// </summary>
        /// <param name="shipTo">O endereço de destino.</param>
        /// <returns>Uma interface para definir as propriedades do <see cref="Shipment"/>.</returns>
        public ICanSetShipmentProperties SetShipTo(ShipTo shipTo);

        /// <summary>
        /// Define a empresa de transporte para o <see cref="Shipment"/>.
        /// </summary>
        /// <param name="shippingCompany">A empresa de transporte.</param>
        /// <returns>Uma interface para definir as propriedades do <see cref="Shipment"/>.</returns>
        public ICanSetShipmentProperties SetShippingCompany(ShippingCompany shippingCompany);

        /// <summary>
        /// Define o tipo de entrega para o <see cref="Shipment"/>.
        /// </summary>
        /// <returns>Uma interface para definir o tipo de entrega do <see cref="Shipment"/>.</returns>
        public ICanSetShipmentDeliveryType SetDeliveryType();

        /// <summary>
        /// Adiciona um pacote ao <see cref="Shipment"/>.
        /// </summary>
        /// <param name="package">O pacote a ser adicionado.</param>
        /// <returns>Uma interface para definir as propriedades do <see cref="Shipment"/>.</returns>
        public ICanSetShipmentProperties AddPackage(Package package);

        /// <summary>
        /// Constrói o <see cref="Shipment"/>.
        /// </summary>
        /// <returns>O <see cref="Shipment"/> construída.</returns>
        public Shipment Build();
    }
}