using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Converters;
using Loggi.NetSDK.Models.Shipments.AddressTypes;

namespace Loggi.NetSDK.Models.Shipments
{
    /// <summary>
    /// Objeto que representa os dados do embarcador.
    /// </summary>
    public class ShipFrom
    {
        /// <summary>
        /// Nome do embarcador. Tamanho mínimo 1 caractere e tamanho máximo 128 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Name é necessario.")]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Telefone do embarcador. Caso não informado o código do país, será considerado 55 (Brasil). Tamanho máximo 16 caractere
        /// </summary>
        [MinLength(0)]
        [MaxLength(16)]
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "FederalTaxId é necessario.")]
        [MinLength(11)]
        [MaxLength(14)]
        [JsonPropertyName("federalTaxId")]
        public string FederalTaxId { get; set; }


        [JsonPropertyName("address")]
        [JsonConverter(typeof(AddressTypeConverter))]
        public IAddressType Address { get; set; }
    }
}