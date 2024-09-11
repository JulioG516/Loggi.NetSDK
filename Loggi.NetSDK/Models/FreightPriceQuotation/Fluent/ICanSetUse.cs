using System.Collections.Generic;

namespace Loggi.NetSDK.Models.FreightPriceQuotation.Fluent
{
    public interface ICanSetUse
    {
        public ICanSetQuotationProperties UseExternalIds(List<string> ids);
        public ICanSetQuotationProperties UsePickupTypes(List<string> ids);
    }
}