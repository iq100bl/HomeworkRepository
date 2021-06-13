﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Currencies.Apis.Rub.Entities;
using Currencies.Common;
using Currencies.Exceptions;
using Flurl;
using Flurl.Http;

namespace Currencies.Apis.Rub
{
    public class RubCurrenciesApi : ICurrenciesApi
    {
        private const string BaseApiUrl = "http://www.cbr.ru/scripts";
        private readonly string _currencyRatesDynamicsApiUrl = $"{BaseApiUrl}/rates/dynamics";
        private readonly string _currencyRatesApiUrl = $"{BaseApiUrl}/XML_daily.asp";
        private readonly string _currenciesApiUrl = $"{BaseApiUrl}/XML_valFull.asp";

        public async Task<CurrencyModel[]> GetCurrencies(DateTime? onDate = null)
        {
            var xmlResponse = await CallApi(() => _currenciesApiUrl.GetStringAsync());
            var response = XmlUtils.ParseXml<RubCurrenciesResponse>(xmlResponse);
            return response.Items.Select(x => new CurrencyModel
            {
                Id = x.Id,
                Name = x.Name,
                CharCode = x.CharCode
            }).ToArray();
        }

        public async Task<CurrencyRateModel> GetCurrencyRate(string charCode, DateTime? onDate = null)
        {
            var date = onDate ?? DateTime.Today;
            string xmlResponse = await CallApi(() => _currencyRatesApiUrl
                .SetQueryParam("date_req", date.ToString("dd/MM/yyyy"))
                .GetStringAsync());

            var response = XmlUtils.ParseXml<RubCurrencyRateResponse>(xmlResponse);
            RubCurrencyRate rate = response.Items.Single(x => x.CharCode == charCode);
            return new CurrencyRateModel
            {
                Date = date,
                Id = rate.Id,
                Name = rate.Name,
                Nominal = rate.Nominal,
                Rate = rate.Rate,
                CharCode = rate.CharCode,
            };
        }

        public async Task<CurrencyRateModel[]> GetDynamics(string charCode, DateTime start, DateTime end)
        {
            var currencies = await GetCurrencies();
            var id = currencies.Single(x => x.CharCode == charCode).Id;
            var xmlResponse = await CallApi(() => _currencyRatesDynamicsApiUrl
            .SetQueryParams(new
            {
                date_req1 = start.ToString("dd/MM/yyyy"),
                date_req2 = end.ToString("dd/MM/yyyy"),
                VAL_NM_RQ = id,
            }).GetStringAsync());

            var response = XmlUtils.ParseXml<CurrencyDynamicsResponse>(xmlResponse);

            return response.Items.Select(x => new CurrencyRateModel {
                CharCode = charCode,
                Date = x.Date, Id = x.Id,
                Name = currencies.Single(x => x.CharCode == charCode).Name,
                Nominal = x.Nominal,
                Rate = x.Rate
            }).ToArray();
        }

        // TODO: base class?
        private static async Task<T> CallApi<T>(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch (FlurlHttpException e) when (e.StatusCode == 404)
            {
                throw new CurrencyNotAvailableException("Currency not available");
            }
        }       
    }
}
