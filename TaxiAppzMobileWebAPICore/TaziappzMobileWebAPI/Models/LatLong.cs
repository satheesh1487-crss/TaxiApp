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
       

    }
    public class RequestVehicleType : LatLong
    {
        [JsonProperty("droplatitude")]
        public decimal? Droplatitude { get; set; }
        [JsonProperty("droplongtitude")]
        public decimal? droplongtitude { get; set; }
        [JsonProperty("pickuplocation")]
        public string Pickuplocation { get; set; }
        [JsonProperty("droplocation")]
        public string Droplocation { get; set; }

        [JsonProperty("paymentoption")]
        public string paymentoption { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("isShare")]
        public int IsShare { get; set; }
        [JsonProperty("driversLists")]
       public List<DriversList> DriversLists { get; set; }
    }
    public class DriversList
    {
        [JsonProperty("driverlatitude")]
        public decimal? Driverlatitude { get; set; }
        [JsonProperty("driverlongtitude")]
        public decimal? Driverlongtitude { get; set; }
        [JsonProperty("driverid")]
        public long? Driverid { get; set; }
    }
    public class DriversListwithDistance
    {
        [JsonProperty("driverlatitude")]
        public decimal? Driverlatitude { get; set; }
        [JsonProperty("driverlongtitude")]
        public decimal? Driverlongtitude { get; set; }
        [JsonProperty("driverid")]
        public long? Driverid { get; set; }
        [JsonProperty("distance")]
        public double? Distance { get; set; }
    }

    public class DriversCancel
    {
        [JsonProperty("requestId")]
        public long RequestId { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        [JsonProperty("cancel_other_reason")]
        public long? Cancel_Other_Reason { get; set; }
        [JsonProperty("request_id")]
        public long Requestid { get; set; }
    }
}
