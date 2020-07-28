using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore.Models
{
    public class UserList
    {
        [JsonProperty("id")]
        public long Id { set; get; }

        [JsonProperty("name")]
        public string Name { set; get; }

        [JsonProperty("email")]
        public string Email { set; get; }

        [JsonProperty("phoneno")]
        public string Phoneno { set; get; }

        [JsonProperty("status")]
        public bool Status { set; get; }

    }
}
