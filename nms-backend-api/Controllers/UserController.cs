using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Concrete;
using nms_backend_api.Logics.Contract;
using nms_backend_api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace nms_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        //add
        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                if(_userRepository.CheckRegister(user.Role, user.AdmissionId))
                {
                    _userRepository.AddUser(user);
                    return Ok("User added Succesfully");
                }
                else
                {
                    return BadRequest($"No Id in {user.Role} Register");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //GetAll
        [HttpGet]
        [Route("GetAllUsers")]
        [AllowAnonymous]
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

        public IActionResult GetById(string id)
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
        [HttpGet]
        [Route("verifyemailandphone/{mail}/{phone}")]

        public IActionResult GetByMail(string mail, string phone)
        {
            try
            {
                return Ok(_userRepository.GetByMailAndPhone(mail,phone));
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

        [HttpPut]
        [Route("reset-password")]
        public IActionResult ResetPassword(ResetPasswordModel model)
        {
            try
            {
                var user = _userRepository.GetById(model.Email);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                // Update the user's password
                user.Password = model.NewPassword;
                _userRepository.UpdateUser(user);

                return Ok("Updated Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //delete 
        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                _userRepository.DeleteUser(id);
                return Ok("User deleted Succesfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("Validate")]
        [AllowAnonymous]
        public IActionResult ValidateUser(Login login)
        {
            try
            {
                User user = _userRepository.UserValidation(login);
                AuthResponse authReponse = new AuthResponse();
                if (user != null)
                {
                    authReponse.Emailid = user.Emailid;
                    authReponse.Role = user.Role;
                    authReponse.AdmissionId = user.AdmissionId;
                    authReponse.Token = GetToken(user);
                }
                return StatusCode(200, authReponse);
            }
            catch (Exception)
            {

                throw;
            }
        }
      
       
        private string GetToken(User? user)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            //header part
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature
            );
            //payload part
            var subject = new ClaimsIdentity(new[]
            {
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim(ClaimTypes.Role, user.Role),
                    });

            var expires = DateTime.UtcNow.AddMinutes(10);
            //signature part
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = expires,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }
        
    }
}
