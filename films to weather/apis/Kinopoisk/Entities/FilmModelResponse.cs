﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using films_to_weather.Apis.Entities;
using Newtonsoft.Json;

namespace films_to_weather.common
{
    public class FilmModelResponse
    {
        [JsonProperty("filmId")]
        public int FilmId { get; set; }

        [JsonProperty("nameRu")]
        public string NameRu { get; set; }

        [JsonProperty("nameEn")]
        public string NameEn { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }
        
        [JsonProperty("countries")]
        public CountryResponse[] Countries;

        [JsonProperty("genres")]
        public GenreResponse[] Genres { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("posterUrlPreview")]
        public string PosterUrlPreview { get; set; }
    }
}
