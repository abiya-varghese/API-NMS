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

        [HttpPost, Route("AddTeachAttendence")]
        public IActionResult AddTeachAttendence(TeacherAttendenceDTO data)
        {
            try
            {
                _teacherAttendenceRepository.AddTeacherAttendence(data);
                return Ok("Teacher Attendence added Succesfully");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet, Route("GetAllAttendance")]
        public IActionResult GetAllTeacherAttendances()
        {
            try
            {
                return Ok(_teacherAttendenceRepository.GetAllTeachAttendences());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        

        [HttpGet]
        [Route("AttendenceReport/{date}/{id}")]
        public IActionResult AttendenceReport(string id, DateTime date)
        {
            try
            {
                return Ok(_teacherAttendenceRepository.AttendenceReportTeacher(id, date));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[HttpPost]
        //[Route("AddTRAttendenceAutogenerate/{date}")]
        //public IActionResult AddtrAttendence(DateTime today)
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
        //        List<TeacherAttendence> teacher = _teacherAttendenceRepository.AddTeacherAttendenceAutogenerate(today);
        //        List<TeacherAttendenceDTO> teacherDTOs = _mapper.Map<List<TeacherAttendenceDTO>>(teacher);
        //        return Ok(teacherDTOs);
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(404, ex.Message);

        //    }
        //}
    }
}
