using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments.NifTypes
{
    public class InternationalNifType : INifType
    {
        [JsonPropertyName("international")] public InternationalNif International { get; set; }
    }

    public class InternationalNif
    {
        [Required(ErrorMessage = "Number é necessario.")]
        [MinLength(1)]
        [MaxLength(20)]
        [JsonPropertyName("number")]
        public string Number { get; set; }
    }
}