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
}
