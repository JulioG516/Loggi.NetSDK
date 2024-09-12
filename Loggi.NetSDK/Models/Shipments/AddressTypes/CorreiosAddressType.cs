using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Addresses;

namespace Loggi.NetSDK.Models.Shipments.AddressTypes
{
    /// <summary>
    /// Objeto que encapsula o objeto <see cref="CorreiosAddress"/> para ser enviado ou devolvido para a Loggi.
    /// </summary>
    public class CorreiosAddressType : AddressType
    {
        /// <summary>
        /// Objeto que contém informações detalhadas do endereço compatível com o formato da API dos Correios. <see cref="Loggi.NetSDK.Models.Addresses.CorreiosAddress"/>
        /// </summary>
        [JsonPropertyName("correiosAddress")]
        public CorreiosAddress CorreiosAddress { get; set; }
    }
}