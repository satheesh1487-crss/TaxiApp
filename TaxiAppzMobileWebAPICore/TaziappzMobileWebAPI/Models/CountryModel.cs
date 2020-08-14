using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class CountryModel
    {

        [JsonProperty("countryId")]
        public long CountryId { get; set; }
        
        [JsonProperty("countryName")]
        public string CountryName { get; set; }
               
    }
}
