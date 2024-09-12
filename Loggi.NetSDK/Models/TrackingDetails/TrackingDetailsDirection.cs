using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.TrackingDetails
{
    /// <summary>
    /// Objeto que contém informaçoes do sentido do pacote.
    /// </summary>
    public class TrackingDetailsDirection
    {
        /// <summary>
        /// Objeto que contém informações do tipo de sentido do pacote.
        /// </summary>
        [JsonPropertyName("type")]
        public DirectionType Type { get; set; }

        /// <summary>
        /// Objeto que contém informações da razão de sentido do pacote.
        /// </summary>
        [JsonPropertyName("reason")]
        public DirectionReason Reason { get; set; }

        /// <summary>
        ///  Objeto contendo informações de um endereço
        /// </summary>
        [JsonPropertyName("returnAddress")]
        public TrackingAddress ReturnAddress { get; set; }
    }

    /// <summary>
    /// Objeto que contém informações do tipo de sentido do pacote.
    /// </summary>
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

    /// <summary>
    /// Objeto que contém informações da razão de sentido do pacote.
    /// </summary>
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

        /// <summary>
        /// Endereço de devolução relacionado ao pacote. Preenchido somente se o pacote está na direção de devolução.
        /// </summary>
        [JsonPropertyName("returnAddress")]
        public TrackingAddress ReturnAddress { get; set; }
    }
}