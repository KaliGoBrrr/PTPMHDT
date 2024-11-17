using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GPTYKhoa.Models;
using Microsoft.EntityFrameworkCore;

namespace GPTYKhoa.Controllers
{
    public class AccountController
    {
        private readonly ApplicationDbContext _dbContext;

        // Hàm tạo cho AccountController với tham số ApplicationDbContext
        public AccountController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Hàm tạo không tham số để khởi tạo ApplicationDbContext bên trong controller
        public AccountController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // Phương thức Register để đăng ký người dùng mới
        public async Task<string> Register(string username, string password, string email)
        {
            // Kiểm tra xem email đã tồn tại trong cơ sở dữ liệu chưa
            if (await _dbContext.Users.AnyAsync(u => u.email == email))
            {
                return "Email đã tồn tại";
            }

            // Hash mật khẩu
            string passwordHash = HashPassword(password);

            // Tạo người dùng mới
            var newUser = new User
            {
                username = username,
                password_hash = passwordHash,
                email = email,
                role = "user"
            };

            // Thêm người dùng vào cơ sở dữ liệu
            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();

            return "Đăng ký thành công";
        }

        // Phương thức Login để xác thực người dùng
        public async Task<User> Login(string username, string password)
        {
            // Hash mật khẩu được nhập
            string passwordHash = HashPassword(password);

            // Tìm kiếm người dùng trong cơ sở dữ liệu với tên người dùng và mật khẩu đã hash
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.username == username && u.password_hash == passwordHash);

            // Trả về null nếu không tìm thấy người dùng hoặc trả về thông tin người dùng nếu đăng nhập thành công
            return user;
        }

        // Phương thức để hash mật khẩu
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
