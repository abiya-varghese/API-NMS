using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nms_backend_api.Entity
{
    [Table("tbl_student")]
    public class Student
    {

        [Key]
        public string StudentId { get; set; }

        [Required] //set not null constraint
        [Column("FirstName", TypeName = "varchar")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required] //set not null constraint
        [Column("LastName", TypeName = "varchar")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        public string Rollno { get; set; }

        [Required]
        [Column("Address", TypeName = "varchar")]
        [StringLength(50)]
        public string Address { get; set; }

    
      
        [Required]
        public DateTime DOB { get; set; }

        

        [Column(TypeName = "char")]
        [StringLength(10)]
        public string Gender { get; set; }//to be enum

        [Required]
        public DateTime RegDate { get; set; }


        [Required]
        public string ClassId { get; set; }//to be enum

        [ForeignKey("ClassId")]
        public Class1? Class { get; set; }

    }
}
