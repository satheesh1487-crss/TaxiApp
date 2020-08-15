using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI 
{
    public class SurgePrice
    {
        [JsonProperty("surgepriceid")]
        public long? Surgepriceid { get; set; }
        [JsonProperty("zoneid")]
        public long? Zoneid { get; set; }
        [JsonProperty("surgepricetype")]
        public string Surgepricetype { get; set; }
        [JsonProperty("starttime")]
        public string Starttime { get; set; }
        [JsonProperty("endtime")]
        public string Endtime { get; set; }
        [JsonProperty("peaktype")]
        public string Peaktype { get; set; }
        [JsonProperty("surgepricevalue")]
        public string Surgepricevalue { get; set; }
    }
}
