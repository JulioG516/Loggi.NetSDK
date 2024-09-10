using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Shipments
{
    public class ShipmentResponse
    {
        [JsonPropertyName("packages")] public List<ResponsePackage> Packages { get; set; }
    }

    public class ResponsePackage
    {
        [JsonPropertyName("trackingCode")] public string TrackingCode { get; set; }
        [JsonPropertyName("barcode")] public string Barcode { get; set; }
        [JsonPropertyName("loggiKey")] public string LoggiKey { get; set; }
        [JsonPropertyName("sequence")] public string Sequence { get; set; }
    }
}