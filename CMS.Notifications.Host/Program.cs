using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;
using CMS.Notifications.Host.Jobs;
using CMS.Notifications.Host.Scheduler;
using Microsoft.Extensions.Configuration;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;

namespace CMS.Notifications.Host
{
    public partial class Program
    {
        private static void Main(string[] args)
        {
            Run().GetAwaiter().GetResult();

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }

        private static async Task Run()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = configurationBuilder.Build();

            FirebaseApp.Create();
            await SchedulerInitializer.Initialize(configuration);
        }
    }
}