using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TaxiAppsWebAPICore.Models
{
    public class CountryList
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
        
        [JsonProperty("countryName")]
        public string CountryName { get; set; }
        
        [JsonProperty("mobileCode")]
        public string MobileCode { get; set; }
        
        [JsonProperty("ountryId")]
        public long CountryId { get; set; }
        
    }

}
