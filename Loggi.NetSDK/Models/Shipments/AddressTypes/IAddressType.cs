using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments.AddressTypes
{
    public interface IAddressType
    {
        [Required]
        [JsonPropertyName("instrunctions")]
        public string? Instrunctions { get; set; }
    }

    public class AddressType : IAddressType
    {
        [Required]
        [JsonPropertyName("instrunctions")]
        public string? Instrunctions { get; set; }
    }
}