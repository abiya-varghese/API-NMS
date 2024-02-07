using nms_backend_api.Entity;

namespace nms_backend_api.Logics.Contract
{
    public interface ITeacherAttendenceRepository
    {

        void AddTeachAttendence(TeacherAttendence teachattendance);
        List<TeacherAttendence> GetAllTeachAttendences();

        //StudentAttendence GetStudAttendenceByName(string name);
        TeacherAttendence GetTeachAttendenceById(int id);

        List<TeacherAttendence> GetTeachersAttendencebyDate(DateTime date);
        void Update(TeacherAttendence teachattendance);
        void Delete(int id);

    }
}
