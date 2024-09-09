using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments
{
    public interface IAddressType
    {
        [Required]
        [JsonPropertyName("instrunctions")]
        public string? Instrunctions { get; set; }
    }

    public class AddressType : IAddressType
    {
        public string? Instrunctions { get; set; }
    }

    public class CorreiosAddressType : AddressType
    {
        [JsonPropertyName("correiosAddress")] public CorreiosAddress CorreiosAddress { get; set; }
    }

    public class LineAddressType : AddressType
    {
        [JsonPropertyName("lineAddress")] public LineAddress LineAddress { get; set; }
    }

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

    public class LineAddress
    {
        [Required(ErrorMessage = "AddressLine1 é necessario.")]
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("addressLine1")]
        public string AddressLine1 { get; set; }

        [MinLength(0)]
        [MaxLength(256)]
        [JsonPropertyName("addressLine2")]
        public string AddressLine2 { get; set; }


        [Required(ErrorMessage = "Postal Code é necessario.")]
        [MinLength(8)]
        [MaxLength(8)]
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "City é necessario.")]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("city")]
        public string City { get; set; }

        [Required(ErrorMessage = "State é necessario.")]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("state")]
        public string State { get; set; }

        [MinLength(1)]
        [MaxLength(100)]
        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}