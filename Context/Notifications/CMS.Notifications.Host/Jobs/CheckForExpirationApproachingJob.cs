using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FirebaseAdmin.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Quartz;

namespace CMS.Notifications.Host.Jobs
{
    class CheckForExpirationApproachingJob : IJob
    {
        private readonly ILogger<CheckForExpirationApproachingJob> logger;
        private readonly IConfiguration configuration;

        public CheckForExpirationApproachingJob(
            ILogger<CheckForExpirationApproachingJob> logger,
            IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            logger.LogInformation($"Running job...");

            var connectionString = configuration.GetConnectionString("CarsDbConnectionString");
            var notificationDaysBefore = configuration.GetValue<int>("NotificationDaysBefore");
            
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

            logger.LogInformation($"Job completed.");
        }

        private async Task SendNotification(Car[] carsToReview)
        {
            var carsNames = string.Join(", ", carsToReview.Select(x => x.Name));

            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = "Powiadomienie",
                    Body = $"Zbliża się koniec terminu dla: {carsNames}"
                },
                Topic = "main"
            };

            var messageInJsonFormat = JsonConvert.SerializeObject(message, Formatting.Indented);
            var messageId = await FirebaseMessaging.DefaultInstance.SendAsync(message);

            logger.LogInformation($"Successfully sent message '{messageId}' with payload: {Environment.NewLine}{messageInJsonFormat}");
        }
    }
}
