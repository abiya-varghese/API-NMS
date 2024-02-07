using AutoMapper;
using nms_backend_api.DTO;
using nms_backend_api.Entity;

namespace nms_backend_api.Profiles
{
    public class AssignClassProfile:Profile
    {
        public AssignClassProfile() {
            CreateMap<AssignClass,AssignClassDTO>();
            CreateMap<AssignClassDTO, AssignClass>();
        }
    }
}
