using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace films_to_weather.Common.Entities
{
    public class FactWeatherModel
    {
        public string UrlLocalYandex { get; set; }

        public decimal Temperature { get; set; }

        public string Condition { get; set; }

        public string Season { get; set; }

        public string Daytime { get; set; }

        public string Icon { get; set; }
    }
}
