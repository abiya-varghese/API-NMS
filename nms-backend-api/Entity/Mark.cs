using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace nms_backend_api.Entity
{
    [Table("tbl_mark")]
    public class Mark
    {
        [Key]
        public string MarkId { get; set; }

        [Required]
        [Column("StudentId")]
        public string StudentId { get; set; }

        [Required]
        [Column("ExamId")]
        public string ExamId { get; set; }

        [Required]
        [Column("Marks")]

        public float Marks { get; set; }

        [Required]
        [Column("Subject Name", TypeName = "varchar")]
        [StringLength(50)]
        public string? SubjectName { get; set; }
        [Required]
        [Column("FirstName", TypeName = "varchar")]
        [StringLength(50)]
        public string ExamName { get; set; }
        [Required]
        [Column("LastName", TypeName = "varchar")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Column("Exam Name", TypeName = "varchar")]
        [StringLength(50)]
        public string LastName { get; set; }

        [ForeignKey("ExamId")]
        public Examination? examination { get; set; }

        [ForeignKey("StudentId")]
        public Student? student { get; set; }
    }
}
