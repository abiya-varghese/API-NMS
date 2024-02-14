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
        //[HttpPost]
        //[Route("AddAttendence/{today}/{classId}/{section}")]
        //public IActionResult AddStudAttendence(DateTime today, string classId, string section)
        //{
        //    try
        //    {
        //        //  classRepository.Create(classes);
        //        //  return Ok(classes);
        //        //var _class = _mapper.Map<StudentAttendence>(data); //convert dto to entity


        //        //if (ModelState.IsValid)
        //        //{
        //        //    _studentAttendenceRepository.AddStudAttendence(_class);

        //        //    return Ok(_class);
        //        //}

        //        //return new JsonResult("Something went wrong") { StatusCode = 500 };
        //        List<StudentAttendence> student = _studentAttendenceRepository.AddStudAttendence(today, classId, section);
        //        List<StudAttendanceDTO> studentDTOs = _mapper.Map<List<StudAttendanceDTO>>(student);
        //        return Ok(studentDTOs);
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(404, ex.Message);

        //    }
        //}
        [HttpPost, Route("AddStudentAttendence")]
        public IActionResult AddStudentAttendence(StudAttendanceDTO data)
        {
            try
            {
                _studentAttendenceRepository.AddStudentAttendence(data);
                return Ok("Student Attendence added Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);
            }
        }
        //GetAllStudAttendances
        //}
        [HttpGet, Route("GetAllAttendence")]
        public IActionResult GetAllStudentAttendances()
        {
            try
            {
                return Ok(_studentAttendenceRepository.GetAllStudAttendances());
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);
            }
        }
       
        [HttpGet]
        [Route("AttendenceReport/{date}/{id}")]
        public IActionResult AttendenceReport(string id, DateTime date)
        {
            try
            {
                return Ok(_studentAttendenceRepository.AttendenceReportStudent(id, date));

            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
    }
}
