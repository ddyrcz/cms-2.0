using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using CMS.Notifications.Host.Jobs;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;

namespace CMS.Notifications.Host
{
    public class Program
    {
        private static void Main(string[] args)
        {
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

            RunProgramRunExample().GetAwaiter().GetResult();

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }

        private static async Task RunProgramRunExample()
        {
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
                        .WithRepeatCount(0))
                    .Build();

                await scheduler.ScheduleJob(job, devTrigger);
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }

        // simple log provider to get something to the console
        private class ConsoleLogProvider : ILogProvider
        {
            public Logger GetLogger(string name)
            {
                return (level, func, exception, parameters) =>
                {
                    if (level >= LogLevel.Info && func != null)
                    {
                        Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] [" + level + "] " + func(), parameters);
                    }
                    return true;
                };
            }

            public IDisposable OpenNestedContext(string message)
            {
                throw new NotImplementedException();
            }

            public IDisposable OpenMappedContext(string key, string value)
            {
                throw new NotImplementedException();
            }
        }
    }
}