using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneAppBackend.Core.Models;
using PhoneAppBackend.Core.Services;

namespace PhoneAppBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly ISystemSettingService _systemSettingService;

        public SystemController(ISystemSettingService systemSettingService) 
        {
            _systemSettingService = systemSettingService;
        }

        [HttpGet]
        [Route("Settings")]
        public SystemSetting Settings(int id)
        {

            return _systemSettingService.GetById(id);

        }

    }
}