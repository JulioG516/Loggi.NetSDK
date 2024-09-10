using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Converters;
using Loggi.NetSDK.Models.Shipments.AddressTypes;
using Loggi.NetSDK.Models.Shipments.NifTypes;

namespace Loggi.NetSDK.Models.Shipments
{
    /// <summary>
    /// Objeto que representa o tomador de serviço.
    /// </summary>
    public class Taker
    {
        /// <summary>
        /// Nome do tomando de serviço.
        /// </summary>
        [Required(ErrorMessage = "1 é necessario.")]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Objeto que representa os dados ficais de uma pessoa física ou jurídica podendo ser nacional ou internacional.
        /// </summary>
        [Required(ErrorMessage = "NifType é necessario.")]
        [JsonConverter(typeof(NifTypeConverter))]
        [JsonPropertyName("nifType")]
        public INifType NifType { get; set; }

        /// <summary>
        /// Objeto que representa um endereço nacional em formato dos Correios ou um endereço internacional.
        /// Os objetos correiosAddress e lineAddress são mutuamente exclusivos.
        /// </summary>
        [Required(ErrorMessage = "Address é necessario.")]
        [JsonConverter(typeof(AddressTypeConverter))]
        [JsonPropertyName("address")]
        public IAddressType Address { get; set; }
    }
}