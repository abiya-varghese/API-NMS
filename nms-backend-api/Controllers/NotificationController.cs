﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Concrete;

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
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);
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
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);
            }
        }
        [HttpGet, Route("GetNotification/")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(notificationRepository.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);
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
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);
            }
        }
    }
}
