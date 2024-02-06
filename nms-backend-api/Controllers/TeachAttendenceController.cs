using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Concrete;
using nms_backend_api.Logics.Contract;

namespace nms_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class TeachAttendenceController : ControllerBase
    {
        private ITeacherAttendenceRepository _teacherAttendenceRepository;
        public TeachAttendenceController(ITeacherAttendenceRepository teacherAttendenceRepository)
        {
            _teacherAttendenceRepository = teacherAttendenceRepository;
        }

        //addattendence
        [HttpPost]
        [Route("AddAttendence")]
        public IActionResult AddTeachAttendence(TeacherAttendence teachattendance)
        {
            try
            {
                _teacherAttendenceRepository.AddTeachAttendence(teachattendance);
                return Ok("Attendence added Succesfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //GetAllTeachAttendences
        [HttpGet]
        [Route("GetAllTeachAttendences")]
        public IActionResult GetAllTeachAttendences()
        {
            try
            {
                return Ok(_teacherAttendenceRepository.GetAllTeachAttendences());
            }
            catch (Exception)
            {

                throw;
            }
        }

        //GetTeachAttendenceById
        [HttpGet]
        [Route("GetTeachAttendenceById/{id}")]

        public IActionResult GetTeachAttendenceById(int id)
        {
            try
            {
                return Ok(_teacherAttendenceRepository.GetTeachAttendenceById(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
        //getattendenceby date

        [HttpGet]
        [Route("GetattendenceBydate")]

        public IActionResult GetTeachersAttendencebyDate(int date)
        {
            try
            {
                return Ok(_teacherAttendenceRepository.GetTeachersAttendencebyDate(date));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //edit 
        [HttpPut]
        [Route("Edit")]
        public IActionResult Update(TeacherAttendence teachattendance)
        {
            try
            {
                _teacherAttendenceRepository.Update(teachattendance);
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
                _teacherAttendenceRepository.Delete(id);
                return Ok("Attendence deleted Succesfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
