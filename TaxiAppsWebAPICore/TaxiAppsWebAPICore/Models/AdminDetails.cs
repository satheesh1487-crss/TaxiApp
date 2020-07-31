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
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("phonenumber")]
        public string Phonenumber { get; set; }
        
        [JsonProperty("Emerphonenumber")]
        public string Emerphonenumber { get; set; }
       
        [JsonProperty("Postalcode")]
        public string Postalcode { get; set; }
       
        [JsonProperty("Country")]
        public string Country { get; set; }
        
        [JsonProperty("Address")]
        public string Address { get; set; }
        
        [JsonProperty("userlogin")]
        public string Userlogin { get; set; }
       
        [JsonProperty("password")]
        public string Password { get; set; }
       
        [JsonProperty("rolename")]
        public long ?Rolename { get; set; }
        
        [JsonProperty("TimeZone")]
        public long ?TimeZone { get; set; }
        
        [JsonProperty("area")]
        public long? Area { get; set; }
        
        [JsonProperty("languagename")]
        public int ?Languagename { get; set; }
       
        [JsonProperty("profilePicture")]
        public string ProfilePicture { get; set; }
       
        [JsonProperty("documentName")]
        public string DocumentName { get; set; }
       
        [JsonProperty("document")]
        public string Document { get; set; }
        

    }
    public class AdminPassword
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
