using System;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Loggi.NetSDK.Models.TrackingDetails;

namespace Loggi.NetSDK.Models.FreightPriceQuotation
{
    public class QuotationPrice
    {
        [JsonPropertyName("totalAmount")] public PricingAmount TotalAmount { get; set; }
        [JsonPropertyName("baseAmount")] public PricingAmount BaseAmount { get; set; }
        [JsonPropertyName("taxesAndFees")] public TaxesAndFees TaxesAndFees { get; set; }
    }

    public class TaxesAndFees
    {
        [JsonPropertyName("pis")] public Tax Pis { get; set; }
        [JsonPropertyName("cofins")] public Tax Cofins { get; set; }
        [JsonPropertyName("gris")] public Tax Gris { get; set; }
        [JsonPropertyName("advalorem")] public Tax Advalorem { get; set; }
        [JsonPropertyName("icms")] public Tax Icms { get; set; }
        [JsonPropertyName("iss")] public Tax Iss { get; set; }
    }

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