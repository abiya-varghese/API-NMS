using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nms_backend_api.Entity
{
    [Table("tble_teacher")]
    public class Teacher
    {
        [Key]
        public string TeacherId { get; set; }

        [Required] //set not null constraint
        [Column("FirstName", TypeName = "varchar")]
        [StringLength(30)]
        public string FName { get; set; }

        [Required] //set not null constraint
        [Column("LastName", TypeName = "varchar")]
        [StringLength(30)]
        public string LName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }

        [Column(TypeName = "char")]
        [StringLength(10)]
        public string Gender { get; set; }//to be enum


        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string SubjectTaught { get; set; }
    }
}
