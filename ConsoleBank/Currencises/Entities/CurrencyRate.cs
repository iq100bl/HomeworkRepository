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
        private readonly DateTime denomination = new DateTime(2016, 6, 30);

        [JsonProperty("Cur_ID")]
        public int Id { get; set; }

        [JsonProperty("Date")]
        public DateTime date { get; set; }

        [JsonProperty("Cur_Abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("Cur_Scale")]
        public int Scale { get; set; }

        [JsonProperty("Cur_Name")]
        public string Name { get; set; }


        [JsonProperty("Cur_OfficialRate")]
        public double Rate { get; set; }

        public override string ToString()
        {
            if(date < denomination)
            {
                return $"{Scale} {Abbreviation} = {Rate} BYN. There was a denomination\n 1 BYN = {Scale / Rate} {Abbreviation} ";
            }
            else
            {
                return $"{Scale} {Abbreviation} = {Rate} BYN\n 1 BYN = {Scale / Rate} {Abbreviation} ";
            }
        }
    }
}
