using AutoMapper;
using nms_backend_api.DTO;
using nms_backend_api.Entity;

namespace nms_backend_api.Profiles
{
    public class TeacherAttendenceProfile:Profile
    {
        public TeacherAttendenceProfile() {
            CreateMap<TeacherAttendenceDTO, TeacherAttendence>();
            CreateMap<TeacherAttendence, TeacherAttendenceDTO>();
        }

    }
}
