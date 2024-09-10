using System;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Tracking
{
    /// <summary>
    /// Objeto que representa as informações do status de um pacote.
    /// </summary>
    public class TrackingStatus
    {
        /// <summary>
        /// Código numérico referente ao estado do pacote. *Listado como Int nos documentarios da Logggi porem é string.*
        /// </summary>
        //TODO: Fazer um enum para o status
        //TODO: Fazer um converter para o status
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// Status geral do pacote em formato legível.
        /// </summary>
        [JsonPropertyName("highLevelStatus")]
        public string HighLevelStatus { get; set; }

        /// <summary>
        /// Breve descrição do status do pacote.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Objeto que representa uma ação que deve ser tomada pelo embarcador para continuar a entrega.
        /// </summary>
        [JsonPropertyName("actionRequired")]
        public StatusActionRequired ActionRequired { get; set; }

        /// <summary>
        /// Data que o pacote entrou no status atual.
        /// </summary>
        [JsonPropertyName("updatedTime")]
        public DateTime? UpdatedTime { get; set; }
    }

    /// <summary>
    /// Objeto que representa uma ação que deve ser tomada pelo embarcador para continuar a entrega.
    /// </summary>
    public class StatusActionRequired
    {
        /// <summary>
        /// Breve descrição da ação que precisa ser tomada pelo embarcador.
        /// </summary>
        [JsonPropertyName("reasonDescription")]
        public string ReasonDescription { get; set; }

        /// <summary>
        /// Rótulo da ação que precisa ser tomada pelo embarcador.
        /// </summary>
        [JsonPropertyName("reasonLabel")]
        public string ReasonLabel { get; set; }
    }
}