using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneAppBackend.Core.Framework;
using PhoneAppBackend.Core.Models;
using PhoneAppBackend.Core.Services;

namespace PhoneAppBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        [Route("SendMessage")]
        public TaskResult SendMessage(Message message)
        {

            return _messageService.CreateandSend(message);

        }

        [HttpGet]
        [Route("GetMessages")]
        public List<Message> GetMessages()
        {
            return _messageService.GetMessages().ToList();
        }
    }
}
