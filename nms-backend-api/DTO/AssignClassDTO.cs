using nms_backend_api.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace nms_backend_api.DTO
{
    public class AssignClassDTO
    {
        public string AssignId { get; set; }
        public string Classid { get; set; }
        public string TeacherId { get; set; }
    }
}
