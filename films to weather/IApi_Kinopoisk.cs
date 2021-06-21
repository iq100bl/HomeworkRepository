using System.Threading.Tasks;
using films_to_weather.common;

namespace films_to_weather
{
    public interface IApi_Kinopoisk
    {
        Task<FilmModel[]> GetTopFilms(int _page);
    }
}
