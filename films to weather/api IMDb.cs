using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using films_to_weather.common;
using Flurl;
using Flurl.Http;

namespace films_to_weather
{
    public class Api_Kinopoisk : IApi_Kinopoisk
    {
        private const string ApiKey = "ac388fc2-6be8-4f76-9354-215df2f9ed8c";
        private const string FilmsBaseApi = "https://kinopoiskapiunofficial.tech";
        private readonly string FilmsTop250 = $"{FilmsBaseApi}/api/v2.2/films/top";

        public async Task<FilmModel[]> GetTopFilms(int _page)
        {
            var rankedFilms = FilmsTop250
                .SetQueryParams(new
                {
                    type = "TOP_250_BEST_FILMS",
                    page = _page
                })
                .WithHeader("X-API-KEY", ApiKey)
                .WithHeader("accept", "application/json");
            var topFilms = await CallApi(() => rankedFilms.GetJsonAsync<FilmTopResponse_films[]>());
            return topFilms.Select(Film => new FilmModel
            {
                Countries = Film.Countries,
                FilmId = Film.FilmId,
                Genres = Film.Genres,
                NameEn = Film.NameEn,
                NameRu = Film.NameRu,
                PosterUrlPreview = Film.PosterUrlPreview,
                Rating = Film.Rating,
                Year = Film.Year
            }).ToArray();
        }
        private static async Task<T> CallApi<T>(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch (FlurlHttpException e) when (e.StatusCode == 404)
            {
                throw new InvalidOperationException("Currency not available");
            }
        }
    }
}
