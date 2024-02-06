using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;

namespace nms_backend_api.Logics.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyContext _context;
        public StudentRepository(MyContext context)
        {
            _context = context;
        }
       
        //add student
        public void AddStudent(Student student)
        {
            try
            {
                _context.students.Add(student);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //get all students
        public List<Student> GetAllStudent()
        {
            try
            {
                return _context.students.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Student GetStudentByName(string name)
        {
            try
            {
                var stds = _context.students.SingleOrDefault(
                    x => x.FirstName == name);

                return stds;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //get students by id
        public Student GetStudentById(int studid)
        {
            try
            {
                return _context.students.Find(studid);
            }
            catch (Exception)
            {

                throw;
            }
        }

       


        public void Update(Student student)
        {
            try
            {
                _context.Update(student);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Delete(int id)
        {
            try
            {
                Student student = _context.students.Find(id);
                _context.students.Remove(student);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
