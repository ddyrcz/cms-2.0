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

                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

                var triggers = new[] {
                    TriggerBuilder.Create()
                        .StartNow()
                        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(12, 00).InTimeZone(timeZone))
                        .Build(),
                    TriggerBuilder.Create()
                        .StartNow()
                        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(20, 00).InTimeZone(timeZone))
                        .Build(),
                    TriggerBuilder.Create()
                        .StartNow()
                        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(16, 40).InTimeZone(timeZone))
                        .Build(),
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
