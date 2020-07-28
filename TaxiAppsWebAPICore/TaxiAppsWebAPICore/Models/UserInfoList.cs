using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore.Models
{
    public class UserInfoList
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phonenumber")]
        public string Phonenumber { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("Country")]
        public long ?Country { get; set; }

        [JsonProperty("TimeZone")]
        public long? TimeZone { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("profilepicture")]
        public string ProfilePicture { get; set; }
    }
}
