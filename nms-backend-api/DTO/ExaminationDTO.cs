namespace nms_backend_api.DTO
{
    public class ExaminationDTO
    {
        public string ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public string ClassId { get; set; }
        public string? SubjectName { get; set; }


    }
}
