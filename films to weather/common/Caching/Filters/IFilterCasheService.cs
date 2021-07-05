using System.Collections.Generic;
using System.Threading.Tasks;

namespace films_to_weather.Common.Caching
{
    public interface IFilterCasheService
    {
        Task<Dictionary<string, int>> GetFilterDictionary(string type);
    }
}
