using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Tracking
{
    public class Links
    {
        /// <summary>
        /// Identificador interno para definir a informação fornecida a partir do arquivo.
        /// </summary>
        [JsonPropertyName("rel")]
        public string Rel { get; set; }


        /// <summary>
        /// URL com o arquivo referente à descrição da informação fornecida por quem recebeu.
        /// </summary>
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}