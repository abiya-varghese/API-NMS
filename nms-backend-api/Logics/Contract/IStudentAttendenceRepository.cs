using nms_backend_api.Entity;
using nms_backend_api.Models;

namespace nms_backend_api.Logics.Contract
{
    public interface IStudentAttendenceRepository
    {

        public List<StudentAttendence> AddStudAttendence(DateTime today, string classId, string section);

        List<StudentAttendence> GetAllStudAttendances();

        //StudentAttendence GetStudAttendenceByName(string name);
        StudentAttendence GetStudAttendenceById(string studid);

        List<StudentAttendence> GetStudentAttendencebyDate(DateTime date);

        void Update(StudentAttendence studattendance);
        void Delete(string id);
        public AttendenceModel AttendenceReportStudent(string id, DateTime month);
        public List<StudentAttendence> GetStudAttendenceByClassAndSection(DateTime today, string classId, string section);

    }
}
