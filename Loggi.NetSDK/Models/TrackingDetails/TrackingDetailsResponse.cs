using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.TrackingDetails
{
    /// <summary>
    /// Resposta da API de DetailsAPI -> detalhes do pacote.
    /// </summary>
    public class TrackingDetailsResponse
    {
        /// <summary>
        /// Lista de objetos <see cref="TrackingDetailsPackage"/>
        /// </summary>
        [JsonPropertyName("packages")]
        public List<TrackingDetailsPackage> Packages { get; set; }
    }
}