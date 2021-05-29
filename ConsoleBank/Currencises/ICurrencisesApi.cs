using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currencises.Entities;

namespace Currencises
{
    public interface ICurrencisesApi
    {
        Task<Currency[]> GetCurrencises();

        Task<CurrencyRate> GetCurrencyRate(int currencyId);
    }
}
