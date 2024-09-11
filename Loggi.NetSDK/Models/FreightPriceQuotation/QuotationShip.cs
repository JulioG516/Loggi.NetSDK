using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Addresses;

namespace Loggi.NetSDK.Models.FreightPriceQuotation
{
    public class QuotationShip
    {
        [Required(ErrorMessage = "ShipFrom é necessario.")]
        [JsonPropertyName("shipFrom")]
        public IQuotationAddress? ShipFrom { get; set; }
    }
}