using System;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.TrackingDetails
{
    /// <summary>
    /// Objeto que contém informações ligados ao Destino.
    /// </summary>
    public class TrackingDetailsDestination
    {
        /// <summary>
        /// Objeto que contém informaçoes do destinatario.
        /// </summary>
        [JsonPropertyName("recipient")]
        public DestinationRecipient Destination { get; set; }

        /// <summary>
        /// Objeto contendo informações de um endereço
        /// </summary>
        [JsonPropertyName("postalAddress")]
        public TrackingAddress PostalAddress { get; set; }
    }

    /// <summary>
    /// Objeto que contém informaçoes do destinatario.
    /// </summary>
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