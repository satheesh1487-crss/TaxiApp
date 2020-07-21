using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TaxiAppsWebAPICore 
{
    public class CountryList
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
        
        [JsonProperty("countryName")]
        public string CountryName { get; set; }
        [JsonProperty("countrycurrency")]
        public string CountryCurrency { get; set; }
     
        [JsonProperty("mobileCode")]
        public string MobileCode { get; set; }
        
        [JsonProperty("countryId")]
        public long CountryId { get; set; }
        [JsonProperty("timezoneaccess")]
        public string TimeZoneaccess { get; set; }
    }

}
