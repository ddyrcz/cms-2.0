using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace Cms.AzureFunctions
{
    public static class WarmUpApi
    {
        [Function("WarmUpApi")]
        public static void Run([TimerTrigger("0 */5 * * * *")] MyInfo myTimer, FunctionContext context)
        {
            var httpClient = new HttpClient();
            
            HttpResponseMessage response = httpClient.GetAsync("https://cms-api-service.azurewebsites.net/api/cars").Result;
            response.EnsureSuccessStatusCode();

            var logger = context.GetLogger("WarmUpApi");

            logger.LogInformation($"WarmUpApi function executed at: {DateTime.Now}");
            logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
