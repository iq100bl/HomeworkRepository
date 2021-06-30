using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace films_to_weather.Translator
{
    public class Library
    {
        public readonly Dictionary<string, string> translator = new Dictionary<string, string>
        {
            { "clear", "ясно" },
            { "partly-cloudy", "малооблачно" },
            { "cloudy", "облачно с прояснениями" },
            { "overcast", "пасмурно" },
            { "drizzle", "морось" },
            { "light-rain", "небольшой дождь" },
            { "rain", "дождь" },
            { "moderate-rain", "умеренно сильный дождь" },
            { "heavy-rain", "сильный дождь" },
            { "continuous-heavy-rain", "длительный сильный дождь" },
            { "showers", "ливень" },
            { "wet-snow", "дождь со снегом" },
            { "light-snow", "небольшой снег" },
            { "snow", "снег" },
            { "snow-showers", "снегопад" },
            { "hail", "град" },
            { "thunderstorm", "гроза" },
            { "thunderstorm-with-rain", "дождь с грозой" },
            { "thunderstorm-with-hail", "гроза с градом" },
            { "summer", "лето" },
            { "autumn", "осень" },
            { "winter", "зима" },
            { "spring", "весна" },
            { "night ", "ночь" },
            { "morning ", "утро" },
            { "day ", "день" },
            { "evening ", "вечер" },
            {"d", "светлое время суток" },
            {"n", "темное время суток" },
            { "moon-code-0 ", "полнолуние" },
            { "moon-code-1 ", " убывающая луна" },
            { "moon-code-2 ", " убывающая луна" },
            { "moon-code-3 ", " убывающая луна" },
            { "moon-code-4 ", " последняя четверть" },
            { "moon-code-5 ", "убывающая луна" },
            { "moon-code-6 ", "убывающая луна" },
            { "moon-code-7 ", "убывающая луна" },
            { "moon-code-8 ", "новолуние" },
            { "moon-code-9 ", "растущая луна" },
            { "moon-code-10 ", "растущая луна" },
            { "moon-code-11 ", "растущая луна" },
            { "moon-code-12 ", "первая четверть" },
            { "moon-code-13 ", "растущая луна" },
            { "moon-code-14 ", "растущая луна" },
            { "moon-code-15 ", "растущая луна" }
        };
    }
}
