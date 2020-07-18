using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore 
{
    public class AdminDetails
    {
        private string _isactive;
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("postalcode")]
        public long? PostalCode { get; set; }
        [JsonProperty("documentname")]
        public string DocumentName { get; set; }
        [JsonProperty("document")]
        public string Document { get; set; }
        [JsonProperty("driverdoccount")]
        public int? DriverDocumentCount { get; set; }
        [JsonProperty("isActive")]
        public string IsActive
        {
            get
            {
                return _isactive;
            }
            set
            {
                _isactive = value == "1" ? "ACTIVE" : "INACTIVE";
                   
            }
        }
    }
}
