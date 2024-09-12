using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Addresses;

namespace Loggi.NetSDK.Models.Shipments.AddressTypes
{
    /// <summary>
    /// Objeto que encapsula o objeto <see cref="LineAddress"/> para ser enviado ou devolvido para a Loggi.
    /// </summary>
    public class LineAddressType : AddressType
    {
        /// <summary>
        /// Objeto que representa um endereço com padrão internacional. <see cref="Loggi.NetSDK.Models.Addresses.LineAddress"/>
        /// </summary>
        [JsonPropertyName("lineAddress")]
        public LineAddress LineAddress { get; set; }
    }
}