using nms_backend_api.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace nms_backend_api.DTO
{
    public class TeacherAttendenceDTO
    {
        public string TeacherId { get; set; }
        public string status { get; set; }
    }
}
