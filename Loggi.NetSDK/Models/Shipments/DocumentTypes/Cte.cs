using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments.DocumentTypes
{
    public class Cte
    {
        [Required(ErrorMessage = "Key é necessario.")]
        [MinLength(44)]
        [MaxLength(44)]
        [JsonPropertyName("key")]
        public string Key { get; set; }
    }
}