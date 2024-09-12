using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Shipments;

namespace Loggi.NetSDK.Models.Package
{
    /// <summary>
    /// Objeto para ser usado na API package -> PackageUpdateAPI
    /// </summary>
    public class PackageUpdate
    {
        /// <summary>
        ///Identifica o campo do pacote que será atualizado.
        /// </summary>
        [JsonPropertyName("updateMask")]
        public string UpdateMask { get; } = "shipTo";

        /// <summary>
        /// Objeto que configura o formato da requisição de atualização do destinatário. Contém as informações da pessoa destinatária e do endereço de entrega.\|||||||||||||||||||||
        /// </summary>
        [JsonPropertyName("shipTo")]
        public ShipTo ShipTo { get; set; }
    }
}