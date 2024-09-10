using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments.DocumentTypes
{
    public interface IDocumentType
    {
        [MaxLength(50)]
        [JsonPropertyName("subPackageNumber")]
        public string SubPackageNumber { get; set; }

        [Required(ErrorMessage = "Cte é necessario.")]
        [JsonPropertyName("cte")]
        public Cte Cte { get; set; }
    }

    public class DocumentType : IDocumentType
    {
        [MaxLength(50)]
        [JsonPropertyName("subPackageNumber é necessario.")]
        public string SubPackageNumber { get; set; }

        [Required(ErrorMessage = "Cte é necessario.")]
        [JsonPropertyName("cte")]
        public Cte Cte { get; set; }
    }





    
}