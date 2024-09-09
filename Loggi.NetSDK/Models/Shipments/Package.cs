using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Enums;

namespace Loggi.NetSDK.Models.Shipments
{
    public class Package
    {
        /// <summary>
        /// Código de rastreio de um envio informado pelo cliente. Caso não seja informado,
        /// a Loggi irá gerar um valor para este campo. Tamanho mínimo 1 caractere e Tamanho máximo
        /// 100 caractere.
        /// </summary>
        [MinLength(1)]
        [MaxLength(100)]
        [JsonPropertyName("trackingCode")]
        public string TrackingCode { get; set; }

        /// <summary>
        /// Conteúdo do código de barras informado pelo cliente. Caso não seja informado,
        /// a Loggi irá gerar um valor para este campo.
        /// Tamanho mínimo 1 caractere e Tamanho máximo 255 caracteres.
        /// </summary>
        [MinLength(1)]
        [MaxLength(255)]
        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }

        /// <summary>
        /// Tipos de frete do pacote. Default em <see cref="FreightTypes.FreightTypeEconomic"/>
        /// </summary>
        [Required(ErrorMessage = "FreightType é necessario.")]
        [JsonPropertyName("freightType")]
        public string FreightType { get; set; } = FreightTypes.FreightTypeEconomic;

        /// <summary>
        /// Peso do pacote em gramas. Valor máximo 30000.
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

        [Required(ErrorMessage = "WidthCm é necessario.")]
        [Range(0, 100)]
        [JsonPropertyName("widthCm")]
        public int WidthCm { get; set; }

        [Required(ErrorMessage = "HeightCm é necessario.")]
        [Range(0, 100)]
        [JsonPropertyName("heightCm")]
        public int HeightCm { get; set; }

        [JsonPropertyName("documentTypes")] public List<IDocumentType> DocumentTypes { get; set; }
    }
}