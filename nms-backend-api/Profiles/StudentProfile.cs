using AutoMapper;
using nms_backend_api.DTO;
using nms_backend_api.Entity;

namespace nms_backend_api.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentAddDto, Student>();
        }
    }
}
