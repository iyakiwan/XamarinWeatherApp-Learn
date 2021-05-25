using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
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
                Log.Debug("HAIII", message.GetNotification().Body);
                new NotificationHelper().CreateNotification(message.GetNotification().Title, message.GetNotification().Body);
            }
            else
            {
                string[] weather = new string[10];
                string location, country, icon, name, desc, 
                    datetime, humidity, pressure, wind, temp;
                //string title, body;

                IDictionary<string, string> data = message.Data;

                data.TryGetValue("location", out weather[0]);
                data.TryGetValue("country", out weather[1]);
                data.TryGetValue("datetime", out weather[2]);
                data.TryGetValue("temp", out weather[3]);
                data.TryGetValue("icon", out weather[4]);
                data.TryGetValue("name", out weather[5]);
                data.TryGetValue("desc", out weather[6]);
                data.TryGetValue("humidity", out weather[7]);
                data.TryGetValue("pressure", out weather[8]);
                data.TryGetValue("wind", out weather[9]);

                Log.Debug("HAIII", weather[0]);

                new NotificationHelper().CreateNotification(message.GetNotification().Title, message.GetNotification().Body, weather);
            }
            
        }
    }
}