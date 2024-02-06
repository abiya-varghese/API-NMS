using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;

namespace nms_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //add student
        [HttpPost]
        [Route("AddStudent")]
        public IActionResult AddStudent(Student student)
        {
            try
            {
                _studentRepository.AddStudent(student);
                return Ok("Student added Succesfully");
            }
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }

        //getstudent by id
        [HttpGet]
        [Route("GetStudentById/{studid}")]

        public IActionResult GetStudentById(int studid)
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
        public IActionResult Update(Student student)
        {
            try
            {
                _studentRepository.Update(student);
                return Ok("Updated Succesfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //delete books
        [HttpDelete]
        [Route("DeleteStudent")]
        public IActionResult Delete(int id)
        {
            try
            {
                _studentRepository.Delete(id);
                return Ok("Student deleted Succesfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
