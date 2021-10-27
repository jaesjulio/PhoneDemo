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
    public class MessageInformationController : ControllerBase
    {
        private readonly IMessageInformationService _MessageInformationService;

        public MessageInformationController(IMessageInformationService MessageInformationService)
        {
            _MessageInformationService = MessageInformationService;
        }

        [HttpPost]
        [Route("SaveMessage")]
        public TaskResult SaveMessage(MessageInformation message)
        {

            return _MessageInformationService.Create(message);

        }
    }
}
