using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class CountryModel
    {

        [JsonProperty("countryId")]
        public long CountryId { get; set; }
        
        [JsonProperty("countryName")]
        public string CountryName { get; set; }
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("countryShortName")]
        public string CountryShortName { get; set; }
        [JsonProperty("countryFlag")]
        public string CountryFlag { get; set; }

    }
}
