using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.TrackingDetails
{
    public class TrackingDetailsResponse
    {
        [JsonPropertyName("packages")] public List<TrackingDetailsPackage> Packages { get; set; }
    }
}