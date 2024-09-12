using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Addresses
{
    /// <summary>
    /// Objeto que representa um endereço com padrão internacional.
    /// </summary>
    public class LineAddress
    {
        /// <summary>
        /// Primeira linha que contempla os dados do endereço. Tamanho mínimo 1 caractere e Tamanho máximo 256 caracteres.
        /// </summary>
        [Required(ErrorMessage = "AddressLine1 é necessario.")]
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("addressLine1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Segunda linha que complementa os dados de endereço. Tamanho máximo 256 caracteres. descritos em addressLine1
        /// </summary>
        [MinLength(0)]
        [MaxLength(256)]
        [JsonPropertyName("addressLine2")]
        public string AddressLine2 { get; set; }
        
        /// <summary>
        /// Código postal do endereço. Tamanho mínimo 8 caractere e Tamanho máximo 8 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Postal Code é necessario.")]
        [MinLength(8)]
        [MaxLength(8)]
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Cidade do endereço. Tamanho mínimo 1 caractere e Tamanho máximo 32 caracteres.
        /// </summary>
        [Required(ErrorMessage = "City é necessario.")]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// Estado do Endereço. Tamanho mínimo 1 caractere e Tamanho máximo 32 caracteres.
        /// </summary>
        [Required(ErrorMessage = "State é necessario.")]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// País do endereço. Tamanho mínimo 1 caractere e Tamanho máximo 100 caracteres.
        /// </summary>
        [MinLength(1)]
        [MaxLength(100)]
        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}