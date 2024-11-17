using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace GPTYKhoa.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AnalysisHistory> AnalysisHistories { get; set; }
    }
}
