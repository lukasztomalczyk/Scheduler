using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using NLog.Fluent;
using Quartz;

namespace SchedulerQuartz3.Modules
{
    public class ExampleJob : IJob
    {
        private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        private bool _isFile = false;
        
        public Task Execute(IJobExecutionContext context)
        {
            if(File.Exists(Directory.GetCurrentDirectory()+"/SRC/test.txt"))
            {
                _isFile = true;
                LoggerExecutedJob();
            }
            
            return Task.FromResult(true);
        }

        private void LoggerExecutedJob()
        {
            if (!_isFile)
            {
                _logger.Error("File not found.");
            }
            else
            {
                _logger.Error("File Found");
            }
        }

    }
}
