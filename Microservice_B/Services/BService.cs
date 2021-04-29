using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microservice_B.Logging;

namespace Microservice_B.Services
{
    public class BService : IBService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMyLogger _myLogger;

        public BService(IHttpClientFactory httpClientFactory, IMyLogger myLogger)
        {
            _httpClientFactory = httpClientFactory;
            _myLogger = myLogger;
            _myLogger.Info("Constructed BService");
        }

        public string Call()
        {
            var client = _httpClientFactory.CreateClient("BClient");
            try
            {
                var url = "http://localhost:60003/c";
                _myLogger.Info($"B starts to call C at {url}");
                var response = client.GetAsync(url).Result;
                _myLogger.Info("B call C successfully");
                return "B call " + response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                _myLogger.Info("B call C failed" + e.Message);
                return "B call C failed";
            }
        }
    }

    public interface IBService
    {
        string Call();
    }
}
