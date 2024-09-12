using System.Text.Json.Serialization;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Loggi.NetSDK.Models.FreightPriceQuotation
{
    /// <summary>
    /// Objeto que representa a cotação devolvida pela Loggi ao utilizar a API Freight Price Quotation
    /// </summary>
    public class LoggiQuotation
    {
        /// <summary>
        /// Objeto que contém os valores gerado pela Loggi.
        /// </summary>
        [JsonPropertyName("price")]
        public QuotationPrice Price { get; set; }

        /// <summary>
        /// Tempo de entrega dentro do prazo estipulado em dias.
        /// </summary>
        [JsonPropertyName("sloInDays")]
        public int SloInDays { get; set; }

        /// <summary>
        /// Tipos de entregas disponíveis.
        /// </summary>
        [JsonPropertyName("freightType")]
        public string FreightType { get; set; }

        /// <summary>
        /// Label do tipo de entrega. Poderá ser usado como output na UI.
        /// </summary>
        [JsonPropertyName("freightTypeLabel")]
        public string FreightTypeLabel { get; set; }

        /// <summary>
        /// Tipos de coletas disponíveis.
        /// </summary>
        [JsonPropertyName("pickup_type")]
        public string PickupType { get; set; }

        /// <summary>
        /// Identificador externo do serviço.
        /// </summary>
        [JsonPropertyName("externalServiceIds")]
        public string ExternalServiceIds { get; set; }
    }
}