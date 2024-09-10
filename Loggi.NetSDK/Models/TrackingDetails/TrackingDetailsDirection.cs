using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.TrackingDetails
{
    public class TrackingDetailsDirection
    {
        [JsonPropertyName("type")] public DirectionType Type { get; set; }
        [JsonPropertyName("reason")] public DirectionReason Reason { get; set; }
        [JsonPropertyName("returnAddress")] public TrackingAddress ReturnAddress { get; set; }
    }

    public class DirectionType
    {
        /// <summary>
        /// Código indicando o sentido do pacote.
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// Mensagem que identifica o sentido do pacote.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class DirectionReason
    {
        /// <summary>
        /// Código indicando a razão pela qual o pacote teve o sentido alterado.
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// Mensagem que descreve a razão pela qual o pacote teve o seu sentido alterado.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("returnAddress")] public TrackingAddress ReturnAddress { get; set; }
    }
}