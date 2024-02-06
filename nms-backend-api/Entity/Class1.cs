using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace nms_backend_api.Entity
{
    [Table("tbl_class")]

    public class Class1
    {
       
            [Key]
            public int ClassId { get; set; }

             [Required]
             [StringLength(50)]
             [Column("SemName", TypeName = "varchar")]
            public string SemName { get; set; }
             [Required]
             [StringLength(50)]
             [Column("Branch",TypeName="varchar")]
             public string Branch { get; set; }
        [Required]
        [StringLength(50)]
        [Column("TeacherId")]
        public int TeacherId { get; set; }

        [ForeignKey("TeacherId")]
            public Teacher? Teacher { get; set; }



    }
}
