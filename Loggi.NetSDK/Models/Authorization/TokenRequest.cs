using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Authorization
{
    /// <summary>
    /// Objeto usado para obter o token da Loggi pela API.
    /// </summary>
    internal class TokenRequest
    {
        /// <summary>
        /// Id do cliente cadastrado na Loggi.
        /// </summary>
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Chave secreta gerada pela Loggi.
        /// </summary>
        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }
    }
}