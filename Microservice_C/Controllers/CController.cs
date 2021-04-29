using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice_C.Logging;
using NLog;

namespace Microservice_C.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CController : ControllerBase
    {
        private readonly IMyLogger _myLogger;

        public CController(IMyLogger myLogger)
        {
            _myLogger = myLogger;
            _myLogger.Info("Constructed CController");
        }

        [HttpGet]
        public string Get()
        {
            _myLogger.Info("CController.Get");

            return "C";
        }
    }
}
