using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using films_to_weather.Apis.YandexWeather.Entities;
using Flurl;
using Flurl.Http;

namespace films_to_weather.Apis.YandexWeather
{
    class ApiWeather :IApiWeather
    {
        private const string WeathersBaseApi = "https://api.weather.yandex.ru/v2/informers?";
        private const string ApiKeyToWeathers = "7f10620d-29e4-45a5-9813-c93f4bcae666";

        public async Task<WeatherResponse> GetWeather()
        {
            var localWeather = WeathersBaseApi.SetQueryParams(new
            {
                lat = "55.833333",
                lon = "37.616667"
            })
                .WithHeader("X-Yandex-API-Key", ApiKeyToWeathers);
            return await CallApi(() => localWeather.GetJsonAsync<WeatherResponse>());
        }

        private static async Task<T> CallApi<T>(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch (FlurlHttpException e) when (e.StatusCode == 404)
            {
                throw new InvalidOperationException("Inquiry not available");
            }
        }
    }
}
