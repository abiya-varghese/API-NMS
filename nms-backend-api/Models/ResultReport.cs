using nms_backend_api.DTO;
using nms_backend_api.Entity;

namespace nms_backend_api.Models
{
    public class ResultReport
    {
      public  List<ResultDisplay> stdDisplay { get; set; }
        public string Percentage {  get; set; }
        public string totalMarks {  get; set; }
    }
}
