using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.TrackingDetails
{
    public class TrackingDetailsVolumetricInfo
    {
        [JsonPropertyName("consideredWeightG")]
        public int ConsideredWeightG { get; set; }

        [JsonPropertyName("integration_values")]
        public VolumetricInfoIntegrationValues Integration_values { get; set; }

        [JsonPropertyName("measured_values")] public VolumetricInfoMeasuredValues Measured_values { get; set; }
    }

    public class VolumetricInfoIntegrationValues
    {
        /// <summary>
        /// Espaço real ocupado pelo pacote, com base na relação entre o peso e o volume da carga, representado em gramas (g).
        /// </summary>
        [JsonPropertyName("cubicWeightG")]
        public int CubicWeightG { get; set; }

        [JsonPropertyName("dimensions")] public TrackingDetailsDimension Dimensions { get; set; }
    }

    public class VolumetricInfoMeasuredValues
    {
        /// <summary>
        /// Espaço real ocupado pelo pacote, com base na relação entre o peso e o volume da carga, representado em gramas (g).
        /// </summary>
        [JsonPropertyName("cubicWeightG")]
        public int CubicWeightG { get; set; }

        [JsonPropertyName("dimensions")] public TrackingDetailsDimension Dimensions { get; set; }
    }
}