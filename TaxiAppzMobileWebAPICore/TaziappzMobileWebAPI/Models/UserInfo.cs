using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI
{
    public class UserInfo
    {
       [JsonProperty("token")]
        public string RememberToken { get; set; }
        [JsonProperty("refreshtoken")]
        public string RefeshToken { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        [JsonProperty("contactno")]
        public string ContactNo { get; set; }
      
        [JsonProperty("expiredate")]
        public DateTime ExpireDate { get; set; }
        [JsonProperty("inserteddate")]
        public DateTime? InsertedDate { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
    public class UserTripRequest
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("driverName")]
        public string DriverName { get; set; }
        [JsonProperty("driverid")]
        public long? driverid { get; set; }
        [JsonProperty("triptype")]
        public string Triptype { get; set; }
        [JsonProperty("pickuplocation")]
        public string Pickup { get; set; }
        [JsonProperty("droplocation")]
        public string Droplocation { get; set; }
        [JsonProperty("isExist")]
        public int IsExist { get; set; }
    }

}
