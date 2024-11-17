using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GPTYKhoa.Models
{
    public class GptModel
    {
        private readonly string _apiKey;
        private readonly string _endpoint = "https://api.openai.com/v1/chat/completions";

        public GptModel()
        {
            _apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY"); // Lấy API key từ biến môi trường
        }

        public async Task<string> GetResponse(string userInput)
        {
            if (string.IsNullOrEmpty(_apiKey))
                return "Lỗi: Thiếu API key.";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new { role = "user", content = userInput }
                    },
                    max_tokens = 100 // Điều chỉnh khi cần
                };

                var json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync(_endpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        using (JsonDocument doc = JsonDocument.Parse(responseContent))
                        {
                            var responseMessage = doc.RootElement
                                .GetProperty("choices")[0]
                                .GetProperty("message")
                                .GetProperty("content")
                                .GetString();

                            return responseMessage;
                        }
                    }
                    else
                    {
                        return $"Lỗi: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
                    }
                }
                catch (Exception ex)
                {
                    return $"Lỗi: Không thể lấy phản hồi. Chi tiết: {ex.Message}";
                }
            }
        }
    }
}
