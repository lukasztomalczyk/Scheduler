using System;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Remotion.Linq.Clauses.ResultOperators;

namespace SchedulerQuartz3.Modules
{
    public static class Planner
    {
        
        public static async Task StartScheduler()
        {
            ISchedulerFactory stdSchedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await stdSchedulerFactory.GetScheduler();

            await scheduler.ScheduleJob(JobDetail(), Trigger());

            await scheduler.Start();
        }

        private static ITrigger Trigger()
        {
            return TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x =>
                    x.WithIntervalInSeconds(5)
                        .RepeatForever())
                .Build();
        }

        private static IJobDetail JobDetail()
        {
            return JobBuilder.Create<ExampleJob>()
                .WithIdentity("job1", "group1")
                .Build();
        }
    }
}