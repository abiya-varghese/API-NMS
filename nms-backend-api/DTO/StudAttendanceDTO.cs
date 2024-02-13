using nms_backend_api.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace nms_backend_api.DTO
{
    public class StudAttendanceDTO
    {
        public string StudentId { get; set; }



        public string status { get; set; }

    }
}
