using System;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.PickupTime
{
    /// <summary>
    /// Objeto devolvido ao utilizar a API de janela de coletas.
    /// </summary>
    public class AvailableDate
    {
        /// <summary>
        /// Data e horário de inicio da janela de coleta
        /// </summary>
        [JsonPropertyName("startDateTime")]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Data e horário do fim da janela de coleta
        /// </summary>
        [JsonPropertyName("endDateTime")]
        public DateTime EndDateTime { get; set; }
    }
}