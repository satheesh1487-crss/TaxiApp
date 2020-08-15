using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI
{
    public class APIResponse
    { 
        [JsonProperty("success_message")]
        public string Message { get; set; }

        [JsonProperty("success")]
        public bool success => isExist == 1;

        [JsonProperty("isExist")]
        public int isExist { get; set; }

       
    }
}
