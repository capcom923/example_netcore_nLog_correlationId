using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice_B.Logging;
using Microservice_B.Services;
using NLog;

namespace Microservice_B.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BController : ControllerBase
    {
        private readonly IMyLogger _myLogger;
        private readonly IBService _bService;

        public BController(IMyLogger myLogger, IBService bService)
        {
            _myLogger = myLogger;
            _bService = bService;
            _myLogger.Info("Constructed BController");
        }

        [HttpGet]
        public string Get()
        {
            _myLogger.Info("BController.Get");

            var result = _bService.Call();

            return result;
        }
    }
}
