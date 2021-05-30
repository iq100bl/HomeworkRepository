using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Currencises
{
    public class Currency
    {
        [JsonProperty("Cur_ID")]
        public int Id { get; set; }

        [JsonProperty("Cur_Code")]
        public int Code { get; set; }

        [JsonProperty("Cur_Abbreviation")]
        public string Abbriviation { get; set; }

        [JsonProperty("Cur_Name")]
        public string Name { get; set; }

        [JsonProperty("Cur_DateStart")]
        public DateTime DateStart { get; set; }

        [JsonProperty("Cur_DateEnd")]
        public DateTime DateEnd { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Code} - {Abbriviation} - {Name}";
        }

    }
}
