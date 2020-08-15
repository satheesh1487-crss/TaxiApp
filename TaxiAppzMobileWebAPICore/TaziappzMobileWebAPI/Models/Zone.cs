using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.Models;

namespace TaziappzMobileWebAPI 
{
    public class Zone
    {
        [JsonProperty("zoneid")]
        public long? Zoneid { get; set; }
        [JsonProperty("zoneName")]
        public string ZoneName { get; set; }
        [JsonProperty("unit")]
        public string Unit { get; set; }
        [JsonIgnore]
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        [JsonProperty("servicelocname")]
        public string ServiceLocName { get; set; }
        [JsonProperty("servicelocnameid")]
        public long ServiceLocID { get; set; }
        [JsonProperty("vehicletypelist")]
        public List<VehicleType> Vehicletypelist { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("surgepricelist")]
        public List<SurgePrice> Surgepricelist { get; set; }
        [JsonProperty("isExist")]
        public int IsExist { get; set; }
    }
}
