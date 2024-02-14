using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nms_backend_api.DTO;
using nms_backend_api.Entity;
using nms_backend_api.Logics;
using nms_backend_api.Logics.Concrete;
using nms_backend_api.Logics.Contract;
using nms_backend_api.Models;
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
        public List<Mark> mark = new List<Mark>();
        private readonly MyContext _context;
        public ExaminationController(ExaminationRepository examinationrepository, IMapper mapper, MyContext context)
        {
            _examinationrepository = examinationrepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost, Route("ScheduleExam")]
        public IActionResult Add(ExaminationDTO examination)
        {
            try
            {
                //  classRepository.Create(classes);
                //  return Ok(classes);
                var exam = _mapper.Map<Examination>(examination); //convert dto to entity
                ExaminationDTO examinationDTOs = _mapper.Map<ExaminationDTO>(exam);

                if (ModelState.IsValid)
                {
                    _examinationrepository.Add(exam);

                    return Ok(examinationDTOs);
                }

                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);

            }
        }
        [HttpGet, Route("GetAllExam")]
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
        [HttpGet, Route("GetExamByExamId/{examId}")]
        public IActionResult GetExamByExamId(string examId)
        {
            try
            {
                var item = _examinationrepository.GetExamByExamId(examId);
               ExaminationDTO examinationDTOs = _mapper.Map<ExaminationDTO>(item);

                if (item == null)
                    return NotFound();

                return Ok(examinationDTOs);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("GetExamByClassId/{ClassId}")]
        public IActionResult GetExamByClassId(string ClassId)
        {
            try
            {

                List<Examination> item = _examinationrepository.GetExamByClassId(ClassId);


                List<ExaminationDTO> examDTOs = _mapper.Map<List<ExaminationDTO>>(item);
                return Ok(examDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);

            }
        }
        [HttpPut, Route("EditExamination")]
        public IActionResult Update([FromBody] ExaminationDTO examination)
        {
            try
            {
                //classRepository.Update(class1);
                //return Ok(class1);
                var exam = _mapper.Map<Examination>(examination); //convert dto to entity
                ExaminationDTO examinationDTOs = _mapper.Map<ExaminationDTO>(exam);


                if (ModelState.IsValid)
                {
                    _examinationrepository.UpdateExam(exam);

                    return Ok(examinationDTOs);
                }

                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);

            }
        }
        [HttpDelete, Route("DeleteExam/{examId}")]
        public IActionResult Delete(string examId)
        {
            _examinationrepository.DeleteExam(examId);
            return Ok("Examination deleted");
        }
        [HttpPost, Route("RecordResult")]
        public IActionResult RecordResult([FromBody] MarkDTO mark)
        {
            try
            {
                //  classRepository.Create(classes);
                //  return Ok(classes);
                var exam = _mapper.Map<Mark>(mark); //convert dto to entity
                MarkDTO markDTOs = _mapper.Map<MarkDTO>(exam);

                if (ModelState.IsValid)
                {
                    _examinationrepository.RecordResult(exam);

                    return Ok(markDTOs);
                }

                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);

            }
        }
        [HttpGet, Route("GetAllResult")]
        public IActionResult GetAllResult()
        {
            try
            {
                List<Mark> mark = _examinationrepository.GetAllResult();
                List<MarkDTO> markDTOs = _mapper.Map<List<MarkDTO>>(mark);
                return Ok(markDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
        [HttpGet, Route("GetAllResultByStudId/{studId}")]
        public IActionResult GetAllResultByStudId(string studId)
        {
            try
            {
                List<Mark> item = _examinationrepository.GetAllResultByStudId(studId);


                List<MarkDTO> markDTOs = _mapper.Map<List<MarkDTO>>(item);
                return Ok(markDTOs);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("GetAllResultByExamId/{examId}")]
        public IActionResult GetAllResultByExamId(string examId)
        {
            try
            {

                List<Mark> item = _examinationrepository.GetAllResultByExamId(examId);


                List<MarkDTO> markDTOs = _mapper.Map<List<MarkDTO>>(item);
                return Ok(markDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);

            }
        }
        [HttpPut, Route("UpdateResult")]
        public IActionResult UpdateResult([FromBody] MarkDTO mark)
        {
            try
            {
                //classRepository.Update(class1);
                //return Ok(class1);
                var mar = _mapper.Map<Mark>(mark); //convert dto to entity
                MarkDTO markDTOs = _mapper.Map<MarkDTO>(mar);


                if (ModelState.IsValid)
                {
                    _examinationrepository.UpdateResult(mar);

                    return Ok(markDTOs);
                }

                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);

            }
        }
        [HttpDelete, Route("DeleteResult/{markId}")]
        public IActionResult DeleteResult(string markId)
        {
            _examinationrepository.DeleteResult(markId);
            return Ok("Examination deleted");
        }
        [HttpGet, Route("GetMarkByMarkId/{markid}")]
        public IActionResult GetMarkByMarkId(string markid)
        {
            try
            {
                var item = _examinationrepository.GetMarkByMarkId(markid);
                MarkDTO markDTOs = _mapper.Map<MarkDTO>(item);

                if (item == null)
                    return NotFound();

                return Ok(markDTOs);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("GetAllResultByStudIdAndExamId/{studId}/{ExamId}")]
        public IActionResult GetResultByStudentIdExamID(string studId,string ExamId)
        {
            try
            {
                List<Mark> item = _examinationrepository.GetResultByStudentIdExamID(studId, ExamId);


                List<MarkDTO> markDTOs = _mapper.Map<List<MarkDTO>>(item);
                return Ok(markDTOs);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("GetResultStudentby/{id}")]
        public IActionResult GetByStudentId(string id)
        {
            try
            {
                List<Mark> r1 = _examinationrepository.GetAllResultByStudId(id);
                List<ResultDisplay> resultDTO = _mapper.Map<List<ResultDisplay>>(r1);


                int i = 0;
                foreach (var item in resultDTO)
                {
                    item.ExamName = (from e in _context.examination
                                     where e.ExamId == r1[i].ExamId
                    select e.ExamName).Single();


                    item.StudentName = (from e in _context.students
                                        where e.StudentId == r1[i].StudentId
                                        select e.FirstName + " " + e.LastName).Single();


                    item.StudentRoll = (from e in _context.students
                                        where e.StudentId == r1[i].StudentId
                                        select e.Rollno).Single();


                    item.className = (from e in _context.students
                                      where e.StudentId == r1[i].StudentId
                                      select e.Class.ClassName).Single();


                    item.Section = (from e in _context.students
                                    where e.StudentId == r1[i].StudentId
                                    select e.Class.Section).Single();


                    item.Subject = (from e in _context.examination
                                    where e.SubjectName == r1[i].SubjectName                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
                                    select e.SubjectName).Single();
                    item.mark = (from e in _context.mark
                                 where e.MarkId == r1[i].MarkId
                                 select e.Marks).Single();
                    item.Result = item.mark >= 40 ? "Pass" : "Fail";

                    i++;
                }


                ResultReport resultReport = new ResultReport();

                // resultReport.stdResults = resultDTO;
                resultReport.stdDisplay = resultDTO;
                float totalmark = 0;


                foreach (var item in resultDTO)
                {
                    totalmark += item.mark;
                    //if (item.Mark >= 40)
                    //{
                    //    item.Result = "Pass";
                    //}
                    //else
                    //{
                    //    item
                    //}
                }
                resultReport.totalMarks = totalmark.ToString();
                resultReport.Percentage = ((totalmark / (float)resultDTO.Count())).ToString();
                return Ok(resultReport);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);

            }
        }
    }
}
