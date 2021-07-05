﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace films_to_weather.Translator
{
    public class Library
    {
        public readonly Dictionary<string, string> Translator = new()
        {
            { "clear", "мюзикл" },
            { "partly-cloudy", "приключения" },
            { "cloudy", "семейный" },
            { "overcast", "драма" },
            { "drizzle", "драма" },
            { "light-rain", "история" },
            { "rain", "детектив" },
            { "moderate-rain", "документальный" },
            { "heavy-rain", "триллер" },
            { "continuous-heavy-rain", "криминал" },
            { "showers", "фильм-нуар" },
            { "wet-snow", "мультфильм" },
            { "light-snow", "детский" },
            { "snow", "спорт" },
            { "snow-showers", "фэнтези" },
            { "hail", "военный" },
            { "thunderstorm", "боевик" },
            { "thunderstorm-with-rain", "боевик" },
            { "thunderstorm-with-hail", "приключения" },
            { "summer", "комедия" },
            { "autumn", "драма" },
            { "winter", "семейный" },
            { "spring", "мелодрама" },
            { "night ", "триллер" },
            { "morning ", "мультфильм" },
            { "day ", "комедия" },
            { "evening ", "фэнтези" },
            {"d", "комедия" },
            {"n", "драма" },
            { "moon-code-0 ", "ужасы" },
            { "moon-code-1 ", "аниме" },
            { "moon-code-2 ", "биография" },
            { "moon-code-3 ", "игра" },
            { "moon-code-4 ", "короткометражка" },
            { "moon-code-5 ", "фэнтези" },
            { "moon-code-6 ", "драма" },
            { "moon-code-7 ", "триллер" },
            { "moon-code-8 ", "фэнтези" },
            { "moon-code-9 ", "растущая луна" },
            { "moon-code-10 ", "мультфильм" },
            { "moon-code-11 ", "криминал" },
            { "moon-code-12 ", "первая четверть" },
            { "moon-code-13 ", "история" },
            { "moon-code-14 ", "приключения" },
            { "moon-code-15 ", "детский" }
        };
    }
}
