using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using films_to_weather.Apis.Entities;
using films_to_weather.common;

namespace films_to_weather.Common.Caching
{
    public class FilterCasheService : IFilterCasheService
    {
        private static readonly Dictionary<int, string> countries = new();
        private static readonly Dictionary<int, string> genres = new();
        private readonly IApiKinopoisk _apiKinopoisk = new ApiKinopoisk();

        public async Task CachingFiltersAsync()
        {
            var filters = await _apiKinopoisk.GetFilters();

                SortingFiltrationDictionaries(filters);
        }

        private static void SortingFiltrationDictionaries(FiltersModelResponse filters)
        {

            foreach (var country in filters.Countries)
            {
                countries.Add(country.CountryId, country.Country);
            }

            foreach (var genre in filters.Genres)
            {
                genres.Add(genre.GenreId, genre.Genre);
            }
        }
    }
}
