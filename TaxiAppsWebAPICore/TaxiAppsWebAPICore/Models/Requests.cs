using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class Requests
    {
       [JsonProperty("sno")]
       public int ID { get; set; }
        [JsonProperty("dateTime")]
        public string DateTime { get; set; }
        [JsonProperty("requestID")]
        public string RequestID { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("driverName")]
        public string DriverName { get; set; }
        [JsonProperty("paymentmode")]
        public string Paymentmode { get; set; }
        [JsonProperty("tripStatus")]
        public string TripStatus { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
