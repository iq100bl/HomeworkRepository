using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace films_to_weather.common
{
    public class FilmModel
    {
        public int FilmId { get; set; }

        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string Year { get; set; }

        public string[] Countries { get; set; }

        public string[] Genres { get; set; }

        public string Rating { get; set; }

        public string PosterUrlPreview { get; set; }
    }
}
