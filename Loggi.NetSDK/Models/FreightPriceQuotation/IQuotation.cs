using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Converters;

namespace Loggi.NetSDK.Models.FreightPriceQuotation
{
    internal interface IQuotation
    {
    }

    public class Quotation : IQuotation
    {
        [Required(ErrorMessage = "ShipFrom é necessario.")]
        [JsonPropertyName("shipFrom")]
        [JsonConverter(typeof(QuotationAddressConverter))]
        public IQuotationAddress ShipFrom { get; set; }

        [Required(ErrorMessage = "ShipTo é necessario.")]
        [JsonPropertyName("shipTo")]
        [JsonConverter(typeof(QuotationAddressConverter))]
        public IQuotationAddress ShipTo { get; set; }

        [JsonPropertyName("packages")] public List<QuotationPackage>? Packages { get; set; }
    }

    public class QuotationPickupTypes : Quotation
    {
        [JsonPropertyName("pickupTypes")] public List<string>? PickupTypes { get; set; }
    }

    public class QuotationExternalServices : Quotation
    {
        [JsonPropertyName("externalServiceIds")]
        public List<string>? ExternalServiceIds { get; set; }
    }
}