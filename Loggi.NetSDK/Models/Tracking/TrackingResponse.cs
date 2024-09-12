using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Tracking
{
    /// <summary>
    /// Resposta obtida na API de Tracking -> Rastrear Pacote.
    /// </summary>
    public class TrackingResponse
    {
        /// <summary>
        /// Lista de objetos <see cref="TrackingPackage"/>
        /// </summary>
        [JsonPropertyName("packages")] public List<TrackingPackage> Packages { get; set; }
    }
}