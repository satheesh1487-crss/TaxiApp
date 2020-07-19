using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore
{
    public class CancelDriver
    {
        [JsonProperty("sNo")]
        public int Sno { get; set; }
        [JsonProperty("cancellationlist")]
        public string CancellationList { get; set; }
        [JsonProperty("payingstatus")]
        public string PayingStatus { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("arrivalstatus")]
        public string ArrivalStatus { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
