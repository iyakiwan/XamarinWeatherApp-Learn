using System;
using WeatherApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    public partial class App : Application
    {
        public App(string[] data = null)
        {
            InitializeComponent();

            if (data != null)
            {
                EntitiyData entitiyData = new EntitiyData
                {
                    Location = data[0],
                    Country = data[1],
                    DateTime = long.Parse(data[2]),
                    Temp = double.Parse(data[3]),
                    Icon = data[4],
                    Name = data[5],
                    Desc = data[6],
                    Humidity = long.Parse(data[7]),
                    Pressure = long.Parse(data[8]),
                    Wind = double.Parse(data[9])
                };
                MainPage = new NavigationPage(new DetailPage(entitiyData));
            } 
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
