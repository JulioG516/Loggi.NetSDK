using System;
using System.Collections.Generic;
using System.Linq;

namespace Loggi.NetSDK.Models.Shipments.ShipmentBuilder
{
    /// <summary>
    /// ShipmentBuilder para facilitar a criação de objetos <see cref="Shipment"/>
    /// </summary>
    public class ShipmentBuilder
    {
        private readonly Shipment _shipment;

        private ShipmentBuilder()
        {
            _shipment = new Shipment
            {
                Packages = new List<Package>()
            };
        }

        /// <summary>
        /// Retorna um ShipmentBuilder
        /// </summary>
        /// <returns><see cref="ShipmentBuilder"/></returns>
        public static ShipmentBuilder CreateBuilder()
        {
            return new ShipmentBuilder();
        }

        /// <summary>
        /// Seta o ShipFrom no Shipment que está sendo criado.
        /// </summary>
        /// <param name="shipFrom"></param>
        /// <returns></returns>
        public ShipmentBuilder SetShipFrom(ShipFrom shipFrom)
        {
            _shipment.ShipFrom = shipFrom;
            return this;
        }

        /// <summary>
        /// Seta o ShipTo no Shipment que esta sendo criado.
        /// </summary>
        /// <param name="shipTo"></param>
        /// <returns></returns>
        public ShipmentBuilder SetShipTo(ShipTo shipTo)
        {
            _shipment.ShipTo = shipTo;
            return this;
        }

        /// <summary>
        /// Seta o ShippingCompany no Shipment que esta sendo criado.
        /// </summary>
        /// <param name="shippingCompany"></param>
        /// <returns></returns>
        public ShipmentBuilder SetShippingCompany(ShippingCompany shippingCompany)
        {
            _shipment.ShippingCompany = shippingCompany;
            return this;
        }

        /// <summary>
        /// Seta o PickupTypes no Shipment que esta sendo criado.
        /// </summary>
        /// <param name="pickupType"></param>
        /// <returns></returns>
        public ShipmentBuilder SetPickupType(string pickupType)
        {
            _shipment.PickupType = pickupType;
            return this;
        }

        /// <summary>
        /// Seta o DeliveryType no Shipment queta sendo criado.
        /// </summary>
        /// <param name="deliveryType"></param>
        /// <returns></returns>
        public ShipmentBuilder SetDeliveryType(string deliveryType)
        {
            _shipment.DeliveryType = deliveryType;
            return this;
        }


        /// <summary>
        /// Adiciona um package na lista de packages no Shipment que esta sendo criado.
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        public ShipmentBuilder AddPackage(Package package)
        {
            _shipment.Packages.Add(package);
            return this;
        }

        /// <summary>
        /// Seta o valor de ExternalServicesIds, utilizar este ou PickupTypes.
        /// </summary>
        /// <param name="externalServiceId"></param>
        /// <returns></returns>
        public ShipmentBuilder SetExternalServiceId(string? externalServiceId)
        {
            _shipment.ExternalServiceId = externalServiceId;
            return this;
        }

        /// <summary>
        /// Constroi o objeto Shipment
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Shipment Build()
        {
            // Valida os campos com Required.
            if (_shipment.ShipFrom == null)
                throw new InvalidOperationException("ShipFrom é necessario para ser montado.");

            if (_shipment.ShipTo == null)
                throw new InvalidOperationException("ShipTo é necessario para ser montado.");

            if (_shipment.Packages == null || !_shipment.Packages.Any())
                throw new InvalidOperationException("Ao menos um pacote é necessario para ser montado.");


            return _shipment;
        }
    }
}