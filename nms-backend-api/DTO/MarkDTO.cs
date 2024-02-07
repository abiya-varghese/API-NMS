using nms_backend_api.Entity;

namespace nms_backend_api.DTO
{
    public class MarkDTO
    {
        public int MarkId { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public float Marks { get; set; }
        public Examination? examination { get; set; }
        public Student? student { get; set; }

    }
}
