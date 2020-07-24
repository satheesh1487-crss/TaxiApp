using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TaxiAppsWebAPICore.Models
{

    public class UserListModel
    {
        
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        [JsonProperty("eMail")]
        public string EMail { get; set; }
        [JsonProperty("phoneNo")]
        public string PhoneNo { get; set; }
        [JsonProperty("userId")]
        public long UserID { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive
        {
            get;set;
        }
    }
}
