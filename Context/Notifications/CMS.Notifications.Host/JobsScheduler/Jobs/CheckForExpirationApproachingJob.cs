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
            var notificationDaysBefore = context.JobDetail.JobDataMap.GetIntValue("notificationDaysBefore");

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var getCarsQuery = @"SELECT * from CARS";

                    var cars = await connection.QueryAsync<Car>(getCarsQuery);

                    var carsToReview = cars.Where(car =>
                        car.IsExpirationApproaching(notificationDaysBefore) ||
                        car.IsInstallmentApproaching(notificationDaysBefore)).ToArray();

                    if (carsToReview.Length > 0)
                    {
                        await SendNotification(carsToReview);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task SendNotification(Car[] carsToReview)
        {
            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = "Powiadomienie",
                    Body = "Zbliża się koniec terminu dla: " + string.Join(", ", carsToReview.Select(x => x.Name).ToArray())
                },
                Topic = "main"
            };

            var messageInJsonFormat = JsonConvert.SerializeObject(message, Formatting.Indented);
            var messageId = await FirebaseMessaging.DefaultInstance.SendAsync(message);

            Console.WriteLine($"Successfully sent message '{messageId}' with payload: {Environment.NewLine}{messageInJsonFormat}");
        }
    }
}
