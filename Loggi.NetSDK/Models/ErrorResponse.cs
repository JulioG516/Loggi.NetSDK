using System.Collections.Generic;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Converters;
using Loggi.NetSDK.Models.Enums;

namespace Loggi.NetSDK.Models
{
        public class ErrorResponse
        {
            /// <summary>
            /// Código numérico referente à falha. no SDK representado por <see cref="Enums.EnumErrorCode"/>
            /// </summary>
            [JsonPropertyName("code")]
            [JsonConverter(typeof(ErrorCodeConverter))]
            public EnumErrorCode Code { get; set; }

            /// <summary>
            /// Texto pequeno informativo sobre a falha
            /// </summary>
            [JsonPropertyName("message")]
            public string Message { get; set; }

            /// <summary>
            /// Detalhes sobre a falha. Nesta versão da API ainda não está sendo retornado, mas deve ser considerado um array de objetos de tipos distintos.k
            /// </summary>
            [JsonPropertyName("details")]
            public List<object> Details { get; set; }
        }
}