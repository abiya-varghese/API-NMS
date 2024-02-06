using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nms_backend_api.Entity
{
    [Table("tbl_Examination")]

    public class Examination
    {
        [Key]
        public int ExamId { get; set; }

        [Required] //set not null constraint
        [StringLength(50)]
        [Column("ExamName", TypeName = "varchar")]
        public string ExamName { get; set; }

        [Required]
        public DateTime ExamDate { get; set; }
        [Required]
        [Column("ClassId")]
        public int ClassId {  get; set; }
        [ForeignKey("ClassId")]
        public Class1? Class { get; set; }

    }
}

