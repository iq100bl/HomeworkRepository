using System.Threading.Tasks;

namespace films_to_weather.Common.Caching
{
    public interface IFilterCasheService
    {
        Task CachingFiltersAsync();
    }
}
