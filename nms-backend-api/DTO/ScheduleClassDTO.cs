namespace nms_backend_api.DTO
{
    public class ScheduleClassDTO
    {
        public string ScheduleId { get; set; }
        public string ClassId { get; set; }
        public string TeacherId { get; set; } = null;
        public string teachername { get; set; }
        public string Subject { get; set; }
        public string Sessiontime { get; set; }
        //public string FName { get; set; }


    }
}