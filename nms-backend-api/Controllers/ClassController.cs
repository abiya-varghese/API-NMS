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
    public class ClassController : ControllerBase
    {
        private readonly IMapper _mapper;
       // public List<Class1> classs = new List<Class1>();


        public ClassRepository classRepository;
        public ClassController(ClassRepository classRepository,IMapper mapper)
        {
            this.classRepository = classRepository;
            this._mapper = mapper;
        }
        [HttpGet, Route("GetAllClass")]
        //public IActionResult getAll()
        //{
        //    try
        //    {
        //        return Ok(classRepository.GetAll());
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public IActionResult getAll()
        {
            try
            {
                List<Class1> class1 = classRepository.GetAll();
                List<ClassDTO> classDTOs = _mapper.Map<List<ClassDTO>>(class1);
                return Ok(classDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
        [HttpGet, Route("GetClassByClassName/{name}")]
        public IActionResult getClassByName(string name)
        {
            try
            {

                var item = classRepository.GetClassBySemName(name);
               ClassDTO classDTOs = _mapper.Map<ClassDTO>(item);
                return Ok(classDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);

            }
        }
        [HttpGet, Route("GetClassByTeacherName/{name}")]
        public IActionResult getClassByTrName(string name)
        {
            try
            {

                var item = classRepository.GetClassByTeacherName(name);


                ClassDTO classDTOs = _mapper.Map<ClassDTO>(item);
                return Ok(classDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);

            }
        }
        //public IActionResult getClassByName(string name)
        //{
        //    try
        //    {
        //        return Ok(classRepository.GetClassBySemName(name));
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        [HttpPost, Route("AddClass")]
        public IActionResult Add(ClassDTO data)
        {
            try
            {
                //  classRepository.Create(classes);
                //  return Ok(classes);
                var _class = _mapper.Map<Class1>(data); //convert dto to entity
                

                if (ModelState.IsValid)
                {
                    classRepository.Create(_class);

                    return Ok(_class);
                }

                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            catch (Exception ex )
            {

                return StatusCode(404, ex.Message);

            }
        }
        [HttpPut, Route("UpdateClass")]
        public IActionResult Edit(ClassDTO data)
        {
            try
            {

                //classRepository.Update(class1);
                //return Ok(class1);
                 var _class = _mapper.Map<Class1>(data); //convert dto to entity
                

                if (ModelState.IsValid)
                {
                    classRepository.Update(_class);

                    return Ok(_class);
                }

                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);

            }


        }
        [HttpDelete, Route("deleteClass/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                classRepository.Delete(id);
                return Ok("class deleted");
               
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);

            }

        }
    }
}
