using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.FreightPriceQuotation
{
    public class QuotationResponse
    {
        [JsonPropertyName("quotations")] public List<LoggiQuotation> Quotations { get; set; }
    }
}