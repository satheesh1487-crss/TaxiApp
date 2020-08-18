using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class GeneralModel
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("token")]
        public  string Token { get; set; }
    }
}
