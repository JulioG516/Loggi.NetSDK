using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.PickupTime
{
    /// <summary>
    /// Objeto que encapsula a resposta da API Loggi Janela de Coletas -> PickupTimeSlotAPI
    /// </summary>
    public class JanelaColetaResponse
    {
        /// <summary>
        /// Lista de objetos <see cref="AvailableDate"/> retornado pela Loggi.
        /// </summary>
        [JsonPropertyName("availableDates")] public List<AvailableDate> AvailableDates { get; set; }
    }
}