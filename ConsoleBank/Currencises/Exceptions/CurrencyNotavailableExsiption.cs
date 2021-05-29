using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currencises.Exceptions
{
    public class CurrencyNotavailableExsiption : Exception
    {
        public CurrencyNotavailableExsiption(string message) : base(message)
        {

        }
    }
}
