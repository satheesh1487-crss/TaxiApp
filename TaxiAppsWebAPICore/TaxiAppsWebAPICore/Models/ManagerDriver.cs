using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore.Models
{
    public class ManagerDriver
    {
        [JsonProperty("Sno")]
        public long Sno { get; set; }
            [JsonProperty("ComplaintType")]
            public string ComplaintType { get; set; }

        [JsonProperty("ComplaintTitle")]
        public string ComplaintTitle { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("RequestID")]
        public string RequestID { get; set; }
        [JsonProperty("DriverName")]
        public string DriverName { get; set; }

        [JsonProperty("IsActive")]
        public string IsActive { get; set; }
         
    }
}
