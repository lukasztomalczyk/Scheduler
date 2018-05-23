using System;
using System.Globalization;
using System.Threading.Tasks;
using Quartz;

namespace SchedulerQuartez2
{
    public class ExampleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("To jest przykładowe zadanie");
            return Task.CompletedTask;
        }
    }
}