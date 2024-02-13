using nms_backend_api.DTO;
using nms_backend_api.Entity;
using nms_backend_api.Models;

namespace nms_backend_api.Logics.Contract
{
    public interface ITeacherAttendenceRepository
    {

        // void AddTeachAttendence(TeacherAttendence teachattendance);
        List<TeacherAttendence> GetAllTeachAttendences();


        TeacherAttendence GetTeachAttendenceById(string id);

        List<TeacherAttendence> GetTeachersAttendencebyDate(DateTime date);
        void Update(TeacherAttendence teachattendance);
        void Delete(string id);
        public AttendenceModel AttendenceReportTeacher(string id, DateTime month);
        //public List<TeacherAttendence> AddTeacherAttendenceAutogenerate(DateTime today);
        void AddTeacherAttendence(TeacherAttendenceDTO data);
    }
}
