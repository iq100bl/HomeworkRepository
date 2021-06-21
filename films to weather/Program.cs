using System;
using System.Threading.Tasks;

namespace films_to_weather
{
    class Program
    {
        private static readonly IApi_Kinopoisk _api_Kinopoisk = new Api_Kinopoisk();

        static async Task Main(string[] args)
        {
            var top250Films = await _api_Kinopoisk.GetTopFilms(1);
            foreach(var film in top250Films)
            Console.WriteLine(film.NameRu);
        }
    }
}
