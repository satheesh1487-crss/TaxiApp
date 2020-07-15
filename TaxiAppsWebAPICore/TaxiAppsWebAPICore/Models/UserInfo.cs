using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore.Models
{
    public class UserInfo
    {
       [JsonProperty("token")]
        public string RememberToken { get; set; }
        [JsonProperty("refreshtoken")]
        public string RefeshToken { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("expiredate")]
        public DateTime ExpireDate { get; set; }
    }
    
}
