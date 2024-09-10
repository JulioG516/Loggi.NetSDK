using System;
using System.Net.Http;
using System.Threading.Tasks;
using Loggi.NetSDK.Models;
using Loggi.NetSDK.Models.Helpers;

namespace Loggi.NetSDK
{
    public class LoggiClient
    {
        private readonly string _clientId;
        private readonly string _clientSecret;

        private HttpClient _httpClient;

        public LoggiClient(string clientId, string clientSecret)
        {
            this._clientId = clientId;
            this._clientSecret = clientSecret;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.loggi.com/")
            };
        }


        public async Task<LoggiResponse<Token>> GetToken()
        {
            var response = await _httpClient.SendPostAsync<Token>(new HttpRequestMessage(HttpMethod.Post,
                "oauth2/token"), new TokenRequest()
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret
            });

            return response;
        }
        
        
        
    }
}