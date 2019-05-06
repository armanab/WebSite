using System;

namespace Package.Service.Implementation
{
    public interface ILogService
    {
        void Log(string logFileName, string log);
    }
}