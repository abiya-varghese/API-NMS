﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nms_backend_api.Entity
{
    [Table("tbl_user")]

    public class User
    {
       // public string UserId { get; set; }

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
        [Key]
        [Column("EmailId", TypeName = "varchar")]
        [StringLength(30)]
        public string Emailid { get; set; }

        [Required]
        public string AdmissionId { get; set; }
    }
}
