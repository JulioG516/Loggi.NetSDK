using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.TrackingDetails;

namespace Loggi.NetSDK.Models.FreightPriceQuotation
{
    /// <summary>
    /// Objeto pacote associado à cotação de frete. utilizado dentro do <see cref="Quotation"/>
    /// </summary>
    public class QuotationPackage
    {
        /// <summary>
        /// Peso do pacote em gramas. Valor máximo 30000
        /// </summary>
        [Required(ErrorMessage = "WeightG é necessario.")]
        [Range(0, 30000)]
        [JsonPropertyName("weightG")]
        public int WeightG { get; set; }

        /// <summary>
        /// Comprimento do pacote em centímetros. Valor máximo 100.
        /// </summary>
        [Required(ErrorMessage = "LengthCm é necessario.")]
        [Range(0, 100)]
        [JsonPropertyName("lengthCm")]
        public int LengthCm { get; set; }

        /// <summary>
        /// Largura do pacote em centrímetros. Valor máximo 100.
        /// </summary>
        [Required(ErrorMessage = "WidthCm é necessario.")]
        [Range(0, 100)]
        [JsonPropertyName("widthCm")]
        public int WidthCm { get; set; }

        /// <summary>
        /// Altura do pacote em centímetros. Valor máximo 100.
        /// </summary>
        [Required(ErrorMessage = "HeightCm é necessario.")]
        [Range(0, 100)]
        [JsonPropertyName("heightCm")]
        public int HeightCm { get; set; }

        /// <summary>
        /// Valor total de todos os produtos a serem transportados dentro de um pacote.
        /// Utilizado o objeto <see cref="PricingAmount"/>
        /// </summary>
        [Required(ErrorMessage = "GoodsValue é necessario.")]
        [JsonPropertyName("goodsValue")]
        public PricingAmount GoodsValue { get; set; }
    }
}