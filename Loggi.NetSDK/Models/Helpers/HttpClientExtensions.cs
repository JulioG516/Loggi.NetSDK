using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Loggi.NetSDK.Models.Helpers
{
    internal static class HttpClientExtensions
    {
        internal static async Task<LoggiResponse<Token>> GetToken(this HttpClient httpClient, object body)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
                "oauth2/token");
            var jsonBody = JsonSerializer.Serialize(body);
            request.Content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return new LoggiResponse<Token>
                {
                    Data = JsonSerializer.Deserialize<Token>(json)!
                };
            }
            else
            {
                var json = await response.Content.ReadAsStringAsync();
                return new LoggiResponse<Token>
                {
                    Error = JsonSerializer.Deserialize<ErrorResponse>(json)
                };
            }
        }
        
        internal static async Task<LoggiResponse<T>> SendGetJsonAsync<T>(this HttpClient httpClient,
            HttpRequestMessage requestMessage, Token token)
            where T : class
        {
            if (token == null || string.IsNullOrEmpty(token.IdToken))
                throw new InvalidOperationException(
                    "Você precisa autenticar primeiro, usando o método LoggiClient.AuthenticateAsync");

            var response = await httpClient.SendAsync(requestMessage);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return new LoggiResponse<T>
                {
                    Data = JsonSerializer.Deserialize<T>(json)!
                };
            }
            else
            {
                var json = await response.Content.ReadAsStringAsync();
                return new LoggiResponse<T>
                {
                    Error = JsonSerializer.Deserialize<ErrorResponse>(json)
                };
            }
        }


        internal static async Task<LoggiResponse<T>> SendPostAsync<T>(this HttpClient httpClient,
            HttpRequestMessage requestMessage, object body, Token token)
            where T : class
        {
            // Serialize the body to JSON
            var jsonBody = JsonSerializer.Serialize(body);
            requestMessage.Content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

            if (token == null || string.IsNullOrEmpty(token.IdToken))
                throw new InvalidOperationException(
                    "Você precisa autenticar primeiro, usando o método LoggiClient.AuthenticateAsync");

            requestMessage.Headers.Add("authorization", $"Bearer {token.IdToken}");

            var response = await httpClient.SendAsync(requestMessage);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return new LoggiResponse<T>
                {
                    Data = JsonSerializer.Deserialize<T>(json)!
                };
            }
            else
            {
                var json = await response.Content.ReadAsStringAsync();
                return new LoggiResponse<T>
                {
                    Error = JsonSerializer.Deserialize<ErrorResponse>(json)
                };
            }
        }
    }
}