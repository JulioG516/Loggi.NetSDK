using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Authorization
{
    public class TokenRequest
    {
        [JsonPropertyName("client_id")] public string ClientId { get; set; }
        [JsonPropertyName("client_secret")] public string ClientSecret { get; set; }

    }
}