using Newtonsoft.Json;
using System;

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

        [JsonProperty("isDeleted")]
        public bool IsDeleted { set; get; }

        [JsonProperty("createdby")]
        public string Createdby { set; get; }

        [JsonProperty("createdat")]
        public DateTime Createdat { set; get; }

        [JsonProperty("updatedby")]
        public string Updatedby { set; get; }

        [JsonProperty("updatedat")]
        public DateTime Updatedat { set; get; }

        [JsonProperty("deletedby")]
        public string Deletedby { set; get; }

        [JsonProperty("deletedat")]
        public DateTime Deletedat { set; get; }

    }
}
