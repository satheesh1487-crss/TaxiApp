using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class SetPrice
    {
        [JsonProperty("setpriceid")]
        public long SetPriceid { get; set; }
        [JsonProperty("zonetypeid")]
        public long? ZoneTypeid { get; set; }
        [JsonProperty("baseprice")]
        public double BasePrice { get; set; }
        [JsonProperty("pricepertime")]
        public double PricePerTime { get; set; }
        [JsonProperty("basedistance")]
        public long BaseDistance { get; set; }
        [JsonProperty("priceperdistance")]
        public double PricePerDistance { get; set; }
        [JsonProperty("freewaitingtime")]
        public long Freewaitingtime { get; set; }

        [JsonProperty("waitingcharges")]
        public double WaitingCharges { get; set; }

        [JsonProperty("cancellationfee")]
        public double? CancellationFee { get; set; }

        [JsonProperty("dropfee")]
        public double? DropFee { get; set; }


        [JsonProperty("admincommtype")]
        public string admincommtype { get; set; }
        [JsonProperty("admincommission")]
        public double? admincommission { get; set; }
        [JsonProperty("driversavingper")]
        public double? Driversavingper { get; set; }
        [JsonProperty("ridetype")]
        public string RideType { get; set; }

       
        //  public virtual List<AdminList> AdminLists { get; set; }
    }
}
