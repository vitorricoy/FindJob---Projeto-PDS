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

        [HttpGet(Name = "")]
        public Message Get()
        {
            return new Message();
        }
    }
}