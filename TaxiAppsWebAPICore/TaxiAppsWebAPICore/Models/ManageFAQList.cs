using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore.Models
{
    public class ManageFAQList
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("servicelocid")]
        public long ?Servicelocid { get; set; }

        [JsonProperty("FAQ_Question")]
        public string FAQ_Question { get; set; }

        [JsonProperty("FAQ_Answer")]
        public string FAQ_Answer { get; set; }

        [JsonProperty("complaint_Type")]
        public string Complaint_Type { get; set; }

        [JsonProperty("isActive")]
        public bool ?IsActive { get; set; }
    }
}
