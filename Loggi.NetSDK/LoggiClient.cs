using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Loggi.NetSDK.Models;
using Loggi.NetSDK.Models.Helpers;
using Loggi.NetSDK.Models.Shipments;
using Loggi.NetSDK.Models.Tracking;
using Loggi.NetSDK.Models.TrackingDetails;

namespace Loggi.NetSDK
{
    public class LoggiClient
    {
        private string _clientId;
        private string _clientSecret;
        private readonly string _companyId;

        private readonly HttpClient _httpClient;

        private Token _token;

        public LoggiClient(string companyId)
        {
            _companyId = companyId;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.loggi.com/")
            };
        }

        /// <summary>
        /// Autentica o usuario para que possa ser utilizado as demais requests.
        /// </summary>
        /// <param name="clientId">Id do cliente cadastrado na Loggi.</param>
        /// <param name="clientSecret">Chave secreta gerada pela Loggi.</param>
        /// <returns>Objeto <see cref="LoggiResponse{T}"/> Podendo conter o <see cref="Token"/> Se obter sucesso.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<LoggiResponse<Token>> AuthenticateAsync(string clientId, string clientSecret)
        {
            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentNullException(nameof(clientId), "clientID não pode ser nulo ou vazio.");

            if (string.IsNullOrEmpty(clientSecret))
                throw new ArgumentNullException(nameof(clientSecret), "clientSecret não pode ser nulo ou vazio.");

            var response = await _httpClient.GetToken(new TokenRequest()
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            });

            if (response.Data != null)
            {
                _token = response.Data;
                _clientId = clientId; // So we can refresh later on
                _clientSecret = clientSecret;
            }

            return response;
        }


        /// <summary>
        /// Cria um Shipment de forma assíncrona. Para iniciar um envio, você precisará de um endereço de origem, outro de destino e um pacote.
        /// </summary>
        /// <param name="shipment">Objeto <see cref="Shipment"/> obtido a partir de um builder.</param>
        /// <returns>Um objeto <see cref="LoggiResponse{T}"/> Contendo <see cref="ShipmentResponse"/> Se obter sucesso.</returns>
        /// <exception cref="ArgumentNullException">Quando shipment é nulo.</exception>
        /// <exception cref="ArgumentNullException">Quando shipment.ShipTo é nulo.</exception>
        /// <exception cref="ArgumentNullException">Quando shipment.ShipFrom é nulo.</exception>
        /// <exception cref="ArgumentNullException">Quando shipment.Packages é nulo ou vazio.</exception>
        /// <exception cref="InvalidOperationException">Quando não autenticado.</exception>
        public async Task<LoggiResponse<ShipmentResponse>> CriarShipmentAsync(Shipment shipment)
        {
            if (shipment == null)
                throw new ArgumentNullException(nameof(shipment), "Shipment nâo pode ser nulo.");
            if (shipment.ShipTo != null)
                throw new ArgumentNullException(nameof(shipment.ShipTo), "ShipTo em Shipment não pode ser nulo.");
            if (shipment.ShipFrom != null)
                throw new ArgumentNullException(nameof(shipment.ShipFrom), "ShipFrom em Shipment não pode ser nulo.");
            if (shipment.Packages == null || !shipment.Packages.Any())
                throw new ArgumentNullException(nameof(shipment.Packages), "Packages deve conter ao menos um valor.");


            var response = await _httpClient.SendPostAsync<ShipmentResponse>(
                $"v1/companies/{_companyId}/async-shipments",
                shipment, _token);

            return response;
        }

        /// <summary>
        /// Faz o rastreio de pacotes a partir das informações de CompanyID e TrackingCode.
        /// </summary>
        /// <param name="trackingCode">O codigo de rastreio do pacote</param>
        /// <returns>Um objeto <see cref="LoggiResponse{T}"/> Contendo <see cref="TrackingResponse"/> Se obter sucesso.</returns>
        /// <exception cref="ArgumentNullException">Quando trackingCode é nulo ou vazio.</exception>
        /// <exception cref="InvalidOperationException">Quando não autenticado.</exception>
        public async Task<LoggiResponse<TrackingResponse>> RastrearPacote(string trackingCode)
        {
            if (string.IsNullOrEmpty(trackingCode))
                throw new ArgumentNullException(nameof(trackingCode), "Tracking Code não pode ser nulo ou vazio.");

            var response = await _httpClient.SendGetJsonAsync<TrackingResponse>
                ($"v1/companies/{_companyId}/packages/{trackingCode}/tracking", _token);

            return response;
        }

        /// <summary>
        /// Recupera detalhes de um pacote a partir das informações do TrackingCode.
        /// </summary>
        /// <param name="trackingCode">O codigo de rastreio do pacote</param>
        /// <returns>Um objeto <see cref="LoggiResponse{T}"/> Contendo <see cref="TrackingDetailsResponse"/> Se obter sucesso.</returns>
        /// <exception cref="ArgumentNullException">Quando trackingCode é nulo ou vazio.</exception>
        /// <exception cref="InvalidOperationException">Quando não autenticado.</exception>
        public async Task<LoggiResponse<TrackingDetailsResponse>> RastrearPacoteDetalhado(string trackingCode)
        {
            if (string.IsNullOrEmpty(trackingCode))
                throw new ArgumentNullException(nameof(trackingCode), "Tracking Code não pode ser nulo ou vazio.");

            var response = await _httpClient.SendGetJsonAsync<TrackingDetailsResponse>
                ($"v1/companies/{_companyId}/packages/{trackingCode}", _token);

            return response;
        }

        // TODO: Labels - ez

        // TODO: Freight Price Quotation - Medium

        // TODO: Packages - Medium

        // TODO: Integrador - Medium
        
        // TODO: Loggi Pontos - Medium
        
        // TODO: Janela de Coletas - ez
    }
}