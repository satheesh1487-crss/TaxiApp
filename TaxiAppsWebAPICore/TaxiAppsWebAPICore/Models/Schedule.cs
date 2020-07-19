using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore
{
    public class Schedule
    {
        [JsonProperty("sno")]
        public int ID { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("requestID")]
        public string RequestID { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
       
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
