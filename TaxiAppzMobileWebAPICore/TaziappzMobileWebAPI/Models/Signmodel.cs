using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI 
{
    public class SignUpmodel
    {
        
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        [JsonProperty("phone")]
        public string mobileno { get; set; }
        [JsonProperty("email")]
        public string MailID { get; set; }
       
    }
    public class DetailsWithToken : SignUpmodel
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("token")]
        public string AccessToken { get; set; }
        [JsonProperty("refreshtoken")]
        public string RefreshToken { get; set; }
        [JsonProperty("isActive")]
        public int? IsActive { get; set; }
        [JsonProperty("success_message")]
        public string Status { get; set; }

    }
    public class SignInmodel
    {
        [JsonProperty("loginMethod")]
        public string LoginMethod { get; set; }
        [JsonProperty("contactno")]
        public string Contactno { get; set; }
        [JsonProperty("devicetoken")]
        public string Devicetoken { get; set; }
        [JsonProperty("loginBy")]
        public string LoginBy { get; set; }

    }
}
