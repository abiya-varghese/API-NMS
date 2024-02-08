using nms_backend_api.Entity;

namespace nms_backend_api.DTO
{
    public class MarkDTO
    {
        public string MarkId { get; set; }
        public string StudentId { get; set; }
        public string ExamId { get; set; }
        public float Marks { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ExamName { get; set; }
        public string? SubjectName { get; set; }
        public string ClassName { get; set; }


    }
}
