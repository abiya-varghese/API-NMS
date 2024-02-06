using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Concrete;
using nms_backend_api.Logics.Contract;

namespace nms_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudAttendenceController : ControllerBase
    {
        private IStudentAttendenceRepository _studentAttendenceRepository;
        public StudAttendenceController(IStudentAttendenceRepository studentAttendenceRepository)
        {
            _studentAttendenceRepository = studentAttendenceRepository;
        }

        //addattendence
        [HttpPost]
        [Route("AddAttendence")]
        public IActionResult AddStudAttendence(StudentAttendence studattendance)
        {
            try
            {
                _studentAttendenceRepository.AddStudAttendence(studattendance);
                return Ok("Attendence added Succesfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //GetAllStudAttendances
        [HttpGet]
        [Route("GetAllAttendences")]
        public IActionResult GetAllStudAttendances()
        {
            try
            {
                return Ok(_studentAttendenceRepository.GetAllStudAttendances());
            }
            catch (Exception)
            {

                throw;
            }
        }

        //GetStudAttendenceById
        [HttpGet]
        [Route("GetStudAttendenceById/{studid}")]

        public IActionResult GetStudAttendenceById(int studid)
        {
            try
            {
                return Ok(_studentAttendenceRepository.GetStudAttendenceById(studid));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //getattendenceby date

        [HttpGet]
        [Route("GetattendenceBydate")]

        public IActionResult GetStudentAttendencebyDate(DateTime date)
        {
            try
            {
                return Ok(_studentAttendenceRepository.GetStudentAttendencebyDate(date));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //edit 
        [HttpPut]
        [Route("Edit")]
        public IActionResult Update(StudentAttendence studattendance)
        {
            try
            {
                _studentAttendenceRepository.Update(studattendance);
                return Ok("Updated Succesfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //delete 
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _studentAttendenceRepository.Delete(id);
                return Ok("Attendence deleted Succesfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
