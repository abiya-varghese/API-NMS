using AutoMapper;
using nms_backend_api.DTO;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;

namespace nms_backend_api.Logics.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyContext _context;
        private readonly IMapper mapper;
        public StudentRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
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
        public List<StudentDto> GetAllStudent()
        {
            List<Student> student = _context.students.ToList();
            List<StudentDto> studentDto = mapper.Map<List<StudentDto>>(student);
            int i = 0;
            foreach (var s in studentDto)
            {              
                s.ClassName = (from c in _context.class1
                         where c.ClassId == student[i].ClassId
                         select c.ClassName).Single();
                i++;
            }
            return (studentDto);
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
        public StudentDto GetStudentById(string studid)
        {
            try
            {
               var stud= _context.students.Find(studid);
                StudentDto studentDto = mapper.Map<StudentDto>(stud);
                studentDto.ClassName = (from c in _context.class1
                               where c.ClassId == stud.ClassId
                               select c.ClassName).Single();
                return studentDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //update
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
        public void Delete(string id)
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

        //get student by roll number

        public StudentDto GetStudentByRoll(string rollno)
        {
            Student student = _context.students.SingleOrDefault(e => e.Rollno == rollno);
            StudentDto sdto = mapper.Map<StudentDto>(student);

            sdto.ClassName = (from c in _context.class1
                        where c.ClassId == student.ClassId
                        select c.ClassName).Single();
            return sdto;
        }

        //getstudentbyclass
        public List<StudentDto> GetStudentByClass(string cls)
        {
            List<Student> student = _context.students.Where(S => S.Class.ClassName == cls).ToList();
            List<StudentDto> studentDto = mapper.Map<List<StudentDto>>(student);

            foreach (var s in studentDto)
            {
                int i = 0;
                s.ClassName = (from c in _context.class1
                         where c.ClassId == student[i].ClassId
                         select c.ClassName).Single();
                i++;
            }
            return (studentDto);
        }

        //get student by class and section

        public List<StudentDto> GetAllStudentsByClassandSec(string cls, string sec)
        {
            List<Student> student = _context.students.
                Where(s => s.Class.ClassName == cls && s.Class.Section == sec).ToList();

            List<StudentDto> studentDto = mapper.Map<List<StudentDto>>(student);
            foreach (var s in studentDto)
            {
                int i = 0;
                s.ClassName = (from c in _context.class1
                         where c.ClassId == student[i].ClassId
                         select c.ClassName).Single();
                i++;
            }
            return (studentDto);
        }

       
    }
}
