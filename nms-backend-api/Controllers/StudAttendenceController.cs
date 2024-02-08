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
    public class StudAttendenceController : ControllerBase
    {
        private IStudentAttendenceRepository _studentAttendenceRepository;
        private readonly IMapper _mapper;
        public List<StudentAttendence> classs = new List<StudentAttendence>();

        public StudAttendenceController(IStudentAttendenceRepository studentAttendenceRepository, IMapper mapper)
        {
            _studentAttendenceRepository = studentAttendenceRepository;
            _mapper = mapper;
        }

        //addattendence
        [HttpPost]
        [Route("AddAttendence")]
        public IActionResult AddStudAttendence(StudAttendanceDTO data)
        {
            try
            {
                //  classRepository.Create(classes);
                //  return Ok(classes);
                var _class = _mapper.Map<StudentAttendence>(data); //convert dto to entity


                if (ModelState.IsValid)
                {
                    _studentAttendenceRepository.AddStudAttendence(_class);

                    return Ok(_class);
                }

                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);

            }
        }

        //GetAllStudAttendances
        [HttpGet]
        [Route("GetAllAttendences")]
        public IActionResult GetAllStudAttendances()
        {
            try
            {
                List<StudentAttendence> student = _studentAttendenceRepository.GetAllStudAttendances();
                List<StudAttendanceDTO> studentDTOs = _mapper.Map<List<StudAttendanceDTO>>(student);
                return Ok(studentDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        //GetStudAttendenceById
        [HttpGet]
        [Route("GetStudAttendenceByAttendenceId/{attid}")]

        public IActionResult GetStudAttendenceById(string attid)
        {
            try
            {
                var item = _studentAttendenceRepository.GetStudAttendenceById(attid);


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

        public IActionResult GetStudentAttendencebyDate(DateTime date)
        {
            try
            {

                List<StudentAttendence> item = _studentAttendenceRepository.GetStudentAttendencebyDate(date);


                List<StudAttendanceDTO> studDTOs = _mapper.Map<List<StudAttendanceDTO>>(item);
                return Ok(studDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);

            }
        }

        //edit 
        [HttpPut]
        [Route("Edit")]
        public IActionResult Update(StudAttendanceDTO data)
        {
            try
            {

                //classRepository.Update(class1);
                //return Ok(class1);
                var _class = _mapper.Map<StudentAttendence>(data); //convert dto to entity


                if (ModelState.IsValid)
                {
                    _studentAttendenceRepository.Update(_class);

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
