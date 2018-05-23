using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Quartz;

namespace SchedulerQuartez2
{
    public class ExampleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            if(File.Exists(Directory.GetCurrentDirectory()+"/SRC/test.txt"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Files exists now!");
                Console.ResetColor();

            }
            return Task.CompletedTask;
        }
    }
}