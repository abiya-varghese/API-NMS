using nms_backend_api.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace nms_backend_api.DTO
{
    public class StudAttendanceDTO
    {
        public int StudAttendenceId { get; set; }
        public int StudentId { get; set; }


        public DateTime AttendanceDate { get; set; }

        public bool status { get; set; }

    }
}
