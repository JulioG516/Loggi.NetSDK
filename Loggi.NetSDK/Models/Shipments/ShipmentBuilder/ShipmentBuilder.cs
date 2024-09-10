using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Loggi.NetSDK.Models.Shipments.ShipmentBuilder
{
    public class ShipmentBuilder
    {
        private readonly Shipment _shipment;

        public ShipmentBuilder()
        {
            _shipment = new Shipment()
            {
                Packages = new List<Package>()
            };
        }

        public ShipmentBuilder SetShipFrom(ShipFrom shipFrom)
        {
            _shipment.ShipFrom = shipFrom;
            return this;
        }

        public ShipmentBuilder SetShipTo(ShipTo shipTo)
        {
            _shipment.ShipTo = shipTo;
            return this;
        }

        public ShipmentBuilder SetShippingCompany(ShippingCompany shippingCompany)
        {
            _shipment.ShippingCompany = shippingCompany;
            return this;
        }

        public ShipmentBuilder SetPickupType(string pickupType)
        {
            _shipment.PickupType = pickupType;
            return this;
        }

        public ShipmentBuilder SetDeliveryType(string deliveryType)
        {
            _shipment.DeliveryType = deliveryType;
            return this;
        }

        public ShipmentBuilder AddPackage(Package package)
        {
            _shipment.Packages.Add(package);
            return this;
        }

        public ShipmentBuilder SetExternalServiceId(string? externalServiceId)
        {
            _shipment.ExternalServiceId = externalServiceId;
            return this;
        }

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