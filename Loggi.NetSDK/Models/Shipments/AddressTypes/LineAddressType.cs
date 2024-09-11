using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Addresses;

namespace Loggi.NetSDK.Models.Shipments.AddressTypes
{
    /// <summary>
    /// Objeto que encapsula os possiveis enderecos que podem ser devolvidos pela Loggi na api de Shipment.
    /// </summary>
    public class LineAddressType : AddressType
    {
        [JsonPropertyName("lineAddress")] public LineAddress LineAddress { get; set; }
    }
}