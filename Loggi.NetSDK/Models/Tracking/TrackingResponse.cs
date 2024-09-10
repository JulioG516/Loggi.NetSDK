using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Tracking
{
    public class TrackingResponse
    {
        [JsonPropertyName("packages")] public List<TrackingPackage> Packages { get; set; }
    }
}