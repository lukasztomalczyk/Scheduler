using System;
using System.Collections.Specialized;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace SchedulerQuartez2
{
    class Program
    {
        static async Task Main(string[] args)
        {
             Console.WriteLine(Directory.GetCurrentDirectory());

            ISchedulerFactory sf = new StdSchedulerFactory();
            
            IScheduler sched = await sf.GetScheduler();
            await sched.Start();

            IJobDetail job = JobBuilder.Create<ExampleJob>()
                    .WithIdentity("job1", "group1")
                    .Build();

            ISimpleTrigger trigger = (ISimpleTrigger) TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(5)
                .RepeatForever())
                .Build();
            
            await sched.ScheduleJob(job, trigger);
            
            Console.WriteLine("Write '1' to create file in checking directory to complite the job:");
            
            int caseSwitch = Convert.ToInt16(Console.ReadLine());
            
            if(caseSwitch == 1)
            {
                  CreateTheExpectedFile();
                  Console.ReadKey();
            }
            
            
            Console.ReadKey();
        }

        private static void CreateTheExpectedFile()
        {
            File.Create(Directory.GetCurrentDirectory()+"/SRC/test.txt");
        }
    }
}