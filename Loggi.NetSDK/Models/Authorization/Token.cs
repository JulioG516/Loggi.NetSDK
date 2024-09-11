using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Authorization
{
    /// <summary>
    /// Solicitação e atualização de token.
    /// O campo idToken deve ser informado no Header Authorization de cada requisição à API de Shipments.
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Token de autenticação. Deve ser informado no campo Auhtorization de cada endpoint da API de Shipment.
        /// </summary>
        [JsonPropertyName("idToken")]
        public string IdToken { get; set; }

        /// <summary>
        /// Tempo de expiração do token em segundos.
        /// </summary>
        [JsonPropertyName("expiresIn")]
        public string ExpiresIn { get; set; }


        /// <summary>
        /// Stores the calculated expiration time.
        /// </summary>
        private DateTime _expirationTime;

        /// <summary>
        /// Gets the expiration time.
        /// </summary>
        [JsonIgnore]
        public DateTime ExpirationTime => _expirationTime;

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (int.TryParse(ExpiresIn, out int expiresInSeconds))
            {
                _expirationTime = DateTime.Now.AddSeconds(expiresInSeconds);
            }
            else
            {
                throw new InvalidOperationException("Invalid ExpiresIn value");
            }
        }

        public bool TokenValid()
        {
            if (ExpirationTime > DateTime.Now)
                return true;

            return false;
        }
    }
}