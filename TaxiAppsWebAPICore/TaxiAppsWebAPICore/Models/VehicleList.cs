using Newtonsoft.Json;

namespace TaxiAppsWebAPICore.Models
{
    public class VehicleList
    {
        [JsonProperty("id")]
        public int Id { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }

        [JsonProperty("image")]
        public string Image { set; get; }

        [JsonProperty("isActive")]
        public bool IsActive { set; get; }
    }
}
