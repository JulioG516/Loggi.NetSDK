using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Loggi.NetSDK.Models.Helpers
{
    internal static class HttpClientExtensions
    {
        internal static async Task<LoggiResponse<T>> SendGetJsonAsync<T>(this HttpClient httpClient,
            HttpRequestMessage requestMessage)
            where T : class
        {
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
            HttpRequestMessage requestMessage, object body)
            where T : class
        {
            // Serialize the body to JSON
            var jsonBody = JsonSerializer.Serialize(body);
            requestMessage.Content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");


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