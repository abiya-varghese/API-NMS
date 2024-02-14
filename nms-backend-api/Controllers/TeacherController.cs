using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nms_backend_api.DTO;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Concrete;
using nms_backend_api.Logics.Contract;
 
namespace nms_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMapper _mapper;
        public readonly ITeacherRepository teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository, IMapper mapper)
        {
            this.teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        [HttpGet, Route("GetAllTeacher")]
        public IActionResult GetAll()
        {
            try
            {
               List<Teacher> teachers= teacherRepository.GetAll();           
                return Ok(teachers);
                // return Ok(teacherRepository.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost, Route("AddTeacher")]
        public IActionResult AddTeacher(Teacher teacher)
        {
            try
            {
                teacherRepository.Add(teacher);
                return Ok(teacher);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut, Route("EditTeacher")]
        public IActionResult Edit(Teacher teacher)
        {
            try
            {
                teacherRepository.Update(teacher);
                return Ok(teacher);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete, Route("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                teacherRepository.Delete(id);
                return Ok("Teacher Deleted");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetTeachersById/{id}")]
        public IActionResult GetStaff(string id)
        {
            try
            {
                return Ok(teacherRepository.GetTeacher(id));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        //[HttpGet, Route("GetTeacherBySubject/{Subject}")]
        //public IActionResult GetAllBySubject(string subject)
        //{
        //    try
        //    {
        //        var teacher1 = teacherRepository.GetTeachersBySubject(subject);
        //        return Ok(teacher1);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        [HttpGet]
        [Route("GetTeachersByClass/{class1}")]
        public IActionResult GetTeachersByClass(string class1)
        {
            try
            {
                List<Teacher> teachers = teacherRepository.GetTeachersByClass(class1);
                List<TeacherClassDTO> teacherDTOs = _mapper.Map<List<TeacherClassDTO>>(teachers);
                return Ok(teacherDTOs);
                // return Ok(teacherRepository.GetTeachersByClass(class1));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }
        //[HttpGet, Route("GetAllTeacherByClass/{Class}")]
        //public IActionResult GetAllByclass(string class1)
        //{
        //    try
        //    {
        //        var teachr = (teacherRepository.GetTeachersByClass(class1));
        //        return Ok(teachr);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        [HttpGet]
        [Route("GetTeachersBySubject/{subject}")]
        public IActionResult GetTeachersBySubject(string subject)
        {
            try
            {
                List<TeacherSubjectDTO> teachers = teacherRepository.GetTeachersBySubject(subject);
                List<TeacherSubjectDTO> teacherDTOs = _mapper.Map<List<TeacherSubjectDTO>>(teachers);

                return Ok(teachers);
               // return Ok(teacherRepository.GetTeachersBySubject(subject));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}