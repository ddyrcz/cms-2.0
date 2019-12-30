using System;
using System.Threading.Tasks;
using CMS.Notifications.Host.Jobs;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;

namespace CMS.Notifications.Host.Scheduler
{
    static class SchedulerInitializer
    {
        public static async Task Initialize()
        {
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

            try
            {
                var factory = new StdSchedulerFactory();
                var scheduler = await factory.GetScheduler();

                await scheduler.Start();

                var job = JobBuilder.Create<CheckForExpirationApproachingJob>()
                    .WithIdentity("mainJob")
                    .Build();

                var dailyTrigger = TriggerBuilder.Create()
                    .WithIdentity("daily")
                    .StartNow()
                    .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(11, 32))
                    .Build();

                var devTrigger = TriggerBuilder.Create()
                    .WithIdentity("dev")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(3)
                        .WithRepeatCount(5))
                    .Build();

                await scheduler.ScheduleJob(job, devTrigger);
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }
    }
}
