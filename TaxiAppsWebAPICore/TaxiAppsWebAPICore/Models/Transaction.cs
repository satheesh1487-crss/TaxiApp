using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore
{
    public class Transaction
    {
        [JsonProperty("sno")]
        public int Sno { get; set; }
        [JsonProperty("requestID")]
        public string RequestID { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("driverName")]
        public string DriverName { get; set; }
        [JsonProperty("promodiscount")]
        public decimal PromoDiscount { get; set; }
        [JsonProperty("adminAmount")]
        public decimal AdminAmount { get; set; }
        [JsonProperty("driverAmount")]
        public decimal DriverAmount { get; set; }
        [JsonProperty("referalAmount")]
        public decimal ReferalAmount { get; set; }
        [JsonProperty("servicetaxinpercentage")]
        public decimal ServiceTaxinPercentage { get; set; }
        [JsonProperty("total")]
        public decimal Total { get; set; }
        [JsonProperty("payment")]
        public string Payment { get; set; }
        [JsonProperty("isPaid")]
        public string IsPaid { get; set; }

    }
}
