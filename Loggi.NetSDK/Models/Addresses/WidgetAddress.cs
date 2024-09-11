using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Addresses
{
    public class WidgetAddress
    {
        /// <summary>
        /// Dados do endereço. Tamanho máximo 256 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Address é necessario.")]
        [MinLength(0)]
        [MaxLength(256)]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Complemento do endereço. Tamanho máximo 256 caracteres.
        /// </summary>
        [MinLength(0)]
        [MaxLength(256)]
        [JsonPropertyName("complement")]
        public string Complement { get; set; }

        /// <summary>
        /// Informações fornecidas pelo Google Maps Place API.
        /// </summary>
        [JsonPropertyName("placesApiInfo")]
        public WidgetPlacesApiInfo PlacesApiInfo { get; set; }

        /// <summary>
        /// Contexto sobre o usuário.
        /// </summary>
        [JsonPropertyName("userContext")] public WidgetUserContext UserContext { get; set; }
    }

    /// <summary>
    /// Informações fornecidas pelo Google Maps Place API.
    /// </summary>
    public class WidgetPlacesApiInfo
    {
        /// <summary>
        /// Um place ID é um identificador textual que identifica exclusivamente um local.
        /// </summary>
        [JsonPropertyName("placeId")]
        public string PlaceId { get; set; }

        /// <summary>
        /// Uma string randômica que identifica uma sessão de autocomplete para fins de faturamento.
        /// </summary>
        [JsonPropertyName("sessionId")]
        public string SessionId { get; set; }
    }

    /// <summary>
    /// Contexto sobre o usuário.
    /// </summary>
    public class WidgetUserContext
    {
        /// <summary>
        /// O endereço IPv4 ou IPv6 do usuário.
        /// </summary>
        [JsonPropertyName("userIp")]
        public string UserIp { get; set; }

        /// <summary>
        /// Posição do usuário utilizando LatLng do Google. https://github.com/googleapis/googleapis/blob/master/google/type/latlng.proto
        /// </summary>
        [JsonPropertyName("position")]
        public UserContextPosition Position { get; set; }
    }

    /// <summary>
    /// Posição do usuário utilizando LatLng do Google. https://github.com/googleapis/googleapis/blob/master/google/type/latlng.proto
    /// </summary>
    public class UserContextPosition
    {
        /// <summary>
        /// A latitude em graus. Deve estar na faixa [-90,0, +90,0].
        /// </summary>
        [JsonPropertyName("latitude")]
        public long Latitude { get; set; }

        /// <summary>
        /// A longitude em graus. Deve estar na faixa [-180,0, +180,0].
        /// </summary>
        [JsonPropertyName("longitude")]
        public long Longitude { get; set; }
    }
}