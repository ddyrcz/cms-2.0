using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FirebaseAdmin.Messaging;
using Newtonsoft.Json;
using Quartz;

namespace CMS.Notifications.Host.JobsScheduler.Jobs
{
    class CheckForExpirationApproachingJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var connectionString = context.JobDetail.JobDataMap.GetString("connectionString");
            var notifyAboutExpirationDaysBefore = context.JobDetail.JobDataMap.GetIntValue("NotifyAboutExpirationDaysBefore");

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var getCarsQuery = @"SELECT * from CARS";

                    var cars = await connection.QueryAsync<Car>(getCarsQuery);
                    var carsWithExpirationApproaching = cars.Where(car => car.IsExpirationApproaching(notifyAboutExpirationDaysBefore));

                    if (carsWithExpirationApproaching.Any())
                    {
                        await SendNotificationToFirebase();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task SendNotificationToFirebase()
        {
            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = "Powiadomienie",
                    Body = "Zbliża się koniec terminu ważności"
                },
                Topic = "main"
            };

            var messageInJsonFormat  = JsonConvert.SerializeObject(message, Formatting.Indented);
            var messageId = await FirebaseMessaging.DefaultInstance.SendAsync(message);

            Console.WriteLine($"Successfully sent message '{messageId}' with payload: {Environment.NewLine}{messageInJsonFormat}");
        }
    }
}
