using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nms_backend_api.DTO;
using nms_backend_api.Entity;
using nms_backend_api.Logics;
using nms_backend_api.Logics.Concrete;
using nms_backend_api.Logics.Contract;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace nms_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly ExaminationRepository _examinationrepository;
        private readonly IMapper _mapper;
        public List<Examination> exam = new List<Examination>();

        public ExaminationController(ExaminationRepository examinationrepository,IMapper mapper)
        {
            _examinationrepository = examinationrepository;
            _mapper = mapper;
        }

        [HttpPost,Route("ScheduleExam")]
        public IActionResult Add([FromBody] ExaminationDTO examination)
        {
            try
            {
                //  classRepository.Create(classes);
                //  return Ok(classes);
                var exam = _mapper.Map<Examination>(examination); //convert dto to entity


                if (ModelState.IsValid)
                {
                    _examinationrepository.Add(exam);

                    return Ok(exam);
                }

                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);

            }
    }
        [HttpGet,Route("GetAllExam")]
        public IActionResult GetAll()
        {
            try
            {
                List<Examination> examinations = _examinationrepository.GetAll();
                List<ExaminationDTO> examinationDTOs = _mapper.Map<List<ExaminationDTO>>(examinations);
                return Ok(examinationDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
        [HttpGet,Route("GetExamByExamId/{examId}")] 
        public IActionResult GetExamByExamId(int examId) 
        {
            try
            {

                var item = exam.FirstOrDefault(x => x.ExamId == examId);


                ExaminationDTO examDTOs = _mapper.Map<ExaminationDTO>(item);
                return Ok(examDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);

            }
        }
        [HttpGet, Route("GetExamByClassId/{ClassId}")]
        public IActionResult GetExamByClassId(int ClassId)
        {
            try
            {

                var item = exam.FirstOrDefault(x => x.Class.ClassId == ClassId);


                ExaminationDTO examDTOs = _mapper.Map<ExaminationDTO>(item);
                return Ok(examDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);

            }
        }
        [HttpPut,Route("EditExamination")]
        public IActionResult Update([FromBody] ExaminationDTO examination)
        {
            try
            {

                //classRepository.Update(class1);
                //return Ok(class1);
                var exam = _mapper.Map<Examination>(examination); //convert dto to entity


                if (ModelState.IsValid)
                {
                    _examinationrepository.UpdateExam(exam);

                    return Ok(exam);
                }

                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);

            }

        }
        [HttpDelete,Route("DeleteExam/{examId}")]
        public IActionResult Delete(int examId)
        {
            _examinationrepository.DeleteExam(examId);
            return Ok("Examination deleted");
        }
    }
}
