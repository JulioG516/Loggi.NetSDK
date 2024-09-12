using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Converters;

namespace Loggi.NetSDK.Models.FreightPriceQuotation
{
    internal interface IQuotation
    {
    }

    /// <summary>
    /// Classe que implementa Quotation usado pela Loggi na API FreightPriceQuotation para obter cotações de valores.
    /// </summary>
    public class Quotation : IQuotation
    {
        /// <summary>
        /// Objeto que representa um endereço nacional em formato dos Correios ou uma
        /// representação alternativa de endereços.
        /// Os objetos correios, lines e widget são mutuamente exclusivos
        /// </summary>
        [Required(ErrorMessage = "ShipFrom é necessario.")]
        [JsonPropertyName("shipFrom")]
        [JsonConverter(typeof(QuotationAddressConverter))]
        public IQuotationAddress ShipFrom { get; set; }

        /// <summary>
        /// Objeto que representa um endereço nacional em formato dos Correios ou uma
        /// representação alternativa de endereços.
        /// Os objetos correios, lines e widget são mutuamente exclusivos.
        /// </summary>
        [Required(ErrorMessage = "ShipTo é necessario.")]
        [JsonPropertyName("shipTo")]
        [JsonConverter(typeof(QuotationAddressConverter))]
        public IQuotationAddress ShipTo { get; set; }

        /// <summary>
        /// Lista de pacotes associado à cotação de frete.
        /// </summary>
        [JsonPropertyName("packages")] public List<QuotationPackage>? Packages { get; set; }
    }

    /// <summary>
    /// Objeto que encapsula a opção de Quotation da Loggi com PickupTypes.
    /// </summary>
    public class QuotationPickupTypes : Quotation
    {
        /// <summary>
        /// Lista de tipos de coleta.
        /// </summary>
        [JsonPropertyName("pickupTypes")] public List<string>? PickupTypes { get; set; }
    }

    /// <summary>
    /// Objeto que encapsula a opção de Quotation da Loggi com ExternalServicesId (SISUs).
    /// </summary>
    public class QuotationExternalServices : Quotation
    {
        /// <summary>
        /// Lista de identificadores externos do serviço.
        /// </summary>
        [JsonPropertyName("externalServiceIds")]
        public List<string>? ExternalServiceIds { get; set; }
    }
}