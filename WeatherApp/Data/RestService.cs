using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.Data
{
    public class RestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<EntitiyData> GetWeatherData(string query)
        {
            EntitiyData entitiyData = null;
            try
            {
                var response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(content);

                    entitiyData = new EntitiyData
                    {
                        Location = weatherData.Title,
                        Country = weatherData.Sys.Country,
                        DateTime = weatherData.Dt,
                        Temp = weatherData.Main.Temperature,
                        Icon = weatherData.Weather[0].Icon,
                        Name = weatherData.Weather[0].Visibility,
                        Desc = weatherData.Weather[0].Description,
                        Humidity = weatherData.Main.Humidity,
                        Pressure = weatherData.Main.Pressure,
                        Wind = weatherData.Wind.Speed
                    };
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }

            return entitiyData;
        }

        public async Task<List<EntitiyData>> GetForecastData(string query)
        {
            List<EntitiyData> list = null;
            try
            {
                var response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ForecastData forecastData = JsonConvert.DeserializeObject<ForecastData>(content);

                    list = new List<EntitiyData>();

                    for (int i = 0; i < forecastData.List.Count; i++)
                    {
                        if (i % 8 == 7)
                        {
                            EntitiyData entitiyData = new EntitiyData
                            {
                                Location = forecastData.City.Name,
                                Country = forecastData.City.Country,
                                DateTime = forecastData.List[i].Dt,
                                Temp = forecastData.List[i].Main.Temp,
                                Icon = forecastData.List[i].Weather[0].Icon,
                                Name = forecastData.List[i].Weather[0].Main,
                                Desc = forecastData.List[i].Weather[0].Description,
                                Humidity = forecastData.List[i].Main.Humidity,
                                Pressure = forecastData.List[i].Main.Pressure,
                                Wind = forecastData.List[i].Wind.Speed
                            };
                            list.Add(entitiyData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }

            return list;
        }
    }
}
