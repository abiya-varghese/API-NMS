namespace nms_backend_api.Models
{
    public class AuthResponse
    {
        public int UserId { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
