using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nms_backend_api.Entity
{
    [Table("tbl_user")]

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("UserName", TypeName = "varchar")]
        public string UserName { get; set; }

        [Required][StringLength(20)]
        public string Password { get; set; }
        [Required]
        [StringLength(20)]
        public string Role { get; set; }

        [Required]
        [Column("PhoneNo", TypeName = "varchar")]
        [StringLength(15)]
        public string PhoneNum { get; set; }
        [Required] //set not null constraint
        [Column("EmailId", TypeName = "varchar")]
        [StringLength(30)]
        public string Emailid { get; set; }

        [Required]
        public int AdmissionId { get; set; }
    }
}
