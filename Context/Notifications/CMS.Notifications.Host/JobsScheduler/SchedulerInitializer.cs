﻿using System;
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

                var job = JobBuilder.Create<CheckForExpirationApproachingJob>()
                    .WithIdentity("mainJob")
                    .UsingJobData("connectionString", connectionString)
                    .UsingJobData("notifyAboutExpirationDaysBefore", notifyAboutExpirationDaysBefore)
                    .Build();

                var devTrigger = TriggerBuilder.Create()
                    .WithIdentity("dev")
                    .StartNow()
                    .WithSimpleSchedule()
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
