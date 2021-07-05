using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using films_to_weather.Apis.Entities;
using Newtonsoft.Json;

namespace films_to_weather.common
{
    public class FiltersModelResponse
    {
        [JsonProperty("countries")]
        public CountryResponse[] Countries { get; set; }

        [JsonProperty("genres")]
        public GenreResponse[] Genres { get; set; }
    }
}
