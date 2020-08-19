using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class UserETAModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
