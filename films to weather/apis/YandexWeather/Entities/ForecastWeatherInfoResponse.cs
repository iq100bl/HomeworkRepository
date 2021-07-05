using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace films_to_weather.Apis.YandexWeather.Entities
{
    public class ForecastWeatherInfoResponse
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("moon_text")]
        public string MoonText { get; set; }

        [JsonProperty("condition")]
        public PartsForecastWeatherResponse Condition { get; set; }
    }
}
