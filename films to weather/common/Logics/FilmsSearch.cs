using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using films_to_weather.Apis.Entities;
using films_to_weather.Apis.YandexWeather;
using films_to_weather.Apis.YandexWeather.Entities;
using films_to_weather.common;
using films_to_weather.Common.Caching;
using films_to_weather.Common.Entities;
using films_to_weather.Translator;
using Telegram.Bot;

namespace films_to_weather.Common.Logics
{
    public class FilmsSearch
    {
        private static readonly IApiKinopoisk _api_Kinopoisk = new ApiKinopoisk();
        private static readonly IApiWeather _apiWeather = new ApiWeather();
        private static readonly IFilterCasheService _filterCasheService = new FilterCasheService();
        private static readonly TelegramBotClient _botClient;
        private static readonly Library _library;
        private const string typeFilterGenres = "genres";

        public async Task<FilmModel[]> GetFilm()
        {
            var weather = await _apiWeather.GetWeather();
            var genres = await GetFitlr(weather.FactWeather.Condition, weather.FactWeather.Season, weather.FactWeather.Daytime);
            return await _api_Kinopoisk.SearchFilmByFilter(genres);
        }

        private async Task<int[]> GetFitlr(string paramOne, string paramTwo, string paramThree)
        {
            var fiters = await _filterCasheService.GetFilterDictionary(typeFilterGenres);
            var genres = new int[]
            {
                fiters[_library.Translator[paramOne]],
                fiters[_library.Translator[paramTwo]],
                fiters[_library.Translator[paramThree]]
            };
            return genres.Distinct().ToArray();
        }
    }
}
