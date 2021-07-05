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
        private static readonly Dictionary<string, int> countries = new();
        private static readonly Dictionary<string, int> genres = new();
        private readonly IApiKinopoisk _apiKinopoisk = new ApiKinopoisk();

        public async Task<Dictionary<string, int>> GetFilterDictionary(string type)
        {
            if (type == "countries")
            {
                if(countries == null)
                {
                    await CachingFiltersAsync();
                }
                return countries;
            }

            else if (type == "genres")
            {
                if (genres == null)
                {
                    await CachingFiltersAsync();
                }
                return genres;
            }
            else
            {
                throw new InvalidOperationException("Wrong filter type dictionary");
            }
        }

        private async Task CachingFiltersAsync()
        {
            var filters = await _apiKinopoisk.GetFilters();

                SortingFiltrationDictionaries(filters);
        }

        private static void SortingFiltrationDictionaries(FiltersModelResponse filters)
        {

            foreach (var country in filters.Countries)
            {
                countries.Add(country.Country, country.CountryId);
            }

            foreach (var genre in filters.Genres)
            {
                genres.Add(genre.Genre, genre.GenreId);
            }
        }
    }
}
