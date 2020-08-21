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
    public class ProfileModel: GeneralModel
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("profile_pic")]
        public string Profile_Pic { get; set; }

        [JsonProperty("new_password")]
        public string New_Password { get; set; }

        [JsonProperty("old_password")]
        public string Old_Password { get; set; }

        [JsonProperty("phone_number")]
        public string Phone_Number { get; set; }
    }
}
