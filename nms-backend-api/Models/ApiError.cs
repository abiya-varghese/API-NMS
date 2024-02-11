namespace nms_backend_api.Models
{
    public class ApiError:Exception
    {
        public ApiError(string? message)
        {
            Message = message;
        }

        public string? Message { get; set; }
    }

}
