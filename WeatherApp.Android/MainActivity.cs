using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Firebase.Iid;
using Android.Util;
using Android.Content;

namespace WeatherApp.Droid
{
    [Activity(Label = "WeatherApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Log.Debug("TOKEN", "Instance ID TOken: " + FirebaseInstanceId.Instance.Token);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var myIntent = Intent;
            if (myIntent.GetStringArrayExtra("DataWeather") != null)
            {
                string[] data = myIntent.GetStringArrayExtra("DataWeather");
                Log.Debug("HAIIIB", data[0]);
                LoadApplication(new App(myIntent.GetStringArrayExtra("DataWeather")));
            }
            else
            {
                LoadApplication(new App());
            }
            
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}