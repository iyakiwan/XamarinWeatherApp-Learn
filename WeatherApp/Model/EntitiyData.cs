using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Model
{
    public class EntitiyData
    {
        public string Location { get; set; }

        public string Country { get; set; }

        public long DateTime { get; set; }

        public double Temp { get; set; }
        
        public string Icon { get; set; }

        public string Desc { get; set; }

        public long Humidity { get; set; }

        public long Pressure { get; set; }

        public double Wind { get; set; }
    }
}
