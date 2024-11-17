using GPTYKhoa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace GPTYKhoa.Views
{
    public partial class GPTAdmin : Form
    {
        private readonly ApplicationDbContext _dbContext;
        private int _userId; // Lưu userId

        // Constructor nhận userId
        public GPTAdmin(int userId)
        {
            InitializeComponent();
            _userId = userId; // Gán userId cho biến
            _dbContext = new ApplicationDbContext(); // Khởi tạo ApplicationDbContext
            LoadUsers(); // Gọi phương thức để tải dữ liệu người dùng (nếu có)
        }

        private void LoadUsers()
        {
            userDataGridView.DataSource = _dbContext.Users
                .Select(u => new
                {
                    u.user_id,
                    u.username,
                    u.email,
                    u.role
                }).ToList();
        }
        private void ClearForm()
        {
            username.Clear();
            email.Clear();
            //password.Clear();
            roleComboBox.SelectedIndex = -1; // Xóa lựa chọn trong ComboBox
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void roleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            var newUser = new User
            {
                username = username.Text,
                email = email.Text,
                //password_hash = HashPassword(password.Text), // Hash mật khẩu trước khi lưu
                role = roleComboBox.SelectedItem.ToString() // Lấy quyền từ ComboBox
            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
            MessageBox.Show("Người dùng đã được thêm thành công!");

            LoadUsers(); // Tải lại danh sách người dùng
            ClearForm();
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            if (userDataGridView.CurrentRow != null)
            {
                int userId = (int)userDataGridView.CurrentRow.Cells["user_id"].Value;
                var user = await _dbContext.Users.FindAsync(userId);

                if (user != null)
                {
                    user.username = username.Text;
                    user.email = email.Text;

                    // Chỉ cập nhật mật khẩu nếu trường mật khẩu không trống
                    //if (!string.IsNullOrEmpty(password.Text))
                    //{
                    //    user.password_hash = HashPassword(password.Text); // Chỉ hash mật khẩu nếu có giá trị mới
                    //}
                    user.role = roleComboBox.SelectedItem.ToString(); // Cập nhật vai trò

                    await _dbContext.SaveChangesAsync();
                    MessageBox.Show("Người dùng đã được cập nhật!");

                    LoadUsers(); // Tải lại danh sách người dùng
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn người dùng để cập nhật.");
            }
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (userDataGridView.CurrentRow != null)
            {
                int userId = (int)userDataGridView.CurrentRow.Cells["user_id"].Value;
                var user = await _dbContext.Users.FindAsync(userId);

                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    await _dbContext.SaveChangesAsync();
                    MessageBox.Show("Người dùng đã được xóa!");

                    LoadUsers(); // Tải lại danh sách người dùng
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn người dùng để xóa.");
            }
        }


        private void userDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = userDataGridView.Rows[e.RowIndex];
                username.Text = row.Cells["username"].Value.ToString();
                email.Text = row.Cells["email"].Value.ToString();
                roleComboBox.SelectedItem = row.Cells["role"].Value.ToString();
            }
        }


        private void GPTAdmin_Load(object sender, EventArgs e)
        {
            roleComboBox.Items.Add("user");
            roleComboBox.Items.Add("admin");
            roleComboBox.SelectedIndex = 0; // Chọn giá trị mặc định là "user"
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
