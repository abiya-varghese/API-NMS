using nms_backend_api.DTO;
using nms_backend_api.Entity;

namespace nms_backend_api.Logics.Contract
{
    public interface ITeacherRepository
    {
        void Add(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(string id);
        Teacher GetTeacher(string id);
        List<Teacher> GetAll();
        List<TeacherSubjectDTO> GetTeachersBySubject(string subject);
        List<Teacher> GetTeachersByClass(string class1);
    }
}
