using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.LoggiPontos
{
    /// <summary>
    /// Objeto contendo os dados dos Loggi Pontos
    /// </summary>
    public class PontosPagination
    {
        /// <summary>
        /// Identificador único do Loggi Ponto.
        /// </summary>
        [JsonPropertyName("location_id")]
        public string LocationId { get; set; }

        /// <summary>
        /// Nome do Loggi Ponto.
        /// </summary>
        [JsonPropertyName("location_name")]
        public string LocationName { get; set; }

        /// <summary>
        /// Tipo do Loggi Ponto.
        /// </summary>
        [JsonPropertyName("location_type")]
        public string LocationType { get; set; }

        /// <summary>
        /// Categorias do Loggi Ponto.
        /// </summary>
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }

        /// <summary>
        /// Não fornecido pela Loggi.
        /// </summary>
        [JsonPropertyName("available_compartments")]
        public string AvailableCompartments { get; set; }

        /// <summary>
        /// Longitude do Loggi Ponto.
        /// </summary>
        [JsonPropertyName("longitude")]
        public long Longitude { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        [JsonPropertyName("latitude")]
        public long Latitude { get; set; }

        /// <summary>
        /// Páis do Loggi Ponto.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Cidade do Loggi Ponto.
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// Distrito do Loggi Ponto.
        /// </summary>
        [JsonPropertyName("district")]
        public string District { get; set; }

        /// <summary>
        /// CEP do Loggi Ponto.
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Endereço do Loggi Ponto.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Bairro.
        /// </summary>
        [JsonPropertyName("neighborhood")]
        public string Neighborhood { get; set; }

        /// <summary>
        /// Estado.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Complemento.
        /// </summary>
        [JsonPropertyName("complement")]
        public string Complement { get; set; }

        /// <summary>
        /// Horário de funcionamento.
        /// </summary>
        [JsonPropertyName("opening_hours")]
        public string OpeningHours { get; set; }

        /// <summary>
        /// Horário de funcionamento.
        /// </summary>
        [JsonPropertyName("opening_hours_detail")]
        public string OpeningHoursDetail { get; set; }

        /// <summary>
        /// Não fornecido pela Loggi.
        /// </summary>
        [JsonPropertyName("navigation_link")]
        public string NavigationLink { get; set; }

        /// <summary>
        /// Não fornecido pela Loggi.
        /// </summary>
        [JsonPropertyName("special_holidays")]
        public string SpecialHolidays { get; set; }

        /// <summary>
        /// Não fornecido pela Loggi.
        /// </summary>
        [JsonPropertyName("site_condition")]
        public string SiteCondition { get; set; }

        /// <summary>
        /// Lista de objetos contendo informações do horario de funcionamento.
        /// </summary>
        [JsonPropertyName("opening_hours_details")]
        public List<PontoOpeningHourDetails> OpeningHourDetails { get; set; }
    }

    /// <summary>
    /// Objeto contendo informações do horario de funcionamento.
    /// </summary>
    public class PontoOpeningHourDetails
    {
        /// <summary>
        /// Dia da semana.
        /// </summary>
        [JsonPropertyName("day")]
        public string Day { get; set; }

        /// <summary>
        /// Hora de abertura.
        /// </summary>
        [JsonPropertyName("open")]
        public string Open { get; set; }

        /// <summary>
        /// Hora de fechamento.
        /// </summary>
        [JsonPropertyName("close")]
        public string Close { get; set; }
    }
}