using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nms_backend_api.DTO;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Concrete;
using nms_backend_api.Logics.Contract;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace nms_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachAttendenceController : ControllerBase
    {
        private ITeacherAttendenceRepository _teacherAttendenceRepository;
        private readonly IMapper _mapper;
        public List<TeacherAttendence> classs = new List<TeacherAttendence>();
        public TeachAttendenceController(ITeacherAttendenceRepository teacherAttendenceRepository, IMapper mapper)
        {
            _teacherAttendenceRepository = teacherAttendenceRepository;
            _mapper = mapper;
        }

        //addattendence
        [HttpPost]
        [Route("AddAttendence")]
        public IActionResult AddTeachAttendence(TeacherAttendenceDTO data)
        {
            try
            {
                //  classRepository.Create(classes);
                //  return Ok(classes);
                var _class = _mapper.Map<TeacherAttendence>(data); //convert dto to entity


                if (ModelState.IsValid)
                {
                    _teacherAttendenceRepository.AddTeachAttendence(_class);

                    return Ok(_class);
                }

                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);

            }
        }

        //GetAllTeachAttendences
        [HttpGet]
        [Route("GetAllTeachAttendences")]
        public IActionResult GetAllTeachAttendences()
        {
            try
            {
                List<TeacherAttendence> teacher = _teacherAttendenceRepository.GetAllTeachAttendences();
                List<TeacherAttendenceDTO> teacherDTOs = _mapper.Map<List<TeacherAttendenceDTO>>(teacher);
                return Ok(teacherDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        //GetTeachAttendenceById
        [HttpGet]
        [Route("GetTeachAttendenceById/{id}")]

        public IActionResult GetTeachAttendenceById(string id)
        {
            try
            {
                var item = _teacherAttendenceRepository.GetTeachAttendenceById(id);


                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //getattendenceby date

        [HttpGet]
        [Route("GetattendenceBydate")]

        public IActionResult GetTeachersAttendencebyDate(DateTime date)
        {
            try
            {

                List<TeacherAttendence> item = _teacherAttendenceRepository.GetTeachersAttendencebyDate(date);


                List<TeacherAttendenceDTO> teacherDTOs = _mapper.Map<List<TeacherAttendenceDTO>>(item);
                return Ok(teacherDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);

            }
        }

        //edit 
        [HttpPut]
        [Route("Edit")]
        public IActionResult Update(TeacherAttendenceDTO data)
        {
            try
            {

                //classRepository.Update(class1);
                //return Ok(class1);
                var _class = _mapper.Map<TeacherAttendence>(data); //convert dto to entity


                if (ModelState.IsValid)
                {
                    _teacherAttendenceRepository.Update(_class);

                    return Ok(_class);
                }

                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);

            }
        }

        //delete 
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(string id)
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
