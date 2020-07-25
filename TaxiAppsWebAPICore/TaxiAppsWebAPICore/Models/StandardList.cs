using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore.Models
{
    public class StandardList
    {
        [JsonProperty("standardId")]
        public long StandardId { get; set; }

        [JsonProperty("standardName")]
        public string StandardName { get; set; }
    }
}
