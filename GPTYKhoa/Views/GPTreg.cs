using GPTYKhoa.Controllers;
using System;
using System.Windows.Forms;

namespace GPTYKhoa.Views
{
    public partial class GPTreg : Form
    {
        private readonly AccountController _accountController;

        public GPTreg()
        {
            InitializeComponent();
            _accountController = new AccountController(); // Khởi tạo không tham số
        }

        private void GPTreg_Load(object sender, EventArgs e)
        {

        }

        private async void registerButton_Click_1(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;

            var result = await _accountController.Register(username, password, email);
            MessageBox.Show(result);

            // Nếu đăng ký thành công, chuyển đến form đăng nhập
            if (result == "Đăng ký thành công")
            {
                this.Hide();
                var loginForm = new GPTlog();
                loginForm.Show();
            }
        }

        private void backToLoginButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new GPTlog();
            loginForm.Show();
        }
    }
}
