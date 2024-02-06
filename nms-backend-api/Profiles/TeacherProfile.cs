using AutoMapper;
using nms_backend_api.DTO;
using nms_backend_api.Entity;

namespace nms_backend_api.Profiles
{
    public class TeacherProfile:Profile
    {
        public TeacherProfile()
        {
            CreateMap<TeacherDTO, Teacher>();
            CreateMap<Teacher, TeacherDTO>();
        }
    }
}
