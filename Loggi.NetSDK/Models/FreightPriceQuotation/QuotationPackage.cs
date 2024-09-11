using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.TrackingDetails;

namespace Loggi.NetSDK.Models.FreightPriceQuotation
{
    public class QuotationPackage
    {
        [Required(ErrorMessage = "WeightG é necessario.")]
        [Range(0, 30000)]
        [JsonPropertyName("weightG")]
        public int WeightG { get; set; }

        [Required(ErrorMessage = "LengthCm é necessario.")]
        [Range(0, 100)]
        [JsonPropertyName("lengthCm")]
        public int LengthCm { get; set; }

        [Required(ErrorMessage = "WidthCm é necessario.")]
        [Range(0, 100)]
        [JsonPropertyName("widthCm")]
        public int WidthCm { get; set; }

        [Required(ErrorMessage = "HeightCm é necessario.")]
        [Range(0, 100)]
        [JsonPropertyName("heightCm")]
        public int HeightCm { get; set; }

        [Required(ErrorMessage = "GoodsValue é necessario.")]
        [JsonPropertyName("goodsValue")]
        public PricingAmount GoodsValue { get; set; }
    }
}