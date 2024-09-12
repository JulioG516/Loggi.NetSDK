using System.Text.Json.Serialization;
using Loggi.NetSDK.Models.Addresses;

namespace Loggi.NetSDK.Models.FreightPriceQuotation
{
    /// <summary>
    /// Encapsula os objetos <see cref="CorreiosAddress"/>, <see cref=""/> />
    /// </summary>
    public interface IQuotationAddress
    {
    }

    /// <summary>
    /// Encapsula o objeto <see cref="CorreiosAddress"/>  para ser enviado para a Loggi como uma propriedade que pode ter 3 opções diferentes.
    /// </summary>
    public class QuotationAddressCorreios : IQuotationAddress
    {
        /// <summary>
        /// Objeto que contém informações detalhadas do endereço compatível com o formato da API dos Correios.
        /// </summary>
        [JsonPropertyName("correios")]
        public CorreiosAddress Correios { get; set; }
    }

    /// <summary>
    /// Encapsula o objeto <see cref="LineAddress"/> para ser enviado para a Loggi como uma propriedade que pode ter 3 opções diferentes.
    /// </summary>
    public class QuotationAddressLine : IQuotationAddress
    {
        /// <summary>
        /// Representação alternativa de endereços utilizando duas linhas e outros componentes.
        /// </summary>
        [JsonPropertyName("lines")]
        public LineAddress Lines { get; set; }
    }

    /// <summary>
    /// Encapsula o objeto <see cref="WidgetAddress"/> para ser enviado para a Loggi como uma propriedade que pode ter 3 opções diferentes.
    /// </summary>
    public class QuotationAddressWidget : IQuotationAddress
    {
        /// <summary>
        /// Representação de endereço utilizando Autocomplete UI Widget + context.
        /// </summary>
        [JsonPropertyName("widget")]
        public WidgetAddress Widget { get; set; }
    }
}