using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using Quartz;
using Quartz.Impl;
using SchedulerQuartz3.Modules;
using StackExchange.Redis;

namespace SchedulerQuartz3.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();
            
        public ValuesController()
        {
            
        }
        
        [HttpGet("Get")]
        public async Task Get()
        {
            await Planner.StartScheduler();

            _logger.Info("udałosię i do ");
        }


        [HttpGet("test")]
        public string Test()
        {
            return _logger.ToString();
        }

    }
}
