using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class ManageReferral
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("referralWorth_Amount")]
        public decimal ?ReferralWorth_Amount { get; set; }
       
        [JsonProperty("referralGain_Amount_PerPerson")]
        public decimal ?ReferralGain_Amount_PerPerson { get; set; }

        [JsonProperty("trip_to_completed_torefer")]
        public decimal ?Trip_to_completed_torefer { get; set; }

        [JsonProperty("trip_to_completed_toearn_refferalAmount")]
        public int? Trip_to_completed_toearn_refferalAmount { get; set; }

    }

    public class UserReferral
    {
        [JsonProperty("id")]
        public int Id { get; set; }
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
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("referralCode")]
        public string ReferralCode { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("amountearned")]
        public decimal AmountEarned { get; set; }
    }
}
