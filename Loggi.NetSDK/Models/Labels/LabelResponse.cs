using System.Collections.Generic;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Converters;

namespace Loggi.NetSDK.Models.Labels
{
    /// <summary>
    /// O campo será retornado dentro da propriedade Success quando informado o valor LABEL_RESPONSE_TYPE_BASE_64 para o campo responseType
    /// e o campo url será retornado dentro da propriedade Success quando informado o valor LABEL_RESPONSE_TYPE_URL para o campo responseType.
    /// </summary>
    public class LabelResponse
    {
        /// <summary>
        /// Arquivo binário em BASE64 ou URL com as etiquetas geradas com sucesso.
        /// </summary>
        [JsonPropertyName("success")]
        [JsonConverter(typeof(LabelResponseTypeConverter))]
        public ILabelResponseType Success { get; set; }


        [JsonPropertyName("failure")] public List<FailureLabel> Failure { get; set; }
    }

    public class FailureLabel
    {
        /// <summary>
        /// Lista de loggi keys dos pacotes que não puderam ter as etiquetas geradas e seus respectivos erros.
        /// </summary>
        [JsonPropertyName("loggiKey")]
        public string LoggiKey { get; set; }

        /// <summary>
        /// Detalhamento do erro na geração da etiqueta.
        /// </summary>
        [JsonPropertyName("status")]
        public ErrorResponse Status { get; set; }
    }
}