using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.LoggiPontos
{
    /// <summary>
    /// Objeto ussado para utilizar a API de LoggiPontos -> DropOffLocationsAPI ->  Listar Loggi Pontos.
    /// </summary>
    public class PontosRequest
    {
        /// <summary>
        /// Nome da categoria do Loggi Ponto. Atualmente é a sigla do estado e só será considerado o primeiro campo da lista.
        /// </summary>
        [Required(ErrorMessage = "Ao menos uma categoria é necessario.")]
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }

        /// <summary>
        /// Quantidade máxima de Loggi Pontos a serem retornados por página.
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; } = 100;

        /// <summary>
        /// Posição do primeiro Loggi Ponto a ser retornado.
        /// </summary>
        [JsonPropertyName("offset")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Filtro por identificador único para retornar um Loggi Ponto específico.
        /// </summary>
        [JsonPropertyName("location_id")]
        public string? LocationId { get; set; } = null;

        /// <summary>
        /// Filtro por proximidade de CEP.
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; } = null;

        /// <summary>
        /// Filtro por país.
        /// </summary>
        [JsonPropertyName("country")]
        public string? Country { get; set; } = "Brasil";

        /// <summary>
        /// Filtro de cidade.
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; } = null;

        /// <summary>
        /// Filtro por estado.
        /// </summary>
        [JsonPropertyName("state")]
        public string? State { get; set; } = null;

        /// <summary>
        /// Filtro por longitude.
        /// </summary>
        [JsonPropertyName("longitude")]
        public long? Longitude { get; set; } = null;

        /// <summary>
        /// Filtro por latitude.
        /// </summary>
        [JsonPropertyName("latitude")] public long? Latitude { get; set; } = null;
        
        /// <summary>
        /// Filtro por distância (em metros).
        /// </summary>
        [JsonPropertyName("distance")]
        public long? Distance { get; set; } = null;
    }
}