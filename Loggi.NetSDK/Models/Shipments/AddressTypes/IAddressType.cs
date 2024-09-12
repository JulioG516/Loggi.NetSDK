using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments.AddressTypes
{
    /// <summary>
    /// Objeto que encapsula os possiveis enderecos que podem ser enviados devolvidos pela Loggi na api de Shipment.
    /// </summary>
    public interface IAddressType
    {
        /// <summary>
        /// Mais detalhes sobre a localização do endereço. Tamanho mínimo 1 caractere e tamanho máximo 300 caracteres.
        /// </summary>
        [Required]
        [JsonPropertyName("instrunctions")]
        public string? Instrunctions { get; set; }
    }


    /// <inheritdoc />
    public class AddressType : IAddressType
    {
        /// <inheritdoc />
        [Required]
        [JsonPropertyName("instrunctions")]
        public string? Instrunctions { get; set; }
    }
}