using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class UsertoDriver
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("rating")]
        public decimal Rating { get; set; }
        [JsonProperty("comment")]
        public string Comment { get; set; }
        [JsonProperty("requestid")]
        public Int64 RequestID { get; set; }
        [JsonProperty("driverName")]
        public string DriverName { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }

    public class DrivertoUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("rating")]
        public decimal Rating { get; set; }
        [JsonProperty("comment")]
        public string Comment { get; set; }
        [JsonProperty("requestid")]
        public Int64 RequestID { get; set; }
        [JsonProperty("driverName")]
        public string DriverName { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
