using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Tracking
{
    public class TrackingDeliveryInformation
    {
        /// <summary>
        /// Nome de quem recebeu o pacote no momento de sua entrega. Não necessariamente é igual ao nome do destinatário.
        /// </summary>
        [JsonPropertyName("receiverName")]
        public string ReceiverName { get; set; }

        /// <summary>
        /// Número do documento identificador de quem recebeu o pacote no momento de sua entrega.
        /// </summary>
        [JsonPropertyName("receiverDocument")]
        public string ReceiverDocument { get; set; }

        /// <summary>
        /// Descrição detalhada do local onde o pacote foi entregue.
        /// </summary>
        [JsonPropertyName("locationDescription")]
        public string LocationDescription { get; set; }

        [JsonPropertyName("links")] public List<Links> Links { get; set; }
    }
}