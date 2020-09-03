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
    }
    public class ProfileModel : GeneralModel
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

    public class DriverStatusModel : GeneralModel
    {
        [JsonProperty("online_status")]
        public bool Online_Status { get; set; }

        //[JsonProperty("contact_number")]
        //public string Contact_Number { get; set; }
    }

    public class UserZoneSOSModel : GeneralModel
    {
        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }
    }

    public class UserFAQListModel : GeneralModel
    {
        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }
    }

    public class DriverLocation
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        [JsonProperty("longitude")]
        public string Longitude { get; set; }

       
 
    }

    public class DriverCancelTripModel : GeneralModel
    {
        [JsonProperty("request_id")]
        public int Request_Id { get; set; }

        [JsonProperty("reason")]
        public int Reason { get; set; }
    }

    public class UserCancelTripModel : GeneralModel
    {
        [JsonProperty("request_id")]
        public int Request_Id { get; set; }

        [JsonProperty("reason")]
        public int Reason { get; set; }

        [JsonProperty("cancel_other_reason")]
        public string Cancel_Other_Reason { get; set; }
    }
    public class SettingModel
    {
         public int Seconds { get; set; }
          public int tripsettingquestionid { get; set; }


    }
}
