using NLog;
using System;

namespace Microservice_A.Logging
{
    public class MyLogger : IMyLogger
    {
        NLog.Logger _logger;

        public MyLogger()
        {
            _logger = LogManager.GetLogger("Microservice_A");
        }

        public string Info(string s)
        {
            s = s.Replace("\n"," ").Replace("\r"," ");
            _logger.Info(s);
            return s;
        }
        public string Error(string s)
        {
            s = s.Replace("\n"," ").Replace("\r"," ");
            _logger.Error(s);
            return s;
        }

        public string Error(string s, Exception ex)
        {
            var se = $"{s} - Exception {ex.ToString()}";
            Error(se);
            return se;
        }


    }
}