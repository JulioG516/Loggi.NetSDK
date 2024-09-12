using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Package
{
    /// <summary>
    /// Resposta da API do PackageCancel
    /// </summary>
    public class PackageCancelResponse
    {
        /// <summary>
        /// Mensagem com a constante que identifica casos em que o cancelamento não pode ser confirmado.
        /// </summary>
        [JsonPropertyName("warning_type")]
        public string WarningType { get; set; }

        /// <summary>
        /// Mensagem de alerta para casos em que o cancelamento não pode ser confirmado.
        /// </summary>
        [JsonPropertyName("warning_message")]
        public string WarningMessage { get; set; }
    }
}