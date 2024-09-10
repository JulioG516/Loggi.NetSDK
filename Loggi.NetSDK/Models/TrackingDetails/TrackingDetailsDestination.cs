using System;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.TrackingDetails
{
    public class TrackingDetailsDestination
    {
        [JsonPropertyName("recipient")] public DestinationRecipient Destination { get; set; }
        [JsonPropertyName("postalAddress")] public TrackingAddress PostalAddress { get; set; }
    }

    public class DestinationRecipient
    {
        /// <summary>
        /// Nome do destinatário associado ao pacote.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Número de telefone do desinatário associado ao pacote.
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Número de identificação fiscal do destinatário associado ao pacote.
        /// </summary>
        [JsonPropertyName("nif")]
        public string Nif { get; set; }
    }
}