using nms_backend_api.DTO;
using nms_backend_api.Entity;
using AutoMapper;

namespace nms_backend_api.Profiles
{
    public class StudentAttenceProfile:Profile
    {
        public StudentAttenceProfile() {

            CreateMap<StudAttendanceDTO, StudentAttendence>();
            CreateMap<StudentAttendence, StudAttendanceDTO>();
        }
    }
}
