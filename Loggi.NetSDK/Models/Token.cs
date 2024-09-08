using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models
{
    public class Token
    {
        [JsonPropertyName("idToken")] public string IdToken { get; set; }
        [JsonPropertyName("expiresIn")] public string ExpiresIn { get; set; }
    }
}