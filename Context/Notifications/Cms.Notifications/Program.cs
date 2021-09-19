using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using TimeZoneConverter;
using Microsoft.Extensions.Hosting;
using FirebaseAdmin;
using Cms.Notifications.Jobs;

namespace Cms.Notifications
{
    public class Prorgam
    {
        public static void Main(string[] args)
        {
            FirebaseApp.Create();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
           .ConfigureServices((hostContext, services) =>
           {
               services.AddLogging(configure => configure.AddConsole(opt =>
                {
                    opt.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
                }))
               .AddQuartz(q =>
               {
                   q.UseMicrosoftDependencyInjectionJobFactory();
                   q.ScheduleJob<CheckForExpirationApproachingJob>(trigger =>
                   {
                       var timeZone = TZConvert.GetTimeZoneInfo("Europe/Warsaw");

                       trigger.WithCronSchedule(CronScheduleBuilder.DailyAtHourAndMinute(09, 00).InTimeZone(timeZone));
                       trigger.WithCronSchedule(CronScheduleBuilder.DailyAtHourAndMinute(20, 00).InTimeZone(timeZone));
                   });
               })
               .AddQuartzHostedService(options =>
               {
                    options.WaitForJobsToComplete = true;
               });
           });
    }
}