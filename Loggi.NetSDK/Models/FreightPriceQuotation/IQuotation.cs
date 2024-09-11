using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.FreightPriceQuotation
{
    internal interface IQuotation
    {
    }

    public class Quotation : IQuotation
    {
        [Required(ErrorMessage = "ShipFrom é necessario.")]
        [JsonPropertyName("shipFrom")]
        public IQuotationAddress? ShipFrom { get; set; }

        [Required(ErrorMessage = "ShipTo é necessario.")]
        [JsonPropertyName("shipTo")]
        public IQuotationAddress? ShipTo { get; set; }

        [JsonPropertyName("packages")] public QuotationPackage? Packages { get; set; }
    }

    public class QuotationPickupTypes : Quotation
    {
        [JsonPropertyName("pickupTypes")] 
        public List<string>? PickupTypes { get; set; }
    }

    public class QuotationExternalServices : Quotation
    {
        [JsonPropertyName("externalServiceIds")]
        public List<string>? ExternalServiceIds { get; set; }
    }
}