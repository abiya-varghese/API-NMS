namespace nms_backend_api.Models
{
    public class AttendenceModel
    {
        public string Percentage {  get; set; }
        public string TotalPresentDays {  get; set; }
        public string TotalAbsentDays { get; set;}
        public string TotalWorkingDays { get; set; }
    }
}
