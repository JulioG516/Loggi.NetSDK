namespace Loggi.NetSDK.Models.Shipments.Fluent
{
    /// <summary>
    /// Interface para usar os tipos de coleta do <see cref="Shipment"/>.
    /// </summary>
    public interface ICanUseShipmentPickupType
    {
        /// <summary>
        /// Define o tipo de coleta como Spot.
        /// </summary>
        /// <returns>Uma interface para definir as propriedades do <see cref="Shipment"/>.</returns>
        public ICanSetShipmentProperties UseSpot();

        /// <summary>
        /// Define o tipo de coleta como Padrão. Atualmente é Spot.
        /// </summary>
        /// <returns>Uma interface para definir as propriedades do <see cref="Shipment"/>.</returns>
        public ICanSetShipmentProperties UseDefault();

        /// <summary>
        /// Define o tipo de coleta como Dedicado.
        /// </summary>
        /// <returns>Uma interface para definir as propriedades do <see cref="Shipment"/>.</returns>
        public ICanSetShipmentProperties UseDedicated();

        /// <summary>
        /// Define o tipo de coleta como Dropoff.
        /// </summary>
        /// <returns>Uma interface para definir as propriedades do <see cref="Shipment"/>.</returns>
        public ICanSetShipmentProperties UseDropoff();

        /// <summary>
        /// Define o tipo de coleta como Milk Run.
        /// </summary>
        /// <returns>Uma interface para definir as propriedades do <see cref="Shipment"/>.</returns>
        public ICanSetShipmentProperties UseMilkRun();

        /// <summary>
        /// Define o tipo de coleta como Cross Border.
        /// </summary>
        /// <returns>Uma interface para definir as propriedades do <see cref="Shipment"/>.</returns>
        public ICanSetShipmentProperties UseCrossBorder();
    }
}