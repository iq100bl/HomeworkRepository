using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Currencies.Common.Caching
{
    public class CurrenciesApiCacheService : ICurrenciesApiCacheService
    {
        private readonly List<CurrencyModel> _currenciesCache = new();
        private readonly Dictionary<string, List<CurrencyRateModel>> _ratesCache = new();

        private readonly ICurrenciesApi _currenciesApi;

        public CurrenciesApiCacheService(ICurrenciesApi currenciesApi)
        {
            _currenciesApi = currenciesApi;
        }

        public Task Initialize()
        {
            // addition request for today's rates
            return Task.CompletedTask;
        }

        public async Task<CurrencyModel[]> GetCurrencies(DateTime? onDate = null)
        {
            if (_currenciesCache.Any())
            {
                return _currenciesCache.ToArray();
            }

            var currencies = await _currenciesApi.GetCurrencies();
            _currenciesCache.AddRange(currencies);
            return currencies;
        }

        public async Task<CurrencyRateModel> GetCurrencyRate(string charCode, DateTime? onDate = null)
        {
            var key = GetKey(onDate);
            if (_ratesCache.ContainsKey(key))
            {
                var rate = _ratesCache[key].SingleOrDefault(x => x.CharCode == charCode);
                if (rate == null)
                {
                    return await GetNewCurrencyRate(charCode, onDate);
                }

                return rate;
            }

            return await GetNewCurrencyRate(charCode, onDate);
        }

        public async Task<CurrencyRateModel[]> GetDynamics(string charCode, DateTime start, DateTime end)
        {
            // TODO: add cache if possible?\
            var currencies = await GetCurrencies();
            var dynamicRates = new CurrencyRateModel[(int)(end - start).TotalDays];
            var key = start;
            for (var i = 0; i <= dynamicRates.Length; i++)
            {
                if (_ratesCache.ContainsKey(GetKey(key)) == null
                    || _ratesCache.ContainsKey(GetKey(key.AddDays(1))) == null
                    || _ratesCache.ContainsKey(GetKey(key.AddDays(2))) == null
                    || _ratesCache.ContainsKey(GetKey(key.AddDays(3))) == null)
                {
                    return await GetNewCurrenciesDynamics(charCode, start, end);
                }

                else
                {
                    dynamicRates[i] = _ratesCache[GetKey(key)].SingleOrDefault(x => x.CharCode == charCode);
                    key = key.AddDays(1);
                }
            }
            return dynamicRates;
        }

        private void AddToCache(string key, CurrencyRateModel rate)
        {
            if (_ratesCache.ContainsKey(key))
            {
                var value = _ratesCache[key];
                value.Add(rate);
            }
            else
            {
                _ratesCache.Add(key, new List<CurrencyRateModel> {rate});
            }
        }

        private async Task<CurrencyRateModel> GetNewCurrencyRate(string currencyAbbreviation, DateTime? onDate = null)
        {
            var newRate = await _currenciesApi.GetCurrencyRate(currencyAbbreviation, onDate);
            return AddToCache(newRate, onDate);
        }
        private async Task<CurrencyRateModel[]> GetNewCurrenciesDynamics(string charCode, DateTime start, DateTime end)
        {
            var newCurrenciesDynamics = await _currenciesApi.GetDynamics(charCode, start, end);
            foreach (var key in newCurrenciesDynamics.Select(x => x.Date))
            {
                AddToCache(newCurrenciesDynamics.Where(x => x.Date == key).SingleOrDefault(), key);
            }
            return newCurrenciesDynamics;
        }

        private CurrencyRateModel AddToCache(CurrencyRateModel rate, DateTime? onDate = null)
        {
            var key = GetKey(onDate);
            AddToCache(key, rate);
            return rate;
        }

        private string GetKey(DateTime? date = null)
        {
            return (date ?? DateTime.Today).ToString("d");
        }
    }
}
