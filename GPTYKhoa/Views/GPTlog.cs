using GPTYKhoa.Controllers;
using System;
using System.Windows.Forms;

namespace GPTYKhoa.Views
{
    public partial class GPTlog : Form
    {
        private readonly AccountController _accountController;

        public GPTlog()
        {
            InitializeComponent();
            _accountController = new AccountController(); // Khởi tạo không tham số
        }

        private void GPTlog_Load(object sender, EventArgs e)
        {

        }

        private async void loginButton_Click_1(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            var user = await _accountController.Login(username, password);

            if (user != null)
            {
                int userId = user.user_id;
                MessageBox.Show("Đăng nhập thành công với quyền: " + user.role);

                // Kiểm tra vai trò của người dùng
                this.Hide();
                if (user.role == "admin")
                {
                    // Nếu vai trò là admin, chuyển đến form GPTAdmin
                    var adminForm = new GPTAdmin(userId); // Truyền userId vào GPTAdmin
                    adminForm.Show();
                }
                else
                {
                    // Nếu là user bình thường, chuyển đến form GPTYKhoaForm
                    var mainForm = new GPTYKhoaForm(userId); // Truyền userId vào GPTYKhoaForm
                    mainForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không chính xác");
            }
        }

        private void goToRegisterButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var registerForm = new GPTreg();
            registerForm.Show();
        }
    }
}
