using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.LoggiPontos
{
    /// <summary>
    /// Objeto devolvido pela API DropOffLocationsAPI -> Listar Loggi Pontos
    /// </summary>
    public class PontosResponse
    {
        /// <summary>
        /// Informa que houve sucesso na pesquisa.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Paginação dos resultados com o objeto <see cref="PontosMessage"/>
        /// </summary>
        [JsonPropertyName("message")]
        public PontosMessage Message { get; set; }
    }
}