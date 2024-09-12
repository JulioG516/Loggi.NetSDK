using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.LoggiPontos
{
    /// <summary>
    /// Objeto que representaa o resultado obtido da LoggiPontos
    /// </summary>
    public class PontosMessage
    {
        /// <summary>
        /// Quantidade máxima de Loggi Pontos por página.
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Posição do primeiro Loggi Ponto na página atual.
        /// </summary>
        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Página atual.
        /// </summary>
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }

        /// <summary>
        /// Quantidade total de páginas.
        /// </summary>
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Quantidade total de Loggi Pontos encontrados.
        /// </summary>
        [JsonPropertyName("total_locations")]
        public int TotalLocations { get; set; }

        /// <summary>
        /// Lista dos Loggi Pontos presentes na página atual.
        /// </summary>
        [JsonPropertyName("pagination")]
        public List<PontosPagination> Pagination { get; set; }
    }
}