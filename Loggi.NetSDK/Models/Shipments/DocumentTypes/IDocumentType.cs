using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments.DocumentTypes
{
    /// <summary>
    /// Objeto que encapsula os Tipos de Documentos que podem ser enviado pela Loggi dentro do Package na Shipment API
    /// Podendo ser <see cref="ContentDeclarationDocumentType"/>, <see cref="DirDocumentType"/> ou <see cref="InvoiceDocumentType"/>
    /// </summary>
    public interface IDocumentType
    {
        /// <summary>
        /// Código do subpacote informado pelo cliente associado ao documento. Tamanho máximo de 50 caracteres.
        /// </summary>
        [MaxLength(50)]
        [JsonPropertyName("subPackageNumber")]
        public string SubPackageNumber { get; set; }

        /// <summary>
        /// Objeto CTE contendo uma chave de identificação do Cte. Tamanho de 44 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Cte é necessario.")]
        [JsonPropertyName("cte")]
        public Cte Cte { get; set; }
    }

    /// <inheritdoc />
    public class DocumentType : IDocumentType
    {
        /// <inheritdoc />
        [MaxLength(50)]
        [JsonPropertyName("subPackageNumber é necessario.")]
        public string SubPackageNumber { get; set; }

        /// <inheritdoc />
        [Required(ErrorMessage = "Cte é necessario.")]
        [JsonPropertyName("cte")]
        public Cte Cte { get; set; }
    }
}