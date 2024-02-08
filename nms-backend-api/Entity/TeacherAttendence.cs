using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace nms_backend_api.Entity
{
    public class TeacherAttendence
    {
        [Key]
        public string TeacherAttendId { get; set; }
        [Column("TeacherId")]
        public string TeacherId { get;set; }
        

        [ForeignKey("TeacherId")]
        public Teacher? Teacher { get; set; }

        [Required]
        public DateTime AttendanceDate { get; set; }

        [Required]
        public bool status { get; set; }
    }
}
