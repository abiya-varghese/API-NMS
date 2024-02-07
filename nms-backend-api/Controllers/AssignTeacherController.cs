using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nms_backend_api.Logics.Concrete;

namespace nms_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignTeacherController : ControllerBase
    {
        public readonly AssignClassRepository assignRepository;

        public AssignTeacherController(AssignClassRepository assignRepository)
        {
            this.assignRepository = assignRepository;
        }
        [HttpPost("assign-teacher-to-class")]
        public IActionResult AssignTeacherToClass(int teacherId, int classId)
        {
            try
            {
                // Call the repository method to assign the teacher to the class
                assignRepository.AssignTeacherToClass(teacherId, classId);
                return Ok("Teacher assigned to class successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while assigning teacher to class.");
            }

        }
    }
}
