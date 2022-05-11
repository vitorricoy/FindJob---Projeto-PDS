using Backend.API.Controllers.Models;
using Backend.Domain.Entity;
using Backend.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class MessageController : ControllerBase
    {
        
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpGet]
        [Route("history")]
        public IActionResult GetHistory([FromQuery(Name = "userId1")] int userId1, [FromQuery(Name = "userId2")] int userId2)
        {
            try
            {
                return Ok(messageService.GetHistory(userId1, userId2));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("lastMessage")]
        public IActionResult GetLastMessage([FromQuery(Name = "userId1")] int userId1, [FromQuery(Name = "userId2")] int userId2)
        {
            try
            {
                return Ok(messageService.GetLastMessage(userId1, userId2));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateMessage([FromBody] CreateMessageInput input)
        {
            try
            {
                return Ok(messageService.CreateMessage(input.Text, input.SentTime, input.SenderId, input.ReceiverId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}