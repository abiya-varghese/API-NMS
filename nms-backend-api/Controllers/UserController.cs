using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Concrete;
using nms_backend_api.Logics.Contract;

namespace nms_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //add
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            try
            {
                _userRepository.AddUser(user);
                return Ok("User added Succesfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //GetAll
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_userRepository.GetAllUsers());
            }
            catch (Exception)
            {

                throw;
            }
        }

        //GetById
        [HttpGet]
        [Route("GetById/{id}")]

        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_userRepository.GetById(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //edit 
        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                _userRepository.UpdateUser(user);
                return Ok("Updated Succesfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //delete 
        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userRepository.DeleteUser(id);
                return Ok("Attendence deleted Succesfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
