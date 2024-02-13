using System.Reflection.Metadata;

namespace nms_backend_api.DTO
{
    public class ResultDisplay
    {
        public string ExamName { get; set; }
        public string StudentName { get; set; }
        public string StudentRoll { get; set; }
        public string className { get; set; }
        public string Section { get; set; }
        public string Subject { get; set; }
        public string Result { get; set; }
        public float mark { get; set; }
    }
}
