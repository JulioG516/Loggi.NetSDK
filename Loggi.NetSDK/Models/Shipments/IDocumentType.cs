using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments
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
        [JsonPropertyName("subPackageNumber")]
        public string SubPackageNumber { get; set; }

        [Required(ErrorMessage = "Cte é necessario.")]
        [JsonPropertyName("cte")]
        public Cte Cte { get; set; }
    }

    public class InvoiceDocumentType : DocumentType
    {
    }

    public class ContentDeclarationDocumentType : DocumentType
    {
    }

    public class DirDocumentType : DocumentType
    {
    }
}