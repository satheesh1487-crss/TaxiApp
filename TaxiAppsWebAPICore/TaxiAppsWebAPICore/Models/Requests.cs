using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore
{
    public class ManageRequests
    {
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("dateTime")]
        public string ?DateTime { get; set; }

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

    public class ViewRequest
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("zone")]
        public string Zone { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("driverRated")]
        public int ?DriverRated { get; set; }

        [JsonProperty("userRated")]
        public int ?UserRated { get; set; }

        [JsonProperty("driverName")]
        public string DriverName { get; set; }

        [JsonProperty("driverEmail")]
        public string DriverEmail { get; set; }

        [JsonProperty("driverContactNo")]
        public string DriverContactNo { get; set; }

        [JsonProperty("request")]
        public List<RequestInfo> Request { get; set; }

        [JsonProperty("driverDetails")]
        public List<RequestDriverInfo> DriverDetails { get; set; }

    }
    public class RequestInfo
    {
        [JsonProperty("typeName")]
        public string TypeName { get; set; }

        [JsonProperty("zoneName")]
        public string ZoneName { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("userRate")]
        public int? UserRate { get; set; }

        [JsonProperty("driverRate")]
        public int? DriverRate { get; set; }
    
    }
    public class RequestDriverInfo
    {
        [JsonProperty("driverRated")]
        public int? DriverRated { get; set; }       

        [JsonProperty("driverName")]
        public string DriverName { get; set; }

        [JsonProperty("driverEmail")]
        public string DriverEmail { get; set; }

        [JsonProperty("driverContactNo")]
        public string DriverContactNo { get; set; }
    }
}
