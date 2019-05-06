using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Package.Service.Application;

namespace Package.Service.Implementation
{
    internal class LogService : ILogService
    {
        protected readonly IApplicationSettingService applicationSettingService;

        public LogService(IApplicationSettingService applicationSettingService)
        {
            this.applicationSettingService = applicationSettingService;
        }

        public void Log(string logFileName, string log)
        {
            var applicationLog = applicationSettingService.GetLogFolderPath();

            var filePath = string.Format(@"{0}\{1}{2}.txt", applicationLog, logFileName,
                DateTime.Now.ToString("yyyyMMdd"));

            using (var writer = System.IO.File.AppendText(filePath))
            {
                writer.WriteLine(log);
                writer.WriteLine(DateTime.Now);
            }
        }
    }
}