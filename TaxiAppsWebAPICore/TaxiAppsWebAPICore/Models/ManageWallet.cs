using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class ManageWallet
    {
        [JsonProperty("walletId")]
        public int WalletID { get; set; }
        [JsonProperty("registrationCode")]
        public string RegisterationCode { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("rating")]
        public string Rating { get; set; }
       
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
