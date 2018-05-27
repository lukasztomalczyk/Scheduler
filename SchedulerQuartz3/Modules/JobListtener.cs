using System.Threading;
using System.Threading.Tasks;
using NLog;
using Quartz;

namespace SchedulerQuartz3.Modules
{
    public class JobListtener : IJobListener
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Task JobToBeExecuted(IJobExecutionContext context,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public Task JobExecutionVetoed(IJobExecutionContext context,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException,
            CancellationToken cancellationToken = new CancellationToken())
        {
            logger.Info("Job Executed.");
        }

        public string Name => "JobListener";
    }
}