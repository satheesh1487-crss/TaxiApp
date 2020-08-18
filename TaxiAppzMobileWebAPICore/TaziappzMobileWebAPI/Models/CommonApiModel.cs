using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class RequestReviewModel
    {

    }

    public class GetProfileModel
    {
        [JsonProperty("driver")]
        public Driver Driver { get; set; }
    }
    public class Driver
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

        [JsonProperty("is_approve")]
        public int Is_Approve { get; set; }

        [JsonProperty("is_available")]
        public int Is_Available { get; set; }

        [JsonProperty("car_model")]
        public string Car_Model { get; set; }

        [JsonProperty("car_number")]
        public string Car_Number { get; set; }

        [JsonProperty("total_reward_point")]
        public double Total_Reward_Point { get; set; }

        [JsonProperty("type_name")]
        public string Type_Name { get; set; }

        [JsonProperty("type_icon")]
        public string Type_Icon { get; set; }
    }

    public class EarningsListModel
    {
        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("earnings")]
        public Earnings Earnings { get; set; }
    }
    public class Earnings
    {

    }
    
}
