using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TaxiAppsWebAPICore.Models
{
   
   public  class UserListModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("eMail")]
        public string EMail { get; set; }
        [JsonProperty("phoneNo")]
        public string PhoneNo { get; set; }
        [JsonProperty("userId")]
        public int UserID { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
