using GPTYKhoa.Models;
using System.Threading.Tasks;

namespace GPTYKhoa.Controllers
{
    public class GptController
    {
        private readonly GptModel _gptModel;

        public GptController()
        {
            _gptModel = new GptModel();
        }

        public async Task<string> GetGptResponse(string userInput)
        {
            // Giả định `response` là kết quả từ GPT
            var response = await _gptModel.GetResponse(userInput);

            // Chỉ trả về phản hồi từ GPT, không lưu vào cơ sở dữ liệu
            return response;
        }
    }
}
