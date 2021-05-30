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

        public async Task<CurrencyRate[]> GetRates(string[] abbreviationsСurrencies)
        {
            var currencyes = await GetCurrencises();
            var currencyRates = new CurrencyRate[abbreviationsСurrencies.Length];
            var i = 0;
            foreach (var name in abbreviationsСurrencies)
            {
                var rates = currencyes.Where(x => x.Abbriviation == name)
                    .Where(x => x.DateStart <= DateTime.Now && x.DateEnd >= DateTime.Now)
                    .Select(x => x.Id)
                    .FirstOrDefault();
                currencyRates[i] = await GetCurrencyRate(rates);
                i += 1;
            }
            return currencyRates;
        }

        public async Task<CurrencyRate[]> ExchangeRateTimeDependent(DateTime date, string[] abbreviationsСurrencies)
        {
            var currencyRates = await GetCurrencyRates(date);
            var currency = new CurrencyRate[abbreviationsСurrencies.Length];
            var i = 0;
            foreach (var name in abbreviationsСurrencies)
            {
                currency[i] = currencyRates.Where(x => x.Abbreviation == name).FirstOrDefault();
                i += 1;
            }
            return currency;
        }

        private Task<CurrencyRate[]> GetCurrencyRates(DateTime date)
        {
            var text = CurrencyRatesApiUrl + "?ondate=" + date.ToString("yyyy-M-d") + "&periodicity=0";
            return CallApi(() => text
            .GetJsonAsync<CurrencyRate[]>());
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
