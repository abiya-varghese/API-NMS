using AutoMapper;
using nms_backend_api.DTO;
using nms_backend_api.Entity;

namespace nms_backend_api.Profiles
{
    public class ResultProfile:Profile
    {
        public ResultProfile() {
            
            CreateMap<Mark,ResultDisplay>();
        }
    }
}
