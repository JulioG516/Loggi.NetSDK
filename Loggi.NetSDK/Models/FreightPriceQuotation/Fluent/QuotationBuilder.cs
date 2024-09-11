using System;
using System.Collections.Generic;

namespace Loggi.NetSDK.Models.FreightPriceQuotation.Fluent
{
    public class QuotationBuilder : ICanSetUse, ICanSetQuotationProperties
    {
        private QuotationPickupTypes? _quotationPickupTypes;
        private QuotationExternalServices? _quotationExternalServices;
        private bool _isExternalServices;

        private QuotationBuilder()
        {
        }

        public static ICanSetUse CreateBuilder()
        {
            return new QuotationBuilder();
        }

        public ICanSetQuotationProperties UseExternalIds(List<string> ids)
        {
            if (_quotationPickupTypes != null)
                throw new InvalidOperationException("Não pode usar Externalids quando já esta usando PickupTypes.");

            _isExternalServices = true;
            _quotationExternalServices = new QuotationExternalServices()
            {
                ExternalServiceIds = ids,
                Packages = new List<QuotationPackage>()
            };
            return this;
        }

        public ICanSetQuotationProperties UsePickupTypes(List<string> ids)
        {
            if (_isExternalServices)
                throw new InvalidOperationException("Não pode usar PickupTypes quando já esta usando Externalids.");

            _quotationPickupTypes = new QuotationPickupTypes()
            {
                PickupTypes = ids,
                Packages = new List<QuotationPackage>()
            };
            return this;
        }

        public ICanSetQuotationProperties SetShipFrom(IQuotationAddress shipFrom)
        {
            if (_quotationPickupTypes != null)
                _quotationPickupTypes.ShipFrom = shipFrom;
            else if (_quotationExternalServices != null)
                _quotationExternalServices.ShipFrom = shipFrom;
            else
                throw new InvalidOperationException("Deve especificar se usar PickupTypes ou ExternalIds primeiro.");

            return this;
        }

        public ICanSetQuotationProperties SetShipTo(IQuotationAddress shipTo)
        {
            if (_quotationPickupTypes != null)
                _quotationPickupTypes.ShipTo = shipTo;
            else if (_quotationExternalServices != null)
                _quotationExternalServices.ShipTo = shipTo;
            else
                throw new InvalidOperationException("Deve especificar se usar PickupTypes ou ExternalIds primeiro.");

            return this;
        }
        
        public ICanSetQuotationProperties AddPackage(QuotationPackage packages)
        {
            if (_quotationPickupTypes != null)
                _quotationPickupTypes.Packages!.Add(packages);
            else if (_quotationExternalServices != null)
                _quotationExternalServices.Packages!.Add(packages);
            else
                throw new InvalidOperationException("Deve especificar se usar PickupTypes ou ExternalIds primeiro.");

            return this;
        }

        public Quotation Build()
        {
            if (_quotationPickupTypes != null)
            {
                if (_quotationPickupTypes.ShipFrom == null)
                    throw new InvalidOperationException("ShipFrom é necessario para ser enviado.");

                if (_quotationPickupTypes.ShipTo == null)
                    throw new InvalidOperationException("ShipTo é necessario para ser enviado.");

                if (_quotationPickupTypes.Packages?.Count == 0)
                    throw new InvalidOperationException("É necessario ao menos um pacote para ser enviado.");

                return _quotationPickupTypes;
            }

            if (_quotationExternalServices != null)
            {
                if (_quotationExternalServices.ShipFrom == null)
                    throw new InvalidOperationException("ShipFrom é necessario para ser enviado.");

                if (_quotationExternalServices.ShipTo == null)
                    throw new InvalidOperationException("ShipTo é necessario para ser enviado.");

                if (_quotationExternalServices.Packages?.Count == 0)
                    throw new InvalidOperationException("É necessario ao menos um pacote para ser enviado.");


                return _quotationExternalServices;
            }

            throw new InvalidOperationException("Deve especificar se usar PickupTypes ou ExternalIds.");
        }
    }
}