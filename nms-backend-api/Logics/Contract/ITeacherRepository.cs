using nms_backend_api.Entity;

namespace nms_backend_api.Logics.Contract
{
    public interface ITeacherRepository
    {
        void Add(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(int id);
        Teacher GetTeacher(int id);
        List<Teacher> GetAll();
        List<Teacher> GetTeachersBySubject(string subject);
        List<Teacher> GetTeachersByClass(string class1);
    }
}
