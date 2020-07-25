using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TaxiAppsWebAPICore.Models
{
   public class CurrencyInfo
    {
        [JsonProperty("currencyID")]
        public int CurrencyID { get; set; }
        [JsonProperty("standardId")]
        public long ?StandardId { get; set; }

        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("currencyName")]
        public string CurrencyName { get; set; }
       
    }
}
