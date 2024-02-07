using nms_backend_api.DTO;
using nms_backend_api.Entity;

namespace nms_backend_api.Logics.Contract
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        List<StudentDto> GetAllStudent();

        StudentDto GetStudentByRoll(int rollno);

        List<StudentDto> GetStudentByClass(string cls);

        List<StudentDto> GetAllStudentsByClassandSec(string cls, string sec);


        Student GetStudentByName(string name);
        Student GetStudentById(int studid);

        void Update(Student student);
        void Delete(int id);

    }
}
