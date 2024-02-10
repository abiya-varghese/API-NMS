
using AutoMapper;
using nms_backend_api.DTO;
using nms_backend_api.Entity;

namespace nms_backend_api.Profiles
{
    public class MarkProfile:Profile
    {
        public MarkProfile() 
        {
            CreateMap<MarkDTO, Mark>();
            CreateMap<Mark, MarkDTO>();
        }
    }
}
