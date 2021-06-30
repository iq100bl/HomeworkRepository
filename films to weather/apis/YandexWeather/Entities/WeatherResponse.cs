using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace films_to_weather.Apis.YandexWeather.Entities
{
    public class WeatherResponse
    {
        [JsonProperty("now_dt")]
        public DateTime DTNow { get; set; }

        [JsonProperty("info")]
        public YandexPageLocalWeatherResponse InfoWeather { get; set; }

        [JsonProperty("fact")]
        public FactWeatherInfoResponse FactWeather { get; set; }

        [JsonProperty("forecast")]
        public ForecastWeatherInfoResponse ForecastWeather { get; set; }

    }
}
