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
                //Console.WriteLine(currency);
            //}

            //var rate = await api.GetCurrencyRate(298);
           // Console.WriteLine(rate);

            string[] abbreviation = { "RUB", "EUR", "UAH", "USD", "PLN" };
            var rates = await api.GetRates(abbreviation);
            foreach(var x in rates)
            {
                Console.WriteLine(x);
            }
        }
    }
}
