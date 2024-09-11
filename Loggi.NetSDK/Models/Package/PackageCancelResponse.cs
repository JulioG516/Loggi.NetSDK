using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Package
{
    public class PackageCancelResponse
    {
         [JsonPropertyName("warning_type")] public string WarningType { get; set; }
         [JsonPropertyName("warning_message")] public string WarningMessage { get; set; }
    }
}