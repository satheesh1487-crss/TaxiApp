using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class UserRatingModel
    {
    }

    public class UserProfileModel
    {
        [JsonProperty("corporate")]
        public int corporate { get; set; }

        [JsonProperty("user")]
        public UserProfile User { get; set; }

        [JsonProperty("sos")]
        public List<UserProfileSos> Sos { get; set; }
    }
    public class UserProfileSos
    {

    }
    public class UserProfile
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("login_by")]
        public string Login_By { get; set; }

        [JsonProperty("login_method")]
        public string Login_Method { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("profile_pic")]
        public string Profile_Pic { get; set; }

        [JsonProperty("is_active")]
        public int Is_Active { get; set; }

        [JsonProperty("corporate")]
        public int Corporate { get; set; }
    }
}
