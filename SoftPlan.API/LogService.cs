using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftPlan.API
{
    public interface ILogService
    {
        public void WriteLog(string message);
    }
    public class LogService : ILogService
    {
        public ILogger Logger { get; set; }
        public void WriteLog(string message)
        {
            Logger.LogInformation(string.Concat(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message));
        }
    }
}
