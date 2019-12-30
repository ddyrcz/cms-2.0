using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using CMS.Notifications.Host.Jobs;
using CMS.Notifications.Host.Scheduler;
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
            FirebaseApp.Create();
            await SchedulerInitializer.Initialize();
        }
    }
}