using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Data;
using WeatherApp.Model;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        RestService restService;
        public EntitiyData data = null;
        public string lt, lg;
        public IList<WaetherList> WeatherList { get; private set; }

        public MainPage()
        {
            InitializeComponent();

            Title = "Weather App";

            restService = new RestService();
            btnDetail.Clicked += async (sender, e) =>
            {
                if (data != null)
                {
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
                EntitiyData entitiyData = await restService.GetWeatherData(GenerateRequestUri(Constants.Endpoint, "/weather"));

                data = entitiyData;

                BindingContext = data;

                listForecast.ItemsSource = await restService.GetForecastData(GenerateRequestUri(Constants.Endpoint, "/forecast"));
                loadingData.IsVisible = false;
                Console.WriteLine("DEBUG - Button Clicked!");
            }
        }

        async void OnGetLocationButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    lt = location.Latitude.ToString();
                    lg = location.Longitude.ToString();
                    //await DisplayAlert("Keterangan",$"Latitude: {location.Latitude}, Longitude: { location.Longitude}, Altitude: { location.Altitude}","OK");

                    loadingData.IsVisible = true;
                    EntitiyData entitiyData = await restService.GetWeatherData(GenerateRequestLatLon(Constants.Endpoint, "/weather", lt, lg));

                    data = entitiyData;

                    BindingContext = data;

                    listForecast.ItemsSource = await restService.GetForecastData(GenerateRequestLatLon(Constants.Endpoint, "/forecast", lt, lg));
                    loadingData.IsVisible = false;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Error", fnsEx.Message, "OK");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await DisplayAlert("Error", fneEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Error", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            EntitiyData item = (EntitiyData)e.SelectedItem;
            await Navigation.PushAsync(new DetailPage(item));
        }

        string GenerateRequestUri(string endpoint, string path)
        {
            string requestUri = endpoint;
            requestUri += path;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=metric";
            requestUri += $"&APPID={Constants.APIKey}";
            return requestUri;
        }

        string GenerateRequestLatLon(string endpoint, string path, string lat, string lon)
        {
            string requestUri = endpoint;
            requestUri += path;
            requestUri += $"?lat={lat}";
            requestUri += $"&lon={lon}";
            requestUri += "&units=metric";
            requestUri += $"&appid={Constants.APIKey}";
            return requestUri;
        }
    }
}
