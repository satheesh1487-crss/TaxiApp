using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore.Models
{
    public class TripSettings
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("tripSettingQuestion")]
        public string TripSettingQuestion { get; set; }

        [JsonProperty("TripSettingAnswer")]
        public string TripSettingAnswer { get; set; }
    }
}
