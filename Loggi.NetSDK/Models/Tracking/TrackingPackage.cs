using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Converters;

namespace Loggi.NetSDK.Models.Tracking
{
    /// <summary>
    /// Package que é devolvido ao dar GET no TrackingAPI => Rastrear Pacote
    /// </summary>
    public class TrackingPackage
    {
        /// <summary>
        /// Chave que identifica unicamente um pacote dentro da Loggi.
        /// </summary>
        [JsonPropertyName("loggiKey")]
        public string LoggiKey { get; set; }

        /// <summary>
        /// Código de rastreio de um pacote.
        /// </summary>
        [JsonPropertyName("trackingCode")]
        public string TrackingCode { get; set; }

        /// <summary>
        /// Objeto que representa as informações do status de um pacote.
        /// </summary>
        [JsonPropertyName("status")]
        public TrackingStatus Status { get; set; }

        /// <summary>
        /// Objeto que representa a localização do pacote em seu status atual.
        /// </summary>
        [JsonPropertyName("location")]
        public TrackingLocation Location { get; set; }

        /// <summary>
        /// Estimativa de data para a primeira tentativa de entrega.
        /// </summary>
        [JsonPropertyName("promisedDate")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? PromisedDate { get; set; }

        /// <summary>
        /// Timestamp do momento da requisição.
        /// </summary>
        [JsonPropertyName("requestTime")]
        public DateTime? RequestTime { get; set; }

        /// <summary>
        /// Histórico de status de um pacote.
        /// </summary>
        [JsonPropertyName("trackingHistory")]
        public List<TrackingHistory> TrackingHistory { get; set; }

        [JsonPropertyName("deliveryInformation")]
        public TrackingDeliveryInformation DeliveryInformation { get; set; }
    }
    
    /// <summary>
    /// Objeto que representa a localização do pacote em seu status atual.
    /// </summary>
    public class TrackingLocation
    {
        /// <summary>
        /// Cidade de onde a localização foi inferida para o status. 
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// Estado (UF) de onde a localização foi inferida para o status.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }
    }


    /// <summary>
    /// Histórico de status de um pacote.
    /// </summary>
    public class TrackingHistory
    {
        /// <summary>
        /// Objeto que representa as informações do status de um pacote.
        /// </summary>
        [JsonPropertyName("status")]
        public TrackingStatus Status { get; set; }

        /// <summary>
        /// Objeto que representa a localização do pacote em um dado status.
        /// </summary>
        [JsonPropertyName("locatiion")]
        public TrackingLocation Locatiion { get; set; }
    }
}