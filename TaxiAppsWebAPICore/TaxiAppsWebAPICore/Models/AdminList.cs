using Newtonsoft.Json;
using System;

namespace TaxiAppsWebAPICore
{
    public class AdminList
    {

        [JsonProperty("id")]
        public long Id { set; get; }

        [JsonProperty("name")]
        public string Name { set; get; }

        [JsonProperty("rgcode")]
        public string Rgcode { set; get; }

        [JsonProperty("email")]
        public string Email { set; get; }

        [JsonProperty("phoneno")]
        public string Phoneno { set; get; }

        [JsonProperty("role")]
        public string Role { set; get; }

        [JsonProperty("status")]
        public bool Status { set; get; }

        [JsonProperty("operations")]
        public string Operations { set; get; }
    }
    
}
