using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore.Models
{
    public class ServiceInfo
    {

        [JsonProperty("serviceId")]
        public long ServiceId { get; set; }

        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }

        [JsonProperty("countryId")]
        public long ?CountryId { get; set; }

        [JsonProperty("currencyId")]
        public long ?CurrencyId { get; set; }

        [JsonProperty("symbolCurrencyId")]
        public long ?SymbolCurrencyId { get; set; }

        [JsonProperty("timezoneId")]
        public long ?TimezoneId { get; set; }
    }
}
