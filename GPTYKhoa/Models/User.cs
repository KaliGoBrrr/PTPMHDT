using System;
using System.ComponentModel.DataAnnotations;

namespace GPTYKhoa.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password_hash { get; set; }

        [Required]
        public string email { get; set; }

        public string role { get; set; } = "user";

        public DateTime created_at { get; set; } = DateTime.Now;
    }
}
