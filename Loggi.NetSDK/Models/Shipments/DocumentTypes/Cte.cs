using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments.DocumentTypes
{
    /// <summary>
    /// Objeto CTE contendo uma chave de identificação do Cte. Tamanho de 44 caracteres.
    /// </summary>
    public class Cte
    {
        /// <summary>
        /// Chave de identificação do Cte. Tamanho de 44 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Key é necessario.")]
        [MinLength(44)]
        [MaxLength(44)]
        [JsonPropertyName("key")]
        public string Key { get; set; }
    }
}