using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace nms_backend_api.Entity
{
    [Table("tbl-assign")]
    public class AssignClass
    {
        [Key]
        public string AssignId { get; set; }
        [ForeignKey("Classid")]
        public  Class1? Classes { get; set; }
        public string Classid { get; set; }

        [ForeignKey("TeacherId")]
        public  Teacher? Teachers { get; set; }
        public string TeacherId { get; set; }

    }
}
