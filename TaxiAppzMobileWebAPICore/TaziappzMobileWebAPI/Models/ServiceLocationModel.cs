using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class ServiceLocationModel
    {
        [JsonProperty("serviceId")]
        public long ?ServiceId { get; set; }

        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }
    }

    public class ZoneModel
    {
        [JsonProperty("zoneId")]
        public long? ZoneId { get; set; }

        [JsonProperty("zoneName")]
        public string ZoneName { get; set; }
    }
    public class TypeModel
    {
        [JsonProperty("TypeId")]
        public long? TypeId { get; set; }

        [JsonProperty("typeName")]
        public string TypeName { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
    }
}
