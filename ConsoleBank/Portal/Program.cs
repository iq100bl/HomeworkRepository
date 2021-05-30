using System;
using System.Threading.Tasks;
using Currencises;

namespace Portal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var api = new CurrencisesApi();
            var currencies = await api.GetCurrencises();

            //foreach (var currency in currencies)
            //{
            //    Console.WriteLine(currency);
            //}

            Console.WriteLine(await api.GetCurrencyRate(298));

            string[] abbreviationСurrencies = { "RUB", "EUR", "UAH", "USD", "PLN" };
            var rates = await api.GetRates(abbreviationСurrencies);
            foreach (var rate in rates)
            {
                Console.WriteLine(rate);
            }


        var date = new DateTime(2014, 7, 6);
            var exchangeRateTimeDependent = await api.ExchangeRateTimeDependent(date, abbreviationСurrencies);
            foreach (var rate in exchangeRateTimeDependent)
            {
                Console.WriteLine(rate);
            }
        }
    }
}
