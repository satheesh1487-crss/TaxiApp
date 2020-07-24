using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class Timezone
    {
        [JsonProperty("timezonedesc")]
        public string TimeZoneDescription { get; set; }

        [JsonProperty("isActive")]
        public string IsActive { get; set; }
      

        [JsonProperty("timezoneid")]
        public long TimeZoneid { get; set; }
    }
}
