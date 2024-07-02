using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.Services
{
    public class WhatsAppService
    {
        private readonly HttpClient _httpClient;

        public WhatsAppService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendMessageAsync()
        {
            var requestUrl = "https://graph.facebook.com/v19.0/376341388890587/messages";
            var accessToken = "EAAMA0lYZC0aABO3UZCHyNzRKYtyPZCMVnbZBLtc2m63aARzvNOwEZBSEIZC23ZAQJSvFUk2d9f3pYk1bpBcv8l51ftoLRRedSOASazMv55YUrXkFk0dYvIMerYH8HqFf6j1Ab0zxDswlZCtVHlvSD3t5aiZAyCfZAinIWqhIp6e4eFu8d12CCkAICnr16qVI8mGWif2002UTgnmbXKzZBwfiLN7MZB6tQ165qV4bFFZA8";

            var payload = new
            {
                messaging_product = "whatsapp",
                to = "201155823701",
                type = "template",
                template = new
                {
                    name = "hello_world",
                    language = new { code = "en_US" }
                }
            };

            var jsonMessage = System.Text.Json.JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            var response = await _httpClient.PostAsync(requestUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error sending message: {error}");
            }
        }
    }
}



