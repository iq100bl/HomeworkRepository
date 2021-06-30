using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using films_to_weather.Apis.Entities;
using films_to_weather.Apis.YandexWeather.Entities;
using films_to_weather.common;
using Flurl;
using Flurl.Http;

namespace films_to_weather
{
    public class ApiKinopoisk : IApiKinopoisk
    {
        private const string ApiKeyToFilms = "ac388fc2-6be8-4f76-9354-215df2f9ed8c";
        private const string FilmsBaseApi = "https://kinopoiskapiunofficial.tech";
        private readonly string _filmsTop250Api = $"{FilmsBaseApi}/api/v2.2/films/top";
        private readonly string _filtersApi = $"{FilmsBaseApi}/api/v2.1/films/filters";
        private const string ApiKeyToWeathers = "7f10620d-29e4-45a5-9813-c93f4bcae666";
        private const string WeathersBaseApi = "https://api.weather.yandex.ru/v2/informers?";
        public async Task<FilmModel[]> GetTopFilms(int _page)
        {
            var rankedFilms = _filmsTop250Api
                .SetQueryParams(new
                {
                    type = "TOP_250_BEST_FILMS",
                    page = _page
                })
                .WithHeader("X-API-KEY", ApiKeyToFilms)
                .WithHeader("accept", "application/json");
            var topFilms = await CallApi(() => rankedFilms.GetJsonAsync<FilmTopResponse>());
            return topFilms.FilmTopResponse_Films.Select(Film => new FilmModel
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

        public async Task<FiltersModelResponse> GetFilters()
        {
            var filters = _filtersApi.WithHeader("X-API-KEY", ApiKeyToFilms).WithHeader("accept", "application/json");
            return await CallApi(() => filters.GetJsonAsync<FiltersModelResponse>());
        }

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
