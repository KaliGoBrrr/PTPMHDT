using GPTYKhoa.Controllers;
using GPTYKhoa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPTYKhoa.Views
{
    public partial class GPTYKhoaForm : Form
    {
        private List<string> conversationHistory = new List<string>();
        private bool isConversationSaved = false; // Cờ để kiểm tra cuộc trò chuyện đã được lưu chưa
        private readonly GptController _gptController;
        private readonly ApplicationDbContext _dbContext;
        private int _userId;

        public GPTYKhoaForm(int userId)
        {
            InitializeComponent();
            _dbContext = new ApplicationDbContext();
            _gptController = new GptController();
            _userId = userId;

            LoadHistory();
        }

        private void SetResponse(string response)
        {
            responseRichTextBox.Text = response;
        }

        private void LoadHistory()
        {
            historyListBox.Items.Clear();

            var history = _dbContext.AnalysisHistories
                .Where(h => h.user_id == _userId)
                .OrderByDescending(h => h.analysis_date)
                .Select(h => new { h.analysis_id, h.result_summary })
                .ToList();

            foreach (var item in history)
            {
                historyListBox.Items.Add(new { Id = item.analysis_id, Text = item.result_summary });
            }

            historyListBox.DisplayMember = "Text";
            historyListBox.ValueMember = "Id";
        }

        private async void analyzeButton_Click_1(object sender, EventArgs e)
        {
            string userInput = userInputTextBox.Text;
            if (string.IsNullOrEmpty(userInput))
            {
                MessageBox.Show("Vui lòng nhập câu hỏi.");
                return;
            }

            // Thêm câu hỏi của người dùng vào lịch sử cuộc trò chuyện
            conversationHistory.Add("User: " + userInput);

            // Gọi GPT để phân tích (chỉ trả về phản hồi)
            string fullConversation = string.Join("\n", conversationHistory);
            string response = await _gptController.GetGptResponse(fullConversation);
            SetResponse(response);

            // Thêm phản hồi của GPT vào lịch sử cuộc trò chuyện
            conversationHistory.Add("GPT: " + response);

            // Hiển thị lịch sử cuộc trò chuyện
            DisplayConversationHistory();

            // Xóa nội dung trong TextBox sau khi gửi
            userInputTextBox.Clear();

            isConversationSaved = false; // Đặt lại cờ lưu để chuẩn bị cho lần lưu tiếp theo nếu cần
        }


        private void DisplayConversationHistory()
        {
            responseRichTextBox.Clear();
            foreach (var entry in conversationHistory)
            {
                responseRichTextBox.AppendText(entry + Environment.NewLine);
            }
        }

        private async void historyListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (historyListBox.SelectedItem != null)
            {
                var selectedAnalysis = (dynamic)historyListBox.SelectedItem;
                int analysisId = selectedAnalysis.Id;

                var analysis = await _dbContext.AnalysisHistories.FirstOrDefaultAsync(h => h.analysis_id == analysisId);
                if (analysis != null)
                {
                    conversationHistory.Clear();
                    conversationHistory = analysis.analysis_data.Split(new[] { '\n' }, StringSplitOptions.None).ToList();
                    DisplayConversationHistory();
                }
            }
        }

        private async void newChatButton_Click(object sender, EventArgs e)
        {
            if (!isConversationSaved && conversationHistory.Count > 0)
            {
                await SaveCurrentConversation(); // Sử dụng await thay vì .Wait() để tránh deadlock
            }

            conversationHistory.Clear();
            responseRichTextBox.Clear();
            userInputTextBox.Clear();
            MessageBox.Show("Bắt đầu cuộc trò chuyện mới!");
            isConversationSaved = false;
        }


        private async void saveChatButton_Click(object sender, EventArgs e)
        {
            if (conversationHistory.Count == 0)
            {
                MessageBox.Show("Không có cuộc trò chuyện nào để lưu.");
                return;
            }

            if (!isConversationSaved)
            {
                await SaveCurrentConversation();
                MessageBox.Show("Cuộc trò chuyện đã được lưu!");
                isConversationSaved = true;
            }
            else
            {
                MessageBox.Show("Cuộc trò chuyện này đã được lưu rồi.");
            }
        }

        private async Task SaveCurrentConversation()
        {
            string analysisData = string.Join("\n", conversationHistory);
            string resultSummary = conversationHistory.Last().Length > 100
                ? conversationHistory.Last().Substring(0, 100) + "..."
                : conversationHistory.Last();

            var analysisHistory = new AnalysisHistory
            {
                user_id = _userId,
                analysis_date = DateTime.Now,
                analysis_data = analysisData,
                result_summary = resultSummary
            };

            _dbContext.AnalysisHistories.Add(analysisHistory);
            await _dbContext.SaveChangesAsync();

            LoadHistory();
        }
        private void userInputTextBox_TextChanged(object sender, EventArgs e)
        {
            // Để trống hoặc thêm mã xử lý nếu cần
        }

        private void GPTYKhoaForm_Load(object sender, EventArgs e)
        {

        }

        private async void deleteChatButton_Click(object sender, EventArgs e)
        {
            if (historyListBox.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một cuộc trò chuyện để xóa.");
                return;
            }

            var selectedAnalysis = (dynamic)historyListBox.SelectedItem;
            int analysisId = selectedAnalysis.Id;

            // Tìm và xóa cuộc trò chuyện khỏi cơ sở dữ liệu
            var analysis = await _dbContext.AnalysisHistories.FirstOrDefaultAsync(h => h.analysis_id == analysisId);
            if (analysis != null)
            {
                _dbContext.AnalysisHistories.Remove(analysis);
                await _dbContext.SaveChangesAsync();

                MessageBox.Show("Cuộc trò chuyện đã được xóa!");

                // Cập nhật danh sách lịch sử trò chuyện
                LoadHistory();
                responseRichTextBox.Clear(); // Xóa nội dung hiển thị trong RichTextBox
                conversationHistory.Clear(); // Xóa lịch sử trò chuyện trong bộ nhớ
            }
            else
            {
                MessageBox.Show("Không tìm thấy cuộc trò chuyện để xóa.");
            }
        }

        private void responseRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void downloadChatButton_Click(object sender, EventArgs e)
        {
            if (conversationHistory.Count == 0)
            {
                MessageBox.Show("Không có cuộc trò chuyện nào để tải xuống.");
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Lưu cuộc trò chuyện";
                saveFileDialog.FileName = "CuocTroChuyen.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Lưu toàn bộ cuộc trò chuyện vào tệp văn bản
                        System.IO.File.WriteAllLines(saveFileDialog.FileName, conversationHistory);
                        MessageBox.Show("Cuộc trò chuyện đã được tải xuống thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi lưu tệp: " + ex.Message);
                    }
                }
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            // Xác nhận người dùng muốn đăng xuất
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận Đăng Xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Đóng form hiện tại (GPTYKhoaForm)
                this.Close();

                // Mở lại màn hình đăng nhập
                var loginForm = new GPTlog(); // Giả sử bạn có một form đăng nhập tên là LoginForm
                loginForm.Show();
            }
        }

    }
}
