using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Addresses
{
    /// <summary>
    /// Objeto que contém informações detalhadas do endereço compatível com o formato da API dos Correios.
    /// </summary>
    public class CorreiosAddress
    {
        /// <summary>
        /// Nome da rua. Tamanho mínimo 1 caractere e Tamanho máximo 128 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Logradouro é necessario.")]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        /// <summary>
        /// Número do endereço. Tamanho máximo 8 caracteres. Caso não possua número, informar com os valores S/N ou s/n
        /// </summary>
        [MinLength(0)]
        [MaxLength(8)]
        [JsonPropertyName("numero")]
        public string Numero { get; set; }

        /// <summary>
        /// Informações adicionais para facilitar a localização. Tamanho máximo 128 caracteres.
        /// </summary>
        [MinLength(0)]
        [MaxLength(128)]
        [JsonPropertyName("complemento")]
        public string Complemento { get; set; }

        /// <summary>
        /// Para endereços de Brasília, procure mais informações nos Correios. Em casos que seja usado regiões adminstrativas e se existir bairro, informe entre parentêses. Tamanho mínimo 1 caractere e Tamanho máximo 64 caracteres.
        /// </summary>
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        /// <summary>
        /// CEP do endereço com 8 dígitos.
        /// </summary>
        [Required(ErrorMessage = "CEP é necessario.")]
        [MinLength(8)]
        [MaxLength(8)]
        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        /// <summary>
        /// Cidade do endereço. Tamanho mínimo 1 caractere e Tamanho máximo 32 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Cidade é necessaria.")]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("cidade")]
        public string Cidade { get; set; }

        /// <summary>
        /// Unidade federativa com dois caracteres.
        /// </summary>
        [Required(ErrorMessage = "UF é necessaria.")]
        [MinLength(2)]
        [MaxLength(2)]
        [JsonPropertyName("uf")]
        public string Uf { get; set; }
    }
}