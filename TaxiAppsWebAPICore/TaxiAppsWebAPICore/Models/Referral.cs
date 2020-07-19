using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class UserReferral
    {
        [JsonProperty("sNo")]
        public int SNo { get; set; }
        [JsonProperty("referralCode")]
        public string ReferralCode { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("amountearned")]
        public decimal AmountEarned { get; set; }
        [JsonProperty("amountspent")]
        public decimal AmountSpent { get; set; }
        [JsonProperty("amountBalance")]
        public decimal AmountBalance { get; set; }
 
    }
    public class DriverRefferal
    {
        [JsonProperty("sNo")]
        public int SNo { get; set; }
        [JsonProperty("referralCode")]
        public string ReferralCode { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("amountearned")]
        public decimal AmountEarned { get; set; }
    }
}
