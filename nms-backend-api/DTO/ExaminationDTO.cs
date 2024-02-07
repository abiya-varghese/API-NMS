namespace nms_backend_api.DTO
{
    public class ExaminationDTO
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public int ClassId { get; set; }
        public string? SubjectName { get; set; }


    }
}
