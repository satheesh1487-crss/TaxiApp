using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TaxiAppsWebAPICore.Models
{
    public class CurrencyList
    {
        [JsonProperty("currencyId")]
        public int CurrencyId { get; set; }

        [JsonProperty("currencyName")]
        public string CurrencyName { get; set; }
    }
}
