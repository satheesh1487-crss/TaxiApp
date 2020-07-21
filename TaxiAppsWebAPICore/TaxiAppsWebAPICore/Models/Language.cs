using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class Language
    {
        [JsonProperty("languageshortname")]
        public string LanguageShortName { get; set; }

        [JsonProperty("languageName")]
        public string LanguageName { get; set; }
        
        [JsonProperty("languageId")]
        public long LanguageId { get; set; }
        
    }
}
