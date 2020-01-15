using System;
using System.Threading.Tasks;
using CMS.Notifications.Host.JobsScheduler.Jobs;
using Microsoft.Extensions.Configuration;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;

namespace CMS.Notifications.Host.JobsScheduler
{
    static class SchedulerInitializer
    {
        public static async Task Initialize(IConfiguration configuration)
        {
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

            var connectionString = configuration.GetConnectionString("CarsDbConnectionString");
            var notifyAboutExpirationDaysBefore = configuration.GetConnectionString("NotifyAboutExpirationDaysBefore");

            try
            {
                var factory = new StdSchedulerFactory();
                var scheduler = await factory.GetScheduler();

                await scheduler.Start();

                var checkForExpirationApproachingJob = JobBuilder.Create<CheckForExpirationApproachingJob>()
                    .WithIdentity("mainJob")
                    .UsingJobData("connectionString", connectionString)
                    .UsingJobData("notifyAboutExpirationDaysBefore", notifyAboutExpirationDaysBefore)
                    .Build();

                var triggers = new[] {
                    TriggerBuilder.Create()
                        .StartNow()
                        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(05, 00))
                        .Build(),
                    TriggerBuilder.Create()
                        .StartNow()
                        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(17, 00))
                        .Build(),
                    TriggerBuilder.Create()
                        .StartNow()
                        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(20, 00))
                        .Build()
                };

                await scheduler.ScheduleJob(checkForExpirationApproachingJob, triggers, false);
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }
    }
}
