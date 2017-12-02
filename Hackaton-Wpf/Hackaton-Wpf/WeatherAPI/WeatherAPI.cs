using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hackaton_Wpf.WeatherAPI
{
    class WeatherAPI
    {
        public string  City { get; set; }
        public string Lati { get; set; }
        public string Longi { get; set; }
        public WeatherForecast WeatherForecast { get; set; }

        public WeatherAPI(string lati, string longi)
        {
            Lati= lati;
            Longi = longi;
            WeatherForecast = DeserializeJson(GetJson());
            WeatherForecast.Currently.TemperatureToCelcius();
        }
        private string GetJson()
        {
            var url = "https://api.darksky.net/forecast/58220c5e622c109668c88539a8a27f73/"+Lati+","+Longi;
            var json = new WebClient().DownloadString(url);
            return json;
        }

        private WeatherForecast DeserializeJson(string json)
        {
            var weatheRequest = JsonConvert.DeserializeObject<WeatherForecast>(json);
            return weatheRequest;
        }
    }
}
