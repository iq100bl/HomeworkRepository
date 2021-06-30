using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace films_to_weather.Apis.Entities
{
    public class GenreResponse
    {
        [JsonProperty("id")]
        public int GenreId { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }
    }
}
