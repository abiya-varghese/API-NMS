using nms_backend_api.Entity;
using nms_backend_api.Models;

namespace nms_backend_api.Logics.Contract
{
    public interface IStudentAttendenceRepository
    {

        void AddStudAttendence(StudentAttendence studattendance);
        List<StudentAttendence> GetAllStudAttendances();

        //StudentAttendence GetStudAttendenceByName(string name);
        StudentAttendence GetStudAttendenceById(string studid);

        List<StudentAttendence> GetStudentAttendencebyDate(DateTime date);

        void Update(StudentAttendence studattendance);
        void Delete(string id);
        public AttendenceModel AttendenceReportStudent(string id, DateTime month);
    }
}
