namespace Loggi.NetSDK.Models.FreightPriceQuotation.Fluent
{
    public interface ICanSetQuotationProperties
    {
        public ICanSetQuotationProperties SetShipFrom(IQuotationAddress shipFrom);
        public ICanSetQuotationProperties SetShipTo(IQuotationAddress shipTo);
        // ICanSetQuotationProperties SetPackages(QuotationPackage packages);
        ICanSetQuotationProperties AddPackage(QuotationPackage packages);
        Quotation Build();
    }
}