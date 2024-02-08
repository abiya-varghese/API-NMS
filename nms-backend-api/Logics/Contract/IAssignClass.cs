using nms_backend_api.Entity;
using System.Security.Claims;

namespace nms_backend_api.Logics.Contract
{
    public interface IAssignClass
    {
        Teacher GetTeacherById(string teacherId);
         Class1 GetClassById(string classId);
        void AssignTeacherToClass(string classid, string teacherid);
    }
}
