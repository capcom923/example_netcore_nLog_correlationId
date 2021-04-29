
using System;

namespace Microservice_B.Logging
{
    public interface IMyLogger
    {
        string Info(string s);
        string Error(string s);
        string Error(string s, Exception ex);
    }
}