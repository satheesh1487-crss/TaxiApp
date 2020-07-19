using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class ManageEmailOption
    {
        [JsonProperty("sno")]
        public int Sno { get; set; }
        [JsonProperty("emailtitle")]
        public string EmailTitle { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
