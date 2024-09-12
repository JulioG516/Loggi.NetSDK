using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Enums;

namespace Loggi.NetSDK.Models.Shipments
{
    /// <summary>
    /// Objeto shipment utilizado na API de criar shipments da Loggi.
    /// </summary>
    public class Shipment
    {
        /// <summary>
        /// Objeto que representa os dados do embarcador.
        /// </summary>
        [Required(ErrorMessage = "ShipFrom é necessario.")]
        [JsonPropertyName("shipFrom")]
        public ShipFrom ShipFrom { get; set; }

        /// <summary>
        /// Objeto que representa os dados do recebedor.
        /// </summary>
        [Required(ErrorMessage = "ShipTo é necessario.")]
        [JsonPropertyName("shipTo")]
        public ShipTo ShipTo { get; set; }

        /// <summary>
        /// Identifica a transportadora responsável pelo pacote no fluxo de operação universal.
        /// </summary>
        [JsonPropertyName("shippingCompany")]
        public ShippingCompany? ShippingCompany { get; set; }

        /// <summary>
        /// Identificador do tipo de coleta. Por padrão será considerado o valor PICKUP_TYPE_SPOT.
        /// </summary>
        [JsonPropertyName("pickupType")]
        public string PickupType { get; set; } = PickupTypes.Spot;

        /// <summary>
        /// Identificador do tipo de entrega. Por padrão será considerado o valor DELIVERY_TYPE_CUSTOMER_DOOR.
        /// </summary>
        [JsonPropertyName("deliveryType")]
        public string DeliveryType { get; set; } = DeliveryTypes.CustomerDoor;

        /// <summary>
        /// Pacote associado ao envio. A soma das medidas (altura, largura e comprimento) do pacote não podem passar de 200 cm.
        /// </summary>
        [JsonPropertyName("packages")]
        public List<Package> Packages { get; set; }

        /// <summary>
        /// Chave de serviço (disponibilizada pelo time de sales engineering).
        /// </summary>
        [JsonPropertyName("externalServiceId")]
        public string? ExternalServiceId { get; set; }
    }
}