using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments.AddressTypes
{
    /// <summary>
    /// Objeto que encapsula os possiveis enderecos que podem ser devolvidos pela Loggi na api de Shipment.
    /// </summary>
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