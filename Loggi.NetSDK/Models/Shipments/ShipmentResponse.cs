using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments
{
    /// <summary>
    /// Resposta da Loggi ao utilizar a api de criar shipments.
    /// Encapsula uma lista de objetos <see cref="ResponsePackage"/>
    /// </summary>
    public class ShipmentResponse
    {
        /// <summary>
        /// Lista de <see cref="ResponsePackage"/> de um Shipment que serão processados.
        /// </summary>
        [JsonPropertyName("packages")]
        public List<ResponsePackage> Packages { get; set; }
    }

    /// <summary>
    /// Objeto da resposta da api de criar shipments.
    /// </summary>
    public class ResponsePackage
    {
        /// <summary>
        /// Código de rastreio de um envio informado pelo cliente. Caso não seja informado, a Loggi irá gerar um valor para este campo. Tamanho mínimo 1 caractere e Tamanho máximo 100 caracteres.
        /// </summary>
        [JsonPropertyName("trackingCode")]
        public string TrackingCode { get; set; }

        /// <summary>
        /// Conteúdo do código de barras informado pelo cliente. Caso não seja informado, a Loggi irá gerar um valor para este campo. Tamanho mínimo 1 caractere e Tamanho máximo 255 caracteres.
        /// </summary>
        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }

        /// <summary>
        /// Identificador único de um pacote gerado pela Loggi.
        /// </summary>
        [JsonPropertyName("loggiKey")]
        public string LoggiKey { get; set; }

        /// <summary>
        /// Valor enviado pelo cliente para identificar um pacote dentro de um Shipment. Este valor será retornado
        /// na resposta. Tamanho máximo 100.
        /// </summary>
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
    }
}