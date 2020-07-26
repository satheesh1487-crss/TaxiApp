using Newtonsoft.Json;
using System;
using System.Security.Policy;

namespace TaxiAppsWebAPICore
{
    public class VehicleTypeList
    {
        [JsonProperty("id")]
        public long Id { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }

        [JsonProperty("image")]
        public string Image { set; get; }

        [JsonProperty("isActive")]
        public bool IsActive { set; get; } 

    }
    public class VehicleTypeInfo
    {
        [JsonProperty("id")]
        public long Id { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }

        [JsonProperty("image")]
        public string Image { set; get; } 

    }
    public class ZoneTypeRleation
    {
        [JsonProperty("relationid")]
        public long Relationid { set; get; }
        [JsonProperty("zoneid")]
        public long Zoneid { set; get; }

        [JsonProperty("typeid")]
        public long Typeid { set; get; }
        [JsonProperty("paymentmode")]
        public string  Paymentmode { set; get; }
        [JsonProperty("showbill")]
        public string Showbill { set; get; }
        [JsonProperty("Isdefault")]
        public int Isdefault { set; get; }
        [JsonProperty("isActive")]
        public bool IsActive { set; get; }
    }
}
