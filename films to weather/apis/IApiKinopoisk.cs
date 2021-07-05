using System.Threading.Tasks;
using films_to_weather.Apis.YandexWeather.Entities;
using films_to_weather.common;

namespace films_to_weather
{
    public interface IApiKinopoisk
    {
        Task<FilmModel[]> GetTopFilms(int _page);

        Task<FiltersModelResponse> GetFilters();

        Task<FilmModel[]> SearchFilmByFilter(int[] genres);
    }
}
