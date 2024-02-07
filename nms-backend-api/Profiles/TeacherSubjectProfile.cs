using AutoMapper;
using nms_backend_api.DTO;
using nms_backend_api.Entity;
namespace nms_backend_api.Profiles
{
    public class TeacherSubjectProfile:Profile
    {
        public TeacherSubjectProfile() 
        {
            //CreateMap<TeacherDTO, Teacher>();
            CreateMap<Teacher, TeacherSubjectDTO>();
        }
    }
}
