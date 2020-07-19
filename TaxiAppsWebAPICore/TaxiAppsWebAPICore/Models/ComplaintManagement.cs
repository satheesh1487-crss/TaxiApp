using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore
{
    public class ManageUser
    {
        [JsonProperty("sNo")]
        public int Sno { get; set; }
        [JsonProperty("complainttype")]
        public string ComplaintType { get; set; }
        [JsonProperty("complainttitle")]
        public string ComplaintTitle { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("requestid")]
        public string RequestID { get; set; }
        [JsonProperty("customerName")]
        public string CustomerName { get; set; }
        [JsonProperty("isActive")]
        public string IsActive { get; set; }
    }
    public class ManageDriver
    {
        [JsonProperty("sNo")]
        public int Sno { get; set; }
        [JsonProperty("complainttype")]
        public string ComplaintType { get; set; }
        [JsonProperty("complainttitle")]
        public string ComplaintTitle { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("requestid")]
        public string RequestID { get; set; }
        [JsonProperty("driverName")]
        public string DriverName { get; set; }
        [JsonProperty("isActive")]
        public string IsActive { get; set; }
    }
}
