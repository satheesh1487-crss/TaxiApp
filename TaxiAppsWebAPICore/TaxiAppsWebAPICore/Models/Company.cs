using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore
{
    public class Company
    {
        [JsonProperty("companyId")]
        public int Companyid { get; set; }
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }
        [JsonProperty("operatorName")]
        public string OperatorName { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
