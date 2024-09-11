using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Addresses
{
    public class CorreiosAddress
    {
        [Required(ErrorMessage = "Logradouro é necessario.")]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        [MinLength(0)]
        [MaxLength(8)]
        [JsonPropertyName("numero")]
        public string Numero { get; set; }

        [MinLength(0)]
        [MaxLength(128)]
        [JsonPropertyName("complemento")]
        public string Complemento { get; set; }

        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "CEP é necessario.")]
        [MinLength(8)]
        [MaxLength(8)]
        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Cidade é necessaria.")]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "UF é necessaria.")]
        [MinLength(2)]
        [MaxLength(2)]
        [JsonPropertyName("uf")]
        public string Uf { get; set; }
    }
}