using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CMS.Notifications.Host.JobsScheduler;
using Microsoft.Extensions.Configuration;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;

namespace CMS.Notifications.Host
{
    public class Prorgam
    {
        private static readonly AutoResetEvent _closing = new AutoResetEvent(false);

        public static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();

            Console.CancelKeyPress += OnExit;
            _closing.WaitOne();
        }

        private static async Task RunAsync()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            var configuration = configurationBuilder.Build();

            FirebaseApp.Create();
            await SchedulerInitializer.Initialize(configuration);
        }

        protected static void OnExit(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Exiting application...");
            _closing.Set();
        }
    }
}