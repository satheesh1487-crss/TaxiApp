using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore
{
    public class ManageUserComplaint
    {
        [JsonProperty("userComplaintID")]
        public long UserCompalintID { get; set; }
        [JsonProperty("zoneId")]
        public long? ZoneId { get; set; }
        [JsonProperty("usercomplainttype")]
        public string UserComplaintType { get; set; }
        [JsonProperty("usercomplainttitle")]
        public string UserComplaintTitle { get; set; }

        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }
    }
  
    public class ManageDriverComplaint
    {
        [JsonProperty("driverComplaintID")]
        public long DriverCompalintID { get; set; }
        [JsonProperty("zoneId")]
        public long? ZoneId { get; set; }
        [JsonProperty("drivercomplainttype")]
        public string DriverComplaintType { get; set; }
        [JsonProperty("drivercomplainttitle")]
        public string DriverComplaintTitle { get; set; }

        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }
    }
}
