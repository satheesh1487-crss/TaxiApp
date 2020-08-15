using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI 
{
    //public class LatLongList
    //{
    //    public List<LatLong> LatLongs { get; set; }
    //}
    public class LatLong
    {
        [JsonProperty("picklatitude")]
        public decimal? Picklatitude { get; set; }
        [JsonProperty("picklongtitude")]
        public decimal? Picklongtitude { get; set; }
        [JsonProperty("droplatitude")]
        public decimal? Droplatitude { get; set; }
        [JsonProperty("droplongtitude")]
        public decimal? droplongtitude { get; set; }
        [JsonIgnore]
        public long? Zoneid { get; set; }


    }
}
