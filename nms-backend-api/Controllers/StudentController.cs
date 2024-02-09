using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nms_backend_api.DTO;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;

namespace nms_backend_api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class StudentController : ControllerBase
    //{
    //    private IStudentRepository _studentRepository;
    //    public StudentController(IStudentRepository studentRepository)
    //    {
    //        _studentRepository = studentRepository;
    //    }

    //    //add student
    //    [HttpPost]
    //    [Route("AddStudent")]
    //    public IActionResult AddStudent(Student student)
    //    {
    //        try
    //        {
    //            _studentRepository.AddStudent(student);
    //            return Ok("Student added Succesfully");
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    //getallstudents
    //    [HttpGet]
    //    [Route("GetAllStudents")]
    //    public IActionResult GetAllStudent()
    //    {
    //        try
    //        {
    //            return Ok(_studentRepository.GetAllStudent());
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    //getstudent by id
    //    [HttpGet]
    //    [Route("GetStudentById/{studid}")]

    //    public IActionResult GetStudentById(int studid)
    //    {
    //        try
    //        {
    //            return Ok(_studentRepository.GetStudentById(studid));
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    //getstudent by classid


    //    //edit student
    //    [HttpPut]
    //    [Route("EditStudent")]
    //    public IActionResult Update(Student student)
    //    {
    //        try
    //        {
    //            _studentRepository.Update(student);
    //            return Ok("Updated Succesfully");
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    //delete books
    //    [HttpDelete]
    //    [Route("DeleteStudent")]
    //    public IActionResult Delete(int id)
    //    {
    //        try
    //        {
    //            _studentRepository.Delete(id);
    //            return Ok("Student deleted Succesfully");
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>();
        private readonly IMapper _mapper;

        private IStudentRepository _studentRepository;
        public StudentController(IMapper mapper, IStudentRepository studentRepository)
        {
            //_studentRepository = studentRepository;
            this._mapper = mapper;
            this._studentRepository = studentRepository;
        }

        //add student
        [HttpPost]
        [Route("AddStudent")]
        public IActionResult AddStudent(StudentAddDto studentdto)
        {
            try
            {
                Student students = _mapper.Map<Student>(studentdto);

                if (ModelState.IsValid)
                {
                    _studentRepository.AddStudent(students);
                    return Ok(students);
                }
                return new JsonResult("something went wrong here")
                { StatusCode = 500 };
            }
            //_studentRepository.AddStudent(student);
            // return Ok("Student added Succesfully");

            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }



        //getallstudents
        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult GetAllStudent()
        {
            try
            {
                return Ok(_studentRepository.GetAllStudent());
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occured while processing your request...");
            }
        }

        //getstudent by rollno:
        [HttpGet]
        [Route("GetStudentByRoll/{roll}")]

        public IActionResult GetStudentByRoll(string roll)
        {
            try
            {
                StudentDto student = _studentRepository.GetStudentByRoll(roll);
                if (student == null)
                {
                    return NotFound($"Student with roll number{roll} is not found");
                }
                return Ok(student);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        //get student by class
        [HttpGet]
        [Route("GetAllStudentByClass/{cls}")]

        public IActionResult GetStudentByClass(string cls)
        {
            try
            {
                List<StudentDto> students = _studentRepository.GetStudentByClass(cls);
                if (students == null)
                {
                    return NotFound($"Student with class{cls} is not found");
                }
                return Ok(students);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


        //get student by class and sect
        [HttpGet]
        [Route("GetAllStudentsByClassandSec/{cls}/{sec}")]

        public IActionResult GetAllStudentsByClassandSec(string cls, string sec)
        {
            try
            {
                List<StudentDto> students = _studentRepository.GetAllStudentsByClassandSec(cls, sec);
                if (students == null)
                {
                    return NotFound($"Student with class{cls}and section {sec} is not found");
                }
                return Ok(students);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }



        //getstudent by id
        [HttpGet]
        [Route("GetStudentById/{studid}")]

        public IActionResult GetStudentById(string studid)
        {
            try
            {
                return Ok(_studentRepository.GetStudentById(studid));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //getstudent by classid


        //edit student
        [HttpPut]
        [Route("EditStudent")]
        public IActionResult Update(StudentAddDto studentdto)
        {
            try
            {
                Student student = _mapper.Map<Student>(studentdto);
                if (ModelState.IsValid)
                {
                    _studentRepository.Update(student);
                    return Ok(student);
                }
                return new JsonResult("something went wrong")
                { StatusCode = 500 };
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        //delete books
        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _studentRepository.Delete(id);
                return Ok("Student deleted Succesfully");
            }
            catch (Exception)
            {

                return StatusCode(500, "An errorb occured while processing your request.");
            }
        }
    }
}
