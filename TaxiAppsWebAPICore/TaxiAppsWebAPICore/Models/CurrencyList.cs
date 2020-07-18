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

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("standardName")]
        public string StandardName { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
