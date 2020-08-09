using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore
{
    public class AdminDetails:AdminPassword
    {
             
        [JsonProperty("firstname")]
        public string Firstname { get; set; }
       
        [JsonProperty("lastname")]
        public string Lastname { get; set; }
        [JsonProperty("roleId")]
        public long? RoleId { get; set; }

        [JsonProperty("area")]
        public long? Area { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("phonenumber")]
        public string Phonenumber { get; set; }
        
        [JsonProperty("emerphonenumber")]
        public string Emerphonenumber { get; set; }
       
        [JsonProperty("postalcode")]
        public long ?Postalcode { get; set; }
       
        [JsonProperty("country")]
        public long ?Country { get; set; }
        
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }


        [JsonProperty("languagename")]
        public int? Languagename { get; set; }

        [JsonProperty("userlogin")]
        public string Userlogin { get; set; }
       
        [JsonProperty("password")]
        public string Password { get; set; }  
        
       
        [JsonProperty("profilePicture")]
        public string ProfilePicture { get; set; }
       
        [JsonProperty("documentName")]
        public string DocumentName { get; set; }
       
        
        

    }
    public class AdminPassword
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
