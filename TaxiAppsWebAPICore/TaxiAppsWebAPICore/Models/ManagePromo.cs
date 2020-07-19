using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class ManagePromo
    {
        [JsonProperty("sNo")]
        public int Sno { get; set; }
        [JsonProperty("coupencode")]
        public string CoupenCode { get; set; }
        [JsonProperty("estimateAmt")]
        public Int64 EstimateAmount { get; set; }
        [JsonProperty("value")]
        public int Value { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("uses")]
        public Int64 Uses { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("startdate")]
        public string StartDate { get; set; }
        [JsonProperty("expirydate")]
        public string ExpiryDate { get; set; }
        [JsonProperty("operation")]
        public string Operation { get; set; }
    }

    public class PromoTransaction
    {
        [JsonProperty("sNo")]
        public int Sno { get; set; }
        [JsonProperty("coupencode")]
        public string CoupenCode { get; set; }
        [JsonProperty("estimateAmt")]
        
        public int Value { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("uses")]
        public Int64 Uses { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("operation")]
        public string Operation { get; set; }
    }
}
