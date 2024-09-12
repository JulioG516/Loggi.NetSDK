using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments.DocumentTypes
{
    /// <summary>
    /// Objeto que implementa um <see cref="DocumentType"/> encapsulando um objeto de Dir
    /// para ser usado na Loggi.
    /// </summary>
    public class DirDocumentType : DocumentType
    {
        /// <summary>
        /// Objeto que representa uma declaração DIR
        /// </summary>
        [JsonPropertyName("dir")]
        public Dir Dir { get; set; }
    }

    /// <summary>
    /// Objeto que representa uma declaração DIR
    /// </summary>
    public class Dir
    {
        /// <summary>
        /// Air Way Bill da declaração de importação de remessas. Tamanho de 11 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Awb é necessario.")]
        [MinLength(11)]
        [MaxLength(11)]
        [JsonPropertyName("awb")]
        public string Awb { get; set; }

        /// <summary>
        /// Número da declaração de importação de remessas. Tamanho de 12 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Number é necessario.")]
        [MinLength(12)]
        [MaxLength(12)]
        [JsonPropertyName("number")]
        public string Number { get; set; }

        /// <summary>
        /// Data de emissão da declaração de importação de remessas. Formato yyyy-MM-dd'T'HH:mm:ss
        /// </summary>
        [Required(ErrorMessage = "EmissionDate é necessario.")]
        [MinLength(12)]
        [MaxLength(24)]
        [JsonPropertyName("emissionDate")]
        public string EmissionDate { get; set; }

        /// <summary>
        /// Valor total da declaração de conteúdo. Tamanho mínimo 1 caractere e Tamanho máximo 8 caracteres.
        /// </summary>
        [Required(ErrorMessage = "TotalValue é necessario.")]
        [MinLength(1)]
        [MaxLength(8)]
        [JsonPropertyName("totalValue")]
        public string TotalValue { get; set; }

        /// <summary>
        /// Moeda do valor total. Tamanho de 3 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Currency é necessario.")]
        [MinLength(3)]
        [MaxLength(3)]
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Modalidade da remessa da declaração de importação de remessas.
        /// </summary>
        [JsonPropertyName("shippingMethod")]
        public string ShippingMethod { get; set; } = "SHIPPING_METHOD_EXPRESS";

        /// <summary>
        /// Valor da taxa de importação da declaração de conteúdo. Tamanho mínimo 1 caractere e Tamanho máximo 8 caracteres.
        /// </summary>
        [MinLength(1)]
        [MaxLength(8)]
        [JsonPropertyName("importTaxValue")]
        public string ImportTaxValue { get; set; }

        /// <summary>
        /// Lista de items na declaração tipo DIR.
        /// </summary>
        [JsonPropertyName("items")]
        public List<DirItem> Items { get; set; }

        /// <summary>
        /// Objeto que representa um remetente nacional ou internacional.
        /// </summary>
        [JsonPropertyName("shipper")]
        public Shipper Shipper { get; set; }

        /// <summary>
        /// Objeto que representa o tomador de serviço.
        /// </summary>
        [JsonPropertyName("taker")]
        public Taker Taker { get; set; }
    }

    /// <summary>
    /// Objeto item para ser utilizado dentro da declaração do tipo <see cref="Dir"/>
    /// </summary>
    public class DirItem
    {
        /// <summary>
        /// Descrição de um dos itens na Declaração de importação de remessas
        /// </summary>
        [MaxLength(100)]
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}