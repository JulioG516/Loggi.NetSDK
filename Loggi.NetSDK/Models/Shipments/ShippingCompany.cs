using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments
{
    /// <summary>
    /// Identifica a transportadora responsável pelo pacote no fluxo de operação universal.
    /// </summary>
    public class ShippingCompany
    {
        /// <summary>
        /// Nome da empresa. Tamanho mínimo 1 caractere e tamanho máximo 128 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Name é necessario.")]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// CPF (com 11 dígitos) ou CNPJ (com 14 dígitos) da empresa.
        /// </summary>
        [Required(ErrorMessage = "FederalTaxId é necessario.")]
        [JsonPropertyName("federalTaxId")]
        public string FederalTaxId { get; set; }
    }
}