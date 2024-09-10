using System;
using System.Net.Http;
using System.Threading.Tasks;
using Loggi.NetSDK.Models;
using Loggi.NetSDK.Models.Helpers;
using Loggi.NetSDK.Models.Shipments;

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

        public async Task<LoggiResponse<ShipmentResponse>> CriarShipmentAsync(Shipment shipment)
        {
            var response = await _httpClient.SendPostAsync<ShipmentResponse>(
                new HttpRequestMessage(HttpMethod.Post, $"v1/companies/{_companyId}/async-shipments"),
                shipment, _token);

            return response;
        }
    }
}