using System;
using System.Collections.Specialized;
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

//            for (int i = 0; i < 50; i++)
//            {
//               Thread.Sleep(100);
//                Console.WriteLine(i);
//            }
            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler sched = await sf.GetScheduler();

            IJobDetail job = JobBuilder.Create<ExampleJob>()
                    .WithIdentity("job1", "group1")
                    .Build();

            ISimpleTrigger trigger = (ISimpleTrigger) TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(1)
                .RepeatForever())
                .Build();
            
            await sched.ScheduleJob(job, trigger);
            Thread.Sleep(1000);
            Console.ReadKey();
        }
    }
}