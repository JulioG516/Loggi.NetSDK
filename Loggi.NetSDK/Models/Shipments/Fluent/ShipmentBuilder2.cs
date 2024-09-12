using System;
using System.Collections.Generic;
using System.Linq;
using Loggi.NetSDK.Models.Enums;

namespace Loggi.NetSDK.Models.Shipments.Fluent
{
    /// <summary>
    /// ShipmentBuilder para facilitar a criação de objetos através da FluentAPI. <see cref="Shipment"/>
    /// </summary>
    public class ShipmentBuilder2 : ICanSetShipmentPickupType, ICanSetShipmentProperties, ICanUseShipmentPickupType,
        ICanSetShipmentDeliveryType
    {
        private Shipment _shipment;

        private ShipmentBuilder2()
        {
            _shipment = new Shipment()
            {
                Packages = new List<Package>()
            };
        }

        /// <summary>
        /// Cria uma nova instancia do ShipmentBuilder
        /// </summary>
        /// <returns>Objeto <see cref="ShipmentBuilder2"/></returns>
        public static ICanSetShipmentPickupType CreateBuilder()
        {
            return new ShipmentBuilder2();
        }


        /// <inheritdoc />
        public ICanUseShipmentPickupType SetPickupTypes()
        {
            return this;
        }

        /// <inheritdoc />
        public ICanSetShipmentProperties UseSpot()
        {
            _shipment.PickupType = PickupTypes.Spot;
            return this;
        }

        /// <inheritdoc />
        public ICanSetShipmentProperties UseDefault()
        {
            _shipment.PickupType = PickupTypes.Spot;
            return this;
        }

        /// <inheritdoc />
        public ICanSetShipmentProperties UseDedicated()
        {
            _shipment.PickupType = PickupTypes.Dedicated;
            return this;
        }

        /// <inheritdoc />
        public ICanSetShipmentProperties UseDropoff()
        {
            _shipment.PickupType = PickupTypes.DropOff;
            return this;
        }

        /// <inheritdoc />
        public ICanSetShipmentProperties UseMilkRun()
        {
            _shipment.PickupType = PickupTypes.MilkRun;
            return this;
        }

        /// <inheritdoc />
        public ICanSetShipmentProperties UseCrossBorder()
        {
            _shipment.PickupType = PickupTypes.CrossBorder;
            return this;
        }


        /// <inheritdoc />
        public ICanSetShipmentProperties SetExternalId(string id)
        {
            _shipment.ExternalServiceId = id;
            return this;
        }

        /// <inheritdoc />
        public ICanSetShipmentProperties SetShipFrom(ShipFrom shipFrom)
        {
            _shipment.ShipFrom = shipFrom;
            return this;
        }

        /// <inheritdoc />
        public ICanSetShipmentProperties SetShipTo(ShipTo shipTo)
        {
            _shipment.ShipTo = shipTo;
            return this;
        }

        /// <inheritdoc />
        public ICanSetShipmentProperties SetShippingCompany(ShippingCompany shippingCompany)
        {
            _shipment.ShippingCompany = shippingCompany;
            return this;
        }

        /// <inheritdoc />
        public ICanSetShipmentDeliveryType SetDeliveryType()
        {
            return this;
        }


        /// <inheritdoc />
        public ICanSetShipmentProperties CustomerDoor()
        {
            _shipment.DeliveryType = DeliveryTypes.CustomerDoor;
            return this;
        }

        /// <inheritdoc />
        public ICanSetShipmentProperties CrossDocking()
        {
            _shipment.DeliveryType = DeliveryTypes.CrossDocking;
            return this;
        }


        /// <inheritdoc />
        public ICanSetShipmentProperties AddPackage(Package package)
        {
            _shipment.Packages.Add(package);
            return this;
        }

        /// <inheritdoc />
        public Shipment Build()
        {
            if (_shipment.ShipFrom == null)
                throw new InvalidOperationException("ShipFrom não pode ser null.");

            if (_shipment.ShipTo == null)
                throw new InvalidOperationException("ShipTo não pode ser null.");

            if (!_shipment.Packages.Any())
                throw new InvalidOperationException("Packages deve conter ao menos um valor.");

            return _shipment;
        }
    }
}