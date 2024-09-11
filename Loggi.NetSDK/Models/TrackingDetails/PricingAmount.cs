using System;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.TrackingDetails
{
    /// <summary>
    /// Objeto com as informações do preço do envio de pacote. Usado no <see cref="TrackingDetailsPricing"/>
    /// Também usado como GoodsValue na <see cref="FreightPriceQuotation.QuotationPackage"/>
    /// </summary>
    public class PricingAmount
    {
        /// <summary>
        /// Código de 3 letras que estabelece a moeda da precificação do envio do pacote, definido na ISO4217
        /// </summary>
        [JsonPropertyName("currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Componente inteiro do preço do envio do pacote. Um envio com preço de 7,52 teria "7" units.
        /// </summary>
        [JsonPropertyName("units")]
        public String Units { get; set; }

        /// <summary>
        /// Componente não inteiro do preço do envio do pacote multiplicado por 10⁹. Um envio com preço de 7,52 teria 520000000 nanos.
        /// </summary>
        [JsonPropertyName("nanos")]
        public string Nanos { get; set; }
    }
}