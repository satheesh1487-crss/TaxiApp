using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI
{
    public class SetPrice
    {
       [JsonIgnore]
        [JsonProperty("setpriceid")]
        public long SetPriceid { get; set; }
        [JsonIgnore]
        [JsonProperty("zonetypeid")]
        public long? ZoneTypeid { get; set; }
        [JsonProperty("baseprice")]
        public decimal? BasePrice { get; set; }
        [JsonProperty("pricepertime")]
        public decimal? PricePerTime { get; set; }
        [JsonProperty("basedistance")]
        public long BaseDistance { get; set; }
        [JsonProperty("priceperdistance")]
        public decimal? PricePerDistance { get; set; }
        [JsonProperty("freewaitingtime")]
        public long Freewaitingtime { get; set; }

        [JsonProperty("waitingcharges")]
        public decimal? WaitingCharges { get; set; }

        [JsonProperty("cancellationfee")]
        public decimal? CancellationFee { get; set; }

        [JsonProperty("dropfee")]
        public decimal? DropFee { get; set; }


        [JsonProperty("admincommtype")]
        public string admincommtype { get; set; }
        [JsonProperty("admincommission")]
        public decimal? admincommission { get; set; }
        [JsonProperty("driversavingper")]
        public decimal? Driversavingper { get; set; }
        [JsonProperty("ridetype")]
        public string RideType { get; set; }

        [JsonProperty("customerIdfee")]
        public decimal? CustomerIdfee { get; set; }
        [JsonProperty("modeofpayment")]
        public string Modeofpayment { get; set; }
    }
}
