using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.TrackingDetails;

namespace Loggi.NetSDK.Models.FreightPriceQuotation
{
    /// <summary>
    /// Objeto que contém os valores gerado pela Loggi.
    /// </summary>
    public class QuotationPrice
    {
        /// <summary>
        /// Preço total do frete com taxas e impostos incluídos.
        /// </summary>
        [JsonPropertyName("totalAmount")]
        public PricingAmount TotalAmount { get; set; }

        /// <summary>
        /// Preço do frete sem taxas e impostos incluídos.
        /// </summary>
        [JsonPropertyName("baseAmount")]
        public PricingAmount BaseAmount { get; set; }

        /// <summary>
        /// Taxas e impostos incluídos.
        /// </summary>
        [JsonPropertyName("taxesAndFees")]
        public TaxesAndFees TaxesAndFees { get; set; }
    }

    /// <summary>
    /// Objeto que encapsula Taxas e Impostos, cada um sendo representnado pelo <see cref="Tax"/>
    /// </summary>
    public class TaxesAndFees
    {
        /// <summary>
        /// Objeto <see cref="Tax"/> referente os impostos do Pis.
        /// </summary>
        [JsonPropertyName("pis")]
        public Tax Pis { get; set; }

        /// <summary>
        /// Objeto <see cref="Tax"/> referente os impostos do Cofins.
        /// </summary>
        [JsonPropertyName("cofins")]
        public Tax Cofins { get; set; }

        /// <summary>
        /// Objeto <see cref="Tax"/> referente os impostos do Gris.
        /// </summary>
        [JsonPropertyName("gris")]
        public Tax Gris { get; set; }

        /// <summary>
        /// Objeto <see cref="Tax"/> referente os impostos do Advalorem.
        /// </summary>
        [JsonPropertyName("advalorem")]
        public Tax Advalorem { get; set; }

        /// <summary>
        /// Objeto <see cref="Tax"/> referente os impostos do Icms.
        /// </summary>
        [JsonPropertyName("icms")]
        public Tax Icms { get; set; }

        /// <summary>
        /// Objeto <see cref="Tax"/> referente os impostos do Iss.
        /// </summary>
        [JsonPropertyName("iss")]
        public Tax Iss { get; set; }
    }

    /// <summary>
    /// Objeto que a porcentagem aplicada de imposto e o valor do imposto.
    /// </summary>
    public class Tax
    {
        /// <summary>
        /// Porcentagem aplicada no imposto.
        /// </summary>
        [JsonPropertyName("rate_tax")]
        public string Ratetax { get; set; }

        /// <summary>
        /// Valor do imposto com a porcentagem do RateTax.
        /// </summary>
        [JsonPropertyName("amount")]
        public PricingAmount Amount { get; set; }
    }
}