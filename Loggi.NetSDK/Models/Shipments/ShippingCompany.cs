using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments
{
    public class ShippingCompany
    {
        [Required(ErrorMessage = "Name é necessario.")]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "FederalTaxId é necessario.")]
        [JsonPropertyName("federalTaxId")]
        public string FederalTaxId { get; set; }
    }
}