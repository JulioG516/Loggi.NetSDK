using System.Collections.Generic;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Enums;

namespace Loggi.NetSDK.Models.Labels
{
    /// <summary>
    /// Objeto que é usado para interagir com a Labels API -> Criar Etiqueta
    /// </summary>
    public class LabelRequest
    {
        /// <summary>
        /// Lista de Loggi Keys.
        /// </summary>
        [JsonPropertyName("loggiKeys")]
        public List<string> LoggiKeys { get; set; }

        /// <summary>
        /// Formato do arquivo gerado que contém a etiqueta. Nesta versão é possível apenas gerar no formato PDF
        /// </summary>
        [JsonPropertyName("format")]
        public string Format { get; set; } = "LABEL_FORMAT_PDF";

        /// <summary>
        /// Tamanho da página de um label.
        /// </summary>
        [JsonPropertyName("layout")]
        public string Layout { get; set; } = LabelLayouts.LayoutA4;

        /// <summary>
        /// Tipo de retorno do label gerado.k
        /// Tipo de retorno do label gerado.k
        /// </summary>
        [JsonPropertyName("responseType")]
        public string ResponseType { get; set; } = LabelResponseTypes.Base64;
    }
}