using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Enums;

namespace Loggi.NetSDK.Models.Shipments
{
    public class ShipTo
    {
        /// <summary>
        /// Nome do recebedor. Tamanho mínimo 1 caractere e tamanho máximo 128 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Um nome é necessario")]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Email do recebedor. Tamanho máximo 300 caracteres.
        /// </summary>
        [MinLength(0)]
        [MaxLength(300)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Telefone do recebedor. Caso não informado o código do país,
        /// será considerado 55 (Brasil). Tamanho máximo 16 caracteres.
        /// </summary>
        [MinLength(0)]
        [MaxLength(16)]
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// CPF (com 11 dígitos) ou CNPJ (com 14 dígitos) do recebedor.
        /// </summary>
        [Required]
        [MinLength(11)]
        [MaxLength(14)]
        [JsonPropertyName("federalTaxId")]
        public string FederalTaxId { get; set; }

        /// <summary>
        /// Inscrição Estadual do recebedor. Tamanho máximo 16 caracteres.
        /// </summary>
        [MinLength(0)]
        [MaxLength(16)]
        [JsonPropertyName("stateTaxId")]
        public string StateTaxId { get; set; }

        /// <summary>
        /// Objeto que representa um endereço nacional em formato dos Correios ou um endereço internacional.
        /// Os objetos correiosAddress e lineAddress são mutuamente exclusivos.
        /// </summary>
        [Required(ErrorMessage = "Address é necessario.")]
        [JsonPropertyName("address")]
        public IAddressType Address { get; set; }

        /// <summary>
        /// Identifica a transportadora responsável pelo pacote no fluxo de operação universal.
        /// </summary>
        [JsonPropertyName("shippingCompany")]
        public ShippingCompany? ShippingCompany { get; set; }

        /// <summary>
        /// Identificador do tipo de coleta. Por padrão será considerado o valor PICKUP_TYPE_SPOT.
        /// </summary>
        [JsonPropertyName("pickupType")]
        public string PickupType { get; set; } = PickupTypes.PickupTypeSpot;

        /// <summary>
        /// Identificador do tipo de entrega. Por padrão será considerado o valor DELIVERY_TYPE_CUSTOMER_DOOR.
        /// </summary>
        [JsonPropertyName("deliveryType")]
        public string DeliveryType { get; set; } = DeliveryTypes.DeliveryTypeCustomerDoor;
        
        
    }
}