using nms_backend_api.Entity;

namespace nms_backend_api.Logics.Contract
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        List<Student> GetAllStudent();

        Student GetStudentByName(string name);
        Student GetStudentById(int studid);

        void Update(Student student);
        void Delete(int id);
       
    }
}
