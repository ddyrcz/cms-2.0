using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;

namespace CMS.Notifications.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.GetApplicationDefault(),
            });

            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = "Test title",
                    Body = "Test title"
                },
                Topic = "main"
            };

            string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;

            Console.WriteLine("Successfully sent message: " + response);
            Console.ReadKey();
        }
    }
}
