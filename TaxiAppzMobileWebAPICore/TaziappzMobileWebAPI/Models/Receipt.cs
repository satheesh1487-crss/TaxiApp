using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace TaziappzMobileWebAPI 
{
    public class Receipt
    {
       [JsonProperty("baseprice")]
       public double Baseprice { get; set; }
        [JsonProperty("basedistance")]
        public double Basedistance { get; set; }
        [JsonProperty("priceperdistance")]
        public double Priceperdistance { get; set; }
        [JsonProperty("duration")]
        public double Duration { get; set; }
        [JsonProperty("pricepertime")]
        public double Pricepertime { get; set; }
        [JsonProperty("freewaitingtime")]
        public double Freewaitingtime { get; set; }
        [JsonProperty("waitingcharge")]
        public double Waitingcharge { get; set; }
        [JsonProperty("waitingtime")]
        public double Waitingtime { get; set; }
        [JsonProperty("subtotal")]
        public double Subtotal { get; set; }
        [JsonProperty("servicetaxper")]
        public double Servicetaxper { get; set; }
        [JsonProperty("admincommissionper")]
        public double Admincommissionper { get; set; }
        [JsonProperty("drivercommission")]
        public double Drivercommission { get; set; }
        [JsonProperty("totalamount")]
        public double Totalamount { get; set; }
        [JsonProperty("result")]
        public bool Result { get; set; }
    }
}
