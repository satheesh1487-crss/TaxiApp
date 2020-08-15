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
        [JsonProperty("latitude")]
        public decimal? Latitude { get; set; }
        [JsonProperty("longtitude")]
        public decimal? Longtitude { get; set; }

    }
}
