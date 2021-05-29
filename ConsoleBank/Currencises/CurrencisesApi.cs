using System;
using System.Threading.Tasks;
using Currencises.Entities;
using Currencises.Exceptions;
using Flurl;
using Flurl.Http;
using System.Linq;

namespace Currencises
{
    public class CurrencisesApi : ICurrencisesApi
    {
        private const string CurrencyRatesApiUrl = "https://www.nbrb.by/api/exrates/rates";
        private const string CurrenciesApiUrl = "https://www.nbrb.by/api/exrates/currencies";
        private readonly string[] abbreviation = { "RUB", "EUR", "UAH", "USD", "PLN" };
        private DateTime denomination = new DateTime(2016,06,30);

        public Task<Currency[]> GetCurrencises()
        {
            return CallApi(() => CurrenciesApiUrl.GetJsonAsync<Currency[]>());            
        }

        public Task<CurrencyRate> GetCurrencyRate(int currencyId)
        {
            return CallApi(() => CurrencyRatesApiUrl
                    .AppendPathSegment(currencyId)
                    .GetJsonAsync<CurrencyRate>());          
        }

        public async Task<CurrencyRate[]> GetRates(string[] abbreviation)
        {
            var x = await GetCurrencises();
            var y = new CurrencyRate[5];
            var i = 0;
            foreach (var name in abbreviation)
            {
               var rates = x.Where(x => x.Abbriviation == name).Where(x => x.DateStart <= DateTime.Now && x.DateEnd >= DateTime.Now).Select(x => x.Id).FirstOrDefault();
               y[i] = await GetCurrencyRate(rates); 
               i += 1;
            }
            return y;
        }

        private static async Task<T> CallApi<T>(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch (FlurlHttpException e) when (e.StatusCode == 404)
            {
                throw new CurrencyNotavailableExsiption("Currency not available");
            }
        }
    }
}
