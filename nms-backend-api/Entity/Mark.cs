using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace nms_backend_api.Entity
{
    [Table("tbl_mark")]
    public class Mark
    {
        [Key]
        public int MarkId { get; set; }

        [Required]
        [Column("StudentId")]
        public int StudentId { get; set; }

        [Required]
        [Column("ExamId")]
        public int ExamId { get; set; }

        [Required]
        [Column("Marks")]
        public float Marks { get; set; }

        [ForeignKey("ExamId")]
        public Examination? examination { get; set; }

        [ForeignKey("StudentId")]
        public Student? student { get; set; }
    }
}
