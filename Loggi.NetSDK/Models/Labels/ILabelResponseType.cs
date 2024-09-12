using System;
using System.Buffers.Text;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Labels
{
    /// <summary>
    /// Encapsula os tipos possiveis retornos de LabelResponseType sendo em Base64 ou URL.
    /// </summary>
    public interface ILabelResponseType
    {
        /// <summary>
        /// Horário de geração da etiqueta em formato UTC.
        /// </summary>
        [JsonPropertyName("createdTime")] public DateTime? CreatedTime { get; set; }
    }

    /// <summary>
    /// Encapsula os tipos possiveis retornos de LabelResponseType sendo em Base64 ou URL.
    /// </summary>
    public class LabelResponseType : ILabelResponseType
    {
        /// <inheritdoc />
        [JsonPropertyName("createdTime")] public DateTime? CreatedTime { get; set; }
    }


    /// <summary>
    /// Este dado é retornando quando informado o valor <see cref="Base64"/> para o campo ResponseType no <see cref="LabelRequest"/>
    /// </summary>
    public class LabelResponseBase64 : LabelResponseType
    {
        /// <summary>
        /// Bytes do arquivo codificado em base 64. Este dado é retornado quando informado o valor LABEL_RESPONSE_TYPE_BASE_64 para o campo responseType.
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    /// <summary>
    /// Este dado é retornando quando informado o valor <see cref="Url"/> para o campo ResponseType no <see cref="LabelRequest"/>
    /// </summary>
    public class LabelResponseUrl : LabelResponseType
    {
        /// <summary>
        /// Link para download da etiqueta gerada. Este dado é retornando quando informado o valor LABEL_RESPONSE_TYPE_URL para o campo responseType.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}