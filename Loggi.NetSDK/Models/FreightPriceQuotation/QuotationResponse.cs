using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.FreightPriceQuotation
{
    /// <summary>
    /// Resposta da Loggi ao Enviar uma request de FreightPriceQuotation.
    /// </summary>
    public class QuotationResponse
    {
        /// <summary>
        /// Objeto que representa a cotação de cada pacote.
        /// </summary>
        [JsonPropertyName("quotations")] public List<LoggiQuotation> Quotations { get; set; }
    }
}