using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.TrackingDetails
{
    public class TrackingAddress
    {
        /// <summary>
        /// Número da versão da resposta de endereço postal do Google. 0 significa que é a versão mais atual.
        /// </summary>
        [JsonPropertyName("revision")]
        public int Revision { get; set; }

        /// <summary>
        /// Código da região associado ao endereço postal gerado pelo Google.
        /// </summary>
        [JsonPropertyName("regionCode")]
        public string RegionCode { get; set; }

        /// <summary>
        /// Código que representa o idioma encontrado no endereço. Não usado pela Loggi no momento.
        /// </summary>
        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// Código postal do endereço enviado. No Brasil, usa-se o CEP.
        /// </summary>
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Código de ordenação usado para fins postais em alguns países. Não se aplica ao Brasil, e não usado pela Loggi no momento.
        /// </summary>
        [JsonPropertyName("sortingCode")]
        public string SortingCode { get; set; }

        /// <summary>
        /// Área administrativa do endereço. No Brasil, equivale à unidade federativa (UF).
        /// </summary>
        [JsonPropertyName("administrativeArea")]
        public string AdministrativeArea { get; set; }

        /// <summary>
        /// Localidade do endereço destinatário. No Brasil, equivale à cidade. Retorna vazio na maioria das respostas.
        /// </summary>
        [JsonPropertyName("locality")]
        public string Locality { get; set; }

        /// <summary>
        /// Sublocalidade do endereço destinatário. No Brasil, equivale ao bairro. Retorna vazio na maioria das respostas.
        /// </summary>
        [JsonPropertyName("sublocality")]
        public string Sublocality { get; set; }

        /// <summary>
        /// Representação mais simples do endereço associado ao destinatário do pacote. Comumente associado ao formato inserido pelo usuário. Retorno obrigatório.
        /// </summary>
        [JsonPropertyName("addressLines")]
        public List<string> AddressLines { get; set; }
    }
}