﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Converters;
using Loggi.NetSDK.Models.Enums;
using Loggi.NetSDK.Models.Shipments.DocumentTypes;

namespace Loggi.NetSDK.Models.Shipments
{
    /// <summary>
    /// Pacote associado ao envio. A soma das medidas (altura, largura e comprimento) do pacote não podem passar de 200 cm.
    /// Utilizado no <see cref="Shipment"/>
    /// </summary>
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
        /// Tipos de frete do pacote. Default em <see cref="FreightTypes.Economic"/>
        /// </summary>
        [Required(ErrorMessage = "FreightType é necessario.")]
        [JsonPropertyName("freightType")]
        public string FreightType { get; set; } = FreightTypes.Economic;

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
        /// Tipos de documentos associados ao pacote.
        /// </summary>
        [JsonPropertyName("documentTypes")]
        [JsonConverter(typeof(DocumentTypeListConverter))]
        public List<IDocumentType> DocumentTypes { get; set; }

        /// <summary>
        /// Valor que identifica se o pacote está embalado. Por padrão, o pacote é considerado embalado (true).
        /// </summary>
        [JsonPropertyName("packaged")]
        public bool Packaged { get; set; } = true;

        /// <summary>
        /// Valor que identifica se o pacote está etiquetado. Por padrão, o pacote é considerado etiquetado (true).
        /// </summary>
        [JsonPropertyName("labelled")] public bool Labelled { get; set; } = true;

        /// <summary>
        /// Valor enviado pelo cliente para identificar um pacote dentro de um Shipment. Este valor será retornado
        ///na resposta. Tamanho máximo 100.
        /// </summary>
        [MinLength(0)]
        [MaxLength(100)]
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
    }
}