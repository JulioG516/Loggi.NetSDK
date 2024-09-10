using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments.DocumentTypes
{
    public class ContentDeclarationDocumentType : DocumentType
    {
        [JsonPropertyName("contentDeclaration")]
        public ContentDeclaration ContentDeclaration { get; set; }
    }

    public class ContentDeclaration
    {
        /// <summary>
        /// Valor total da declaração de conteúdo. Tamanho mínimo 1 caractere e Tamanho máximo 8 caracteres.
        /// </summary>
        [Required(ErrorMessage = "TotalValue é necessario.")]
        [MinLength(1)]
        [MaxLength(8)]
        [JsonPropertyName("totalValue")]
        public string TotalValue { get; set; }

        /// <summary>
        /// Descrição dos itens da declaração de conteúdo. Tamanho mínimo 1 caractere e Tamanho máximo 100 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Description é necessario.")]
        [MinLength(1)]
        [MaxLength(100)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("items")] public List<ContentDeclarationItem> Items { get; set; }

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

    public class ContentDeclarationItem
    {
        /// <summary>
        /// Descrição de um dos itens na Declaração de conteúdo
        /// </summary>
        [MaxLength(100)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Quantidade de ocorrência desse item na declaração de conteúdo
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Valor unitário desse item na declaração de conteúdo
        /// </summary>
        [Range(0, 8)]
        [JsonPropertyName("unitaryValue")]
        public int UnitaryValue { get; set; }

        [Range(0, 30000)]
        [JsonPropertyName("unitaryWeightG")]
        public int UnitaryWeightG { get; set; }
    }
}