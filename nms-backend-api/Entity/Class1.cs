﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace nms_backend_api.Entity
{
    [Table("tbl_class")]

    public class Class1
    {
       
            [Key]
            public string ClassId { get; set; }

             [Required]
             [StringLength(50)]
             [Column("ClassName", TypeName = "varchar")]
            public string ClassName { get; set; }
             [Required]
             [StringLength(50)]
             [Column("Section",TypeName="varchar")]
             public string Section { get; set; }
        [Required]
        [Column("TeacherId")]
        public string TeacherId { get; set; }

        [ForeignKey("TeacherId")]
            public Teacher? Teacher { get; set; }



    }
}
