using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using Quartz;

namespace CMS.Notifications.Host.Jobs
{
    class CheckForExpirationApproachingJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                // TODO: Move to appsettings.json
                using (var connection = new SqlConnection("Server=localhost;Database=CMS;User Id=sa; Password=password123!;"))
                {
                    await connection.OpenAsync();
                    var query = @"SELECT * from CARS";

                    var cars = await connection.QueryAsync<Car>(query);

                    // TODO: Move to appsettings.json
                    int approachingExpirationDaysBefore = 14;

                    var carsWithExpirationApproaching =
                        cars.Where(car => car.IsExpirationApproaching(approachingExpirationDaysBefore));

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
                    Body = "Deadline is incoming",
                    Title = "Check the app!"
                },
                Topic = "main"
            };

            var messageInJsonFormat  = JsonConvert.SerializeObject(message, Formatting.Indented);

            var messageId = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            Console.WriteLine($"Successfully sent message '{messageId}' with payload: {Environment.NewLine}{messageInJsonFormat}");
        }
    }
}
