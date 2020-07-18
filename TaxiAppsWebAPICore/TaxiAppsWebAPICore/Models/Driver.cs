using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class Driver
    {
        [JsonProperty("driverId")]
        public int DriverId { get; set; }
        [JsonProperty("registrationCode")]
        public string RegisterationCode  { get; set; }
        [JsonProperty("driverName")]
        public string DriverName { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("rating")]
        public string Rating { get; set; }
        [JsonProperty("acceptanceRatio")]
        public string AcceptanceRatio { get; set; }
        [JsonProperty("operatorName")]
        public string OperatorName { get; set; }
        [JsonProperty("blockedStatus")]
        public string BlockedStatus { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("fineReason")]
        public string FineReason { get; set; }
        [JsonProperty("bonusReson")]
        public string BonusReason { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
