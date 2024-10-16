﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Enums;

namespace Loggi.NetSDK.Models.Shipments.DocumentTypes
{
    /// <summary>
    /// Objeto que implementa um <see cref="DocumentType"/> encapsulando um objeto de Nota Fiscal
    /// para ser usado na Loggi.
    /// </summary>
    public class InvoiceDocumentType : DocumentType
    {
        /// <summary>
        /// Objeto que representa as características da Nota Fiscal de um pacote.
        /// </summary>
        [JsonPropertyName("invoice")]
        public Invoice Invoice { get; set; }
    }

    /// <summary>
    /// Objeto que representa as características da Nota Fiscal de um pacote.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Chave de identificação da Nota Fiscal. Tamanho de 44 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Key é necessario.")]
        [MinLength(44)]
        [MaxLength(44)]
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Série da Nota Fiscal. Tamanho mínimo 1 caractere e Tamanho máximo 3 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Series é necessario.")]
        [MinLength(1)]
        [MaxLength(3)]
        [JsonPropertyName("series")]
        public string Series { get; set; }

        /// <summary>
        /// Número da Nota Fiscal. Tamanho mínimo 1 caractere e Tamanho máximo 9 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Number é necessario.")]
        [MinLength(1)]
        [MaxLength(9)]
        [JsonPropertyName("number")]
        public string Number { get; set; }

        /// <summary>
        /// Valor total da Nota Fiscal. Tamanho mínimo 1 caractere e Tamanho máximo 8 caracteres.
        /// </summary>
        [Required(ErrorMessage = "TotalValue é necessario.")]
        [MinLength(1)]
        [MaxLength(8)]
        [JsonPropertyName("totalValue")]
        public string TotalValue { get; set; }

        /// <summary>
        /// Constante que representa se um pacote terá tributação de ICMS.
        /// </summary>
        [Required(ErrorMessage = "Icms é necessario.")]
        [JsonPropertyName("icms")]
        public string Icms { get; set; } = IcmsTypes.Taxed;

        /// <summary>
        /// Lista de items na Nota Fiscal.
        /// </summary>
        [JsonPropertyName("items")]
        public List<InvoiceItem> Items { get; set; }


        /// <summary>
        /// Objeto que representa um remetente nacional ou internacional.
        /// </summary>
        [JsonPropertyName("shipper")]
        public Shipper Shipper { get; set; }

        /// <summary>
        /// Objeto que representa o tomador de serviço.
        /// </summary>
        [JsonPropertyName("taker")] public Taker Taker { get; set; }
    }

    /// <summary>
    /// Objeto que representa as características da Nota Fiscal de um pacote.
    /// </summary>
    public class InvoiceItem
    {
        /// <summary>
        /// Descrição de um dos itens na Nota fiscal
        /// </summary>
        [MaxLength(100)]
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}