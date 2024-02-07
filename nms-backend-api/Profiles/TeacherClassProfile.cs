using AutoMapper;
using nms_backend_api.DTO;
using nms_backend_api.Entity;
namespace nms_backend_api.Profiles
{
    public class TeacherClassProfile:Profile
    {
        public TeacherClassProfile() 
        {
            //CreateMap<TeacherDTO, Teacher>();
            CreateMap<Teacher, TeacherClassDTO>();
        }

    }
}
