using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.TrackingDetails
{
    /// <summary>
    /// Informações de volume do pacote.
    /// </summary>
    public class TrackingDetailsVolumetricInfo
    {
        /// <summary>
        /// Peso que vai ser considerado para o cálculo final da cobrança, representado em gramas (g).
        /// </summary>
        [JsonPropertyName("consideredWeightG")]
        public int ConsideredWeightG { get; set; }

        /// <summary>
        /// Dados fornecidos pelo embarcador no envio do pacote.
        /// </summary>
        [JsonPropertyName("integration_values")]
        public VolumetricInfoIntegrationValues IntegrationValues { get; set; }

        /// <summary>
        /// Dados revisados pela Loggi para pacotes medidos e pesados em nossas bases.
        /// </summary>
        [JsonPropertyName("measured_values")]
        public VolumetricInfoMeasuredValues MeasuredValues { get; set; }
    }

    /// <summary>
    /// Dados fornecidos pelo embarcador no envio do pacote.
    /// </summary>
    public class VolumetricInfoIntegrationValues
    {
        /// <summary>
        /// Espaço real ocupado pelo pacote, com base na relação entre o peso e o volume da carga, representado em gramas (g).
        /// </summary>
        [JsonPropertyName("cubicWeightG")]
        public int CubicWeightG { get; set; }

        /// <summary>
        /// Objeto que contèm detalhes da dimensão do pacote.
        /// </summary>
        [JsonPropertyName("dimensions")]
        public TrackingDetailsDimension Dimensions { get; set; }
    }

    /// <summary>
    /// Dados revisados pela Loggi para pacotes medidos e pesados em nossas bases.
    /// </summary>
    public class VolumetricInfoMeasuredValues
    {
        /// <summary>
        /// Espaço real ocupado pelo pacote, com base na relação entre o peso e o volume da carga, representado em gramas (g).
        /// </summary>
        [JsonPropertyName("cubicWeightG")]
        public int CubicWeightG { get; set; }

        /// <summary>
        /// Objeto que contèm detalhes da dimensão do pacote.
        /// </summary>
        [JsonPropertyName("dimensions")]
        public TrackingDetailsDimension Dimensions { get; set; }
    }
}