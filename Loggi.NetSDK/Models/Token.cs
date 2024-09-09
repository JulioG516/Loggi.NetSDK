using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models
{
    /// <summary>
    /// Solicitação e atualização de token.
    /// O campo idToken deve ser informado no Header Authorization de cada requisição à API de Shipments.
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Id do cliente cadastrado na Loggi.
        /// </summary>
        [JsonPropertyName("idToken")]
        public string IdToken { get; set; }

        /// <summary>
        /// Chave secreta gerada pela Loggi.
        /// </summary>
        [JsonPropertyName("expiresIn")]
        public string ExpiresIn { get; set; }
    }
}