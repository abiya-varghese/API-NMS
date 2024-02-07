using nms_backend_api.Entity;
using System.Security.Claims;

namespace nms_backend_api.Logics.Contract
{
    public interface IAssignClass
    {
        Teacher GetTeacherById(int teacherId);
         Class1 GetClassById(int classId);
        void AssignTeacherToClass(int classid, int teacherid);
    }
}
