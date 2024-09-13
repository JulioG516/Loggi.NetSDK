using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Shipments.AddressTypes;

namespace Loggi.NetSDK.Models.PickupTime
{
    /// <summary>
    /// Objeto para requisitar dados da API Loggi Janela de coleta ->  PickupTimeSlotAPI.
    /// </summary>
    public class JanelaColetaRequest
    {
        /// <summary>
        /// Objeto que representa um endereço nacional em formato dos Correios ou um endereço internacional. Os objetos <see cref="CorreiosAddressType"/> e <see cref="LineAddressType"/> são mutuamente exclusivos.
        /// </summary>
        [JsonPropertyName("address")] public IAddressType Address { get; set; }
    }
}