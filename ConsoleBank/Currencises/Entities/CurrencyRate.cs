using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Currencises.Entities
{
    public class CurrencyRate
    {
        [JsonProperty("Cur_ID")]
        public int Id { get; set; }

        [JsonProperty("Cur_Scale")]
        public int Scale { get; set; }

        [JsonProperty("Cur_OfficialRate")]
        public double Rate { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Scale} - {Rate}";
        }
    }
}
