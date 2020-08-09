using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class ManagePromo
    {
        [JsonProperty("promoID")]
        public long PromoID { get; set; }
        [JsonProperty("coupencode")]
        public string CoupenCode { get; set; }
        [JsonProperty("estimateAmt")]
        public double? EstimateAmount { get; set; }
        [JsonProperty("value")]
        public long? Value { get; set; }
        [JsonProperty("zoneid")]
        public long? Zoneid { get; set; }
       
        [JsonProperty("uses")]
        public long? Uses { get; set; }
        [JsonProperty("repeatedlyuse")]
        public long? RepeatedlyUse { get; set; }
        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        [JsonProperty("startdate")]
        public DateTime? StartDate { get; set; }
        [JsonProperty("expirydate")]
        public DateTime? ExpiryDate { get; set; }
        [JsonProperty("operation")]
        public string Operation { get; set; }
    }

    public class PromoTransaction
    {
        [JsonProperty("promoID")]
        public long PromoID { get; set; }
        [JsonProperty("coupencode")]
        public string CoupenCode { get; set; }
       
        [JsonProperty("value")]
        public long? Value { get; set; }
       
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("uses")]
        public long? Uses { get; set; }
         
        [JsonProperty("operation")]
        public string Operation { get; set; }
    }
  
}
