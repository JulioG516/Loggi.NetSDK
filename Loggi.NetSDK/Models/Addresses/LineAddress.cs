using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Addresses
{
    public class LineAddress
    {
        [Required(ErrorMessage = "AddressLine1 é necessario.")]
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("addressLine1")]
        public string AddressLine1 { get; set; }

        [MinLength(0)]
        [MaxLength(256)]
        [JsonPropertyName("addressLine2")]
        public string AddressLine2 { get; set; }


        [Required(ErrorMessage = "Postal Code é necessario.")]
        [MinLength(8)]
        [MaxLength(8)]
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "City é necessario.")]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("city")]
        public string City { get; set; }

        [Required(ErrorMessage = "State é necessario.")]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("state")]
        public string State { get; set; }

        [MinLength(1)]
        [MaxLength(100)]
        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}