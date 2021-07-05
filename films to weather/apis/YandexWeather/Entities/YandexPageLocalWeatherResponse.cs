using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace films_to_weather.Apis.YandexWeather.Entities
{
    public class YandexPageLocalWeatherResponse
    {
        [JsonProperty("url")]
        public string UrlLocalYandex { get; set; }
    }
}
