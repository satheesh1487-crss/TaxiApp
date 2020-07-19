using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore
{
    public class ManageSMSOption
    {
        [JsonProperty("sno")]
        public int Sno { get; set; }
        [JsonProperty("smstitle")]
        public string SMSTitle { get; set; }
      
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
