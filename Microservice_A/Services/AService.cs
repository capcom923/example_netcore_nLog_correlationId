using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microservice_A.Logging;

namespace Microservice_A.Services
{
    public class AService : IAService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMyLogger _myLogger;

        public AService(IHttpClientFactory httpClientFactory, IMyLogger myLogger)
        {
            _httpClientFactory = httpClientFactory;
            _myLogger = myLogger;
            _myLogger.Info("Constructed AService");
        }

        public string Call()
        {
            var client = _httpClientFactory.CreateClient("AClient");
            try
            {
                var url = "http://localhost:60002/b";
                _myLogger.Info($"A starts to call B at {url}");
                var response = client.GetAsync(url).Result;
                _myLogger.Info("A call B successfully");
                return "A call " + response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                _myLogger.Info("A call B failed" + e.Message);
                return "A call B failed";
            }
        }
    }

    public interface IAService
    {
        string Call();
    }
}
