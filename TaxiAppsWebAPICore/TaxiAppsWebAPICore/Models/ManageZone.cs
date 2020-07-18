using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class ManageZone
    {
        [JsonProperty("zoneid")]
        public int Zoneid { get; set; }
        [JsonProperty("zoneName")]
        public string ZoneName { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

    }
}
