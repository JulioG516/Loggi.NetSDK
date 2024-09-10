using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments.NifTypes
{
    /// <summary>
    /// Contém os dados fiscais nacional.
    /// </summary>
    public class NationalNifType : INifType
    {
        [JsonPropertyName("national")] public NationalNif National { get; set; }
    }

    public class NationalNif
    {
        /// <summary>
        /// CPF (com 11 dígitos) ou CNPJ (com 14 dígitos).
        /// </summary>
        [Required(ErrorMessage = "FederalTaxId é necessario.")]
        [MinLength(1)]
        [MaxLength(14)]
        [JsonPropertyName("federalTaxId")]
        public string FederalTaxId { get; set; }

        /// <summary>
        /// Inscrição Estadual.
        /// </summary>
        [MinLength(0)]
        [MaxLength(16)]
        [JsonPropertyName("stateTaxId")]
        public string StateTaxId { get; set; }
    }
}