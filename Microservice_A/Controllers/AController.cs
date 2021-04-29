using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice_A.Logging;
using Microservice_A.Services;
using NLog;

namespace Microservice_A.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AController : ControllerBase
    {
        private readonly IMyLogger _myLogger;
        private readonly IAService _aService;

        public AController(IMyLogger myLogger, IAService aService)
        {
            _myLogger = myLogger;
            _aService = aService;
            _myLogger.Info("Constructed AController");
        }

        [HttpGet]
        public string Get()
        {
            _myLogger.Info("AController.Get");

            var result = _aService.Call();

            return $"Get result [{result}] at {DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff zzz")}";
        }
    }
}
