using System.Threading.Tasks;
using films_to_weather.Apis.YandexWeather.Entities;
using films_to_weather.common;

namespace films_to_weather
{
    public interface IApiWeather
    {
        Task<WeatherResponse> GetWeather();
    }
}
