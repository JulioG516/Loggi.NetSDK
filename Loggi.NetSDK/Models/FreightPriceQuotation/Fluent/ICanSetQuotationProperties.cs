namespace Loggi.NetSDK.Models.FreightPriceQuotation.Fluent
{
    public interface ICanSetQuotationProperties
    {
        public ICanSetQuotationProperties SetShipFrom(IQuotationAddress shipFrom);
        public ICanSetQuotationProperties SetShipTo(IQuotationAddress shipTo);
        public ICanSetQuotationProperties AddPackage(QuotationPackage packages);
        public Quotation Build();
    }
}