using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class UserGetReferralModel
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("earned")]
        public int Earned { get; set; }

        [JsonProperty("spent")]
        public int Spent { get; set; }

        [JsonProperty("balance")]
        public int balance { get; set; }

        [JsonProperty("currency")]
        public string currency { get; set; }
    }
    public class UserCheckReferralModel
    {

    }
}
