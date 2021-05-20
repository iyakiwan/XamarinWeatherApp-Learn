using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Model
{
    public class ForecastData
    {
        [JsonProperty("cod")]
        public string Cod { get; set; }

        [JsonProperty("message")]
        public int Message { get; set; }

        [JsonProperty("cnt")]
        public int Cnt { get; set; }

        [JsonProperty("list")]
        public List<WaetherList> List { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }

    public class MainFor
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("sea_level")]
        public int SeaLevel { get; set; }

        [JsonProperty("grnd_level")]
        public int GrndLevel { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp_kf")]
        public double TempKf { get; set; }
    }

    public class WeatherFor
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class CloudsFor
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }

    public class WindFor
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public int Deg { get; set; }

        [JsonProperty("gust")]
        public double Gust { get; set; }
    }

    public class SysFor
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }

    public class Rain
    {
        [JsonProperty("3h")]
        public double T3h { get; set; }
    }

    public class WaetherList
    {
        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("main")]
        public MainFor Main { get; set; }

        [JsonProperty("weather")]
        public List<WeatherFor> Weather { get; set; }

        [JsonProperty("clouds")]
        public CloudsFor Clouds { get; set; }

        [JsonProperty("wind")]
        public WindFor Wind { get; set; }

        [JsonProperty("visibility")]
        public int Visibility { get; set; }

        [JsonProperty("pop")]
        public double Pop { get; set; }

        [JsonProperty("sys")]
        public SysFor Sys { get; set; }

        [JsonProperty("dt_txt")]
        public string DtTxt { get; set; }

        [JsonProperty("rain")]
        public Rain Rain { get; set; }
    }

    public class CoordFor
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }

    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public CoordFor Coord { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }

        [JsonProperty("timezone")]
        public int Timezone { get; set; }

        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }

        [JsonProperty("sunset")]
        public int Sunset { get; set; }
    }


    public class MergeData
    {
        public WeatherData DataWeather { get; set; }

        public ForecastData DataForecast { get; set; }
    }
}
