using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nms_backend_api.Entity;

namespace nms_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly NotificationRepository notificationRepository;

        public NotificationController(NotificationRepository notificationRepository)
        {
            this.notificationRepository = notificationRepository;
        }

        [HttpPost, Route("AddNotification/")]
        public IActionResult Add([FromBody] Notification notification)
        {
            try
            {
                notificationRepository.Add(notification);
                return Ok(notification);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut, Route("EditNotification/")]
        public IActionResult Update([FromBody] Notification notification)
        {
            try
            {
                notificationRepository.Update(notification);
                return Ok(notification);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("GetNotification/")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(notificationRepository.GetAll());
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete, Route("DeleteNotification/")]
        public IActionResult Delete(string id)
        {
            try
            {
                notificationRepository.Delete(id);
                return Ok("Notification Deleted");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
