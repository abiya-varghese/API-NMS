using nms_backend_api.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace nms_backend_api.DTO
{
    public class TeacherAttendenceDTO
    {
        public string TeacherAttendId { get; set; }
        public string TeacherId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool status { get; set; }
    }
}
