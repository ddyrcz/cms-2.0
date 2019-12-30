using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Quartz;

namespace CMS.Notifications.Host.Jobs
{
    class CheckForExpirationApproachingJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
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
                    // Send push notification.
                }
            }
        }
    }
}
