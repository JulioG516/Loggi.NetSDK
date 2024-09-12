using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments.NifTypes
{
    /// <summary>
    /// Objeto que encapsula os tipos de dados Fiscais, sendo este o internacional.
    /// </summary>
    public class InternationalNifType : INifType
    {
        /// <summary>
        /// Objeto contendo informações de dados fiscais internacional.
        /// </summary>
        [JsonPropertyName("international")]
        public InternationalNif International { get; set; }
    }

    /// <summary>
    /// Implementação dos tipos de dados Fiscais, sendo este o internacional.
    /// </summary>
    public class InternationalNif
    {
        /// <summary>
        /// Número de identificação fiscal internacional.
        /// </summary>
        [Required(ErrorMessage = "Number é necessario.")]
        [MinLength(1)]
        [MaxLength(20)]
        [JsonPropertyName("number")]
        public string Number { get; set; }
    }
}