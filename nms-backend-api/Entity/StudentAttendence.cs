using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace nms_backend_api.Entity
{
    [Table("tbl_StudentAttendence")]

    public class StudentAttendence
    {
        [Key]
        public string StudAttendenceId { get; set; }
        public string StudentId { get; set; }
        [ForeignKey("StudentId")]

        public Student? Student { get; set; }

        [Required]
        public DateTime AttendanceDate { get; set; }

        [Required]
        public bool status { get; set; }
    }
}
