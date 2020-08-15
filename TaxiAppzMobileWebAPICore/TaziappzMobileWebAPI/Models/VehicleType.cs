using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI  
{
    public class VehicleType
    {
        [JsonProperty("typeid")]
        public long? TypeId { set; get; }
        [JsonProperty("typename")]
        public string TypeName { set; get; }
        [JsonProperty("setpriceList")]
        public List<SetPrice> SetpriceList { get; set; }
    }
}
