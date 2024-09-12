using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Shipments;

namespace Loggi.NetSDK.Models.Package
{
    /// <summary>
    /// Objeto para ser usado na API package -> PackageUpdateAPI
    /// </summary>
    public class PackageUpdate
    {
        [JsonPropertyName("updateMask")] public string UpdateMask { get;  }= "shipTo";
        [JsonPropertyName("shipTo")] public ShipTo ShipTo { get; set; }
    }
}