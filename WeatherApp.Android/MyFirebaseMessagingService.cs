using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherApp.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        public MyFirebaseMessagingService()
        {

        }
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);
            if (!message.Data.GetEnumerator().MoveNext())
            {
                new NotificationHelper().CreateNotification(message.GetNotification().Title, message.GetNotification().Body);
            }
            else
            {
                string title, body;
                IDictionary<string, string> data = message.Data;

                data.TryGetValue("title", out title);
                data.TryGetValue("body", out body);

                new NotificationHelper().CreateNotification(title, body);
            }
            
        }
    }
}