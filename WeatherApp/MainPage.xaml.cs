using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Data;
using WeatherApp.Model;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;
        public WeatherData data = null;
        public IList<WaetherList> WeatherList { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
            data = new WeatherData();
            //List<string> items = new List<string> { "First", "Second", "Third", "First", "Second", "Third", "First", "Second", "Third", "First", "Second", "Third" };
            //listView.ItemsSource = items;
            btnDetail.Clicked += async (sender, e) =>
            {
                if (data != null)
                {
                    EntitiyData entitiyData = new EntitiyData();
                    entitiyData.Location = data.Title;
                    entitiyData.Country = data.Sys.Country;
                    entitiyData.DateTime = data.Dt;
                    entitiyData.Icon = data.Weather[0].Icon;
                    entitiyData.Temp = data.Main.Temperature;
                    entitiyData.Desc = data.Weather[0].Description;
                    entitiyData.Humidity = data.Main.Humidity;
                    entitiyData.Pressure = data.Main.Pressure;
                    entitiyData.Wind = data.Wind.Speed;

                    await Navigation.PushAsync(new DetailPage(data));
                }
                else
                {
                    await DisplayAlert("Alert", "Masukkan data yang sesuai", "OK");
                }
                
            };
        }

        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                loadingData.IsVisible = true;
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Constants.Endpoint, "/weather"));

                data = weatherData;

                BindingContext = data;

                listForecast.ItemsSource = await _restService.GetForecastData(GenerateRequestUri(Constants.Endpoint, "/forecast"));
                loadingData.IsVisible = false;
                Console.WriteLine("DEBUG - Button Clicked!");
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            WaetherList item = (WaetherList)e.SelectedItem;
            await Navigation.PushAsync(new DetailPage(item));
        }

        string GenerateRequestUri(string endpoint, string path)
        {
            string requestUri = endpoint;
            requestUri += path;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=metric"; // or units=metric
            requestUri += $"&APPID={Constants.APIKey}";
            return requestUri;
        }
    }
}
