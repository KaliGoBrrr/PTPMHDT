using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPTYKhoa.Models
{
    [Table("AnalysisHistory")] // Chỉ định tên bảng đúng trong cơ sở dữ liệu
    public class AnalysisHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int analysis_id { get; set; }

        public int user_id { get; set; }
        public DateTime analysis_date { get; set; } = DateTime.Now;
        public string analysis_data { get; set; }
        public string result_summary { get; set; }
    }
}
