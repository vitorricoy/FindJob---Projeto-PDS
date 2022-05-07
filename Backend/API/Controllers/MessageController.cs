using Backend.Domain.Entity;
using Backend.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/message/[controller]")]
    public class MessageController : ControllerBase
    {
        
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpGet(Name = "history")]
        public IActionResult GetHistory(int userId1, int userId2)
        {
            try
            {
                return Ok(messageService.GetHistory(userId1, userId2));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet(Name = "lastMessage")]
        public IActionResult GetLastMessage(int userId1, int userId2)
        {
            try
            {
                return Ok(messageService.GetLastMessage(userId1, userId2));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost()]
        public IActionResult CreateMessage(string text, DateTime sentTime, int senderId, int receiverId)
        {
            try
            {
                return Ok(messageService.CreateMessage(text, sentTime, senderId, receiverId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}