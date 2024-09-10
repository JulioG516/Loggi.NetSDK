using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Converters;
using Loggi.NetSDK.Models.Shipments.AddressTypes;
using Loggi.NetSDK.Models.Shipments.NifTypes;

namespace Loggi.NetSDK.Models.Shipments
{
    /// <summary>
    /// Objeto que representa um remetente nacional ou internacional.
    /// </summary>
    public class Shipper
    {
        [Required(ErrorMessage = "Name é necessario.")]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Objeto que representa os dados ficais de uma pessoa física ou jurídica podendo ser nacional ou internacional.
        /// </summary>
        [JsonConverter(typeof(NifTypeConverter))]
        [JsonPropertyName("nifType")]
        public INifType NifType { get; set; }

        [Required(ErrorMessage = "Address é necessario.")]
        [JsonConverter(typeof(AddressTypeConverter))]
        [JsonPropertyName("address")]
        public IAddressType Address { get; set; }
    }
}