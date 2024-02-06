using AutoMapper;
using nms_backend_api.DTO;
using nms_backend_api.Entity;


namespace nms_backend_api.Profiles
{
    public class ClassProfile:Profile
    {
        public ClassProfile()
        {
           CreateMap<ClassDTO, Class1>();
            CreateMap<Class1,ClassDTO>();
        }
    }
}
