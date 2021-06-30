using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using films_to_weather.Apis.Entities;

namespace films_to_weather.common
{
    public class FiltersModel
    {
        public CountryResponse[] Countries { get; set; }

        public GenreResponse[] Genres { get; set; }
    }
}
