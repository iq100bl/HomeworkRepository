﻿using System;
using System.Threading.Tasks;
using films_to_weather.Common.Caching;
using Telegram.Bot;

namespace films_to_weather
{
    class Program
    {
        private static readonly IApiKinopoisk _api_Kinopoisk = new ApiKinopoisk();
        private static readonly IFilterCasheService _filterCasheService = new FilterCasheService();
        private static TelegramBotClient _botClient;

        static async Task Main(string[] args)
        {
            //await _filterCasheService.CachingFiltersAsync();

            //var top250Films = await _api_Kinopoisk.GetTopFilms(1);

            //foreach(var film in top250Films)
            //Console.WriteLine(film.NameRu);

            var weather = await _api_Kinopoisk.GetWeather();
            Console.WriteLine(weather.ToString());
        }
    }
}
