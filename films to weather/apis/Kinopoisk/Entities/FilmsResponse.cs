using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using films_to_weather.common;
using Newtonsoft.Json;

namespace films_to_weather.Apis.Entities
{
    public class FilmsResponse
    {
        [JsonProperty("films")]
        public FilmModelResponse[] FilmTopResponse_Films;
    }
}
