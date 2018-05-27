using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Quartz;

namespace SchedulerQuartz3.Modules
{
    public class ExampleJob1 : IJob
    {
        private readonly ILogger<ExampleJob1> logger;
        
        public ExampleJob1(
            ILogger<ExampleJob1> logger)
        {
            this.logger = logger;
        }
        

        public async Task Execute(IJobExecutionContext context)
        {
            logger.LogInformation("wykonało się");
            await Task.FromResult(true);
        }
    }
}