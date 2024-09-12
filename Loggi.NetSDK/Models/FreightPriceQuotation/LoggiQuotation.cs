using System.Text.Json.Serialization;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Loggi.NetSDK.Models.FreightPriceQuotation
{
    /// <summary>
    /// Objeto que representa a cotação devolvida pela Loggi ao utilizar a API Freight Price Quotation
    /// </summary>
    public class LoggiQuotation
    {
        [JsonPropertyName("price")] public QuotationPrice Price { get; set; }
        [JsonPropertyName("sloInDays")] public int SloInDays { get; set; }
        [JsonPropertyName("freightType")] public string FreightType { get; set; }
        [JsonPropertyName("freightTypeLabel")] public string FreightTypeLabel { get; set; }
        [JsonPropertyName("pickup_type")] public string Pickup_type { get; set; }
        [JsonPropertyName("externalServiceIds")] public string ExternalServiceIds { get; set; }
    }
}