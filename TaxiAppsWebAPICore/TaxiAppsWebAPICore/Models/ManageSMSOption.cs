using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore
{
    public class ManageSMSOption
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("smstitle")]
        public string SMSTitle { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isActive")]
        public bool ?IsActive { get; set; }
    }
}
