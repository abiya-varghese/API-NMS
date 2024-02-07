using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nms_backend_api.Entity
{
    [Table("tbl_student")]
    public class Student
    {

        [Key]
        public int StudentId { get; set; }

        [Required] //set not null constraint
        [Column("FirstName", TypeName = "varchar")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required] //set not null constraint
        [Column("LastName", TypeName = "varchar")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        public int Rollno { get; set; }

        [Required]
        [Column("Address", TypeName = "varchar")]
        [StringLength(50)]
        public string Address { get; set; }

    
      
        [StringLength(50)]
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage = "Invalid EmailId")] //validate input value with email fromat
        public string Email { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Enter Mobile")]
        [RegularExpression("[6-9]\\d{9}", ErrorMessage = "Invalid Mobile No")]
        public string Contactno { get; set; }

        [Column(TypeName = "char")]
        [StringLength(10)]
        public string Gender { get; set; }//to be enum

        [Required]
        public DateTime RegDate { get; set; }


        [Required]
        public int ClassId { get; set; }//to be enum

        [ForeignKey("ClassId")]
        public Class1? Class { get; set; }

    }
}
