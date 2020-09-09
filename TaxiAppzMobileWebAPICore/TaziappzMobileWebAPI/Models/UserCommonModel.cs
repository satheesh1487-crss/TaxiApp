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
        public long Id { get; set; }

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
        public bool ?Is_Active { get; set; }

        [JsonProperty("corporate")]
        public int ?Corporate { get; set; }
    }
    public class UserSosModel
    {
        [JsonProperty("sos")]
        public List<SosUser> sos { get; set; }

        [JsonProperty("user_sos")]
        public List<User_Sos> User_Sos { get; set; }
    }
    public class SosUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("number")]
        public string number { get; set; }
    }
    public class User_Sos
    {

    }
    public class UserFaqListModel
    {
        [JsonProperty("faq_list")]
        public List<User_Faq_List> Faq_List { get; set; }        
    }
    public class User_Faq_List
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("answer")]
        public string Answer { get; set; }
    }
    public class UserRequestInProgress
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("last_name")]
        public string Last_name { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("profile_picture")]
        public string Profile_picture { get; set; }
        [JsonProperty("active")]
        public bool? Active { get; set; }
        //[JsonProperty("email_confirmed")]
        //public string Email_confirmed { get; set; }
        //[JsonProperty("mobile_confirmed")]
        //public long Mobile_confirmed { get; set; }
        //[JsonProperty("last_known_ip")]
        //public string Last_known_ip { get; set; }
        //[JsonProperty("last_login_at")]
        //public DateTime? Last_login_at { get; set; }

        [JsonProperty("onTripRequest")]
        public UserTripRequestinProgress OnTripRequest { get; set; }
        [JsonProperty("metaRequest")]
        public UserMetaRequest metaRequest { get; set; }
    }
    public class UserTripRequestinProgress
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("request_number")]
        public string Request_number { get; set; }
        [JsonProperty("is_later")]
        public int? Is_later { get; set; }
        [JsonProperty("user_id")]
        public long? User_id { get; set; }
        [JsonProperty("trip_start_time")]
        public DateTime? Trip_start_time { get; set; }
        [JsonProperty("arrived_at")]
        public string Arrived_at { get; set; }

        [JsonProperty("accepted_at")]
        public DateTime? Accepted_at { get; set; }
        [JsonProperty("completed_at")]
        public string Completed_at { get; set; }

        [JsonProperty("Is_driver_started")]
        public bool? is_driver_started { get; set; }
        [JsonProperty("is_driver_arrived")]
        public bool? Is_driver_arrived { get; set; }
        [JsonProperty("is_trip_start")]
        public bool? Is_trip_start { get; set; }
        [JsonProperty("is_completed")]
        public bool? Is_completed { get; set; }

        [JsonProperty("is_cancelled")]
        public bool? Is_cancelled { get; set; }
        [JsonProperty("cancel_method")]
        public string Cancel_method { get; set; }

        [JsonProperty("payment_opt")]
        public string Payment_opt { get; set; }
        [JsonProperty("is_paid")]
        public string Is_paid { get; set; }
        [JsonProperty("user_rated")]
        public int? User_rated { get; set; }
        [JsonProperty("driver_rated")]
        public int? Driver_rated { get; set; }

        [JsonProperty("unit")]
        public int? Unit { get; set; }
        [JsonProperty("zone_type_id")]
        public long? Zone_type_id { get; set; }
        [JsonProperty("vehicle_type_name")]
        public string Vehicle_type_name { get; set; }
        [JsonProperty("pick_lat")]
        public decimal? Pick_lat { get; set; }

        [JsonProperty("pick_lng")]
        public decimal? Pick_lng { get; set; }
        [JsonProperty("drop_lat")]
        public decimal Drop_lat { get; set; }
        [JsonProperty("drop_lng")]
        public decimal Drop_lng { get; set; }
        [JsonProperty("pick_address")]
        public string Pick_address { get; set; }
        [JsonProperty("drop_address")]
        public string Drop_address { get; set; }

        [JsonProperty("driverDetail")]
        public DriverDetails DriverDetails { get; set; }

    }
    public class DriverDetails
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("profile_picture")]
        public string Profile_picture { get; set; }
        [JsonProperty("active")]
        public bool? Active { get; set; }

        [JsonProperty("approve")]
        public bool? Approve { get; set; }
        [JsonProperty("availabe")]
        public bool? Availabe { get; set; }


        [JsonProperty("uploaded_document")]
        public string Uploaded_document { get; set; }
        [JsonProperty("service_location_id")]
        public long? Service_location_id { get; set; }

        [JsonProperty("vehicle_type_id")]
        public long? Vehicle_type_id { get; set; }
        [JsonProperty("vehicle_type_name")]
        public string Vehicle_type_name { get; set; }

        [JsonProperty("car_make")]
        public string Car_make { get; set; }
        [JsonProperty("car_model")]
        public string Car_model { get; set; }

        [JsonProperty("car_make_name")]
        public string Car_make_name { get; set; }
        [JsonProperty("car_model_name")]
        public string Car_model_name { get; set; }

        [JsonProperty("car_color")]
        public string Car_color { get; set; }
        [JsonProperty("car_number")]
        public string Car_number { get; set; }
    }

    public class UserMetaRequest
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("request_number")]
        public string Request_number { get; set; }
        [JsonProperty("is_later")]
        public int? Is_later { get; set; }
        [JsonProperty("user_id")]
        public long? User_id { get; set; }
        [JsonProperty("trip_start_time")]
        public DateTime? Trip_start_time { get; set; }
        [JsonProperty("arrived_at")]
        public string Arrived_at { get; set; }

        [JsonProperty("accepted_at")]
        public DateTime? Accepted_at { get; set; }
        [JsonProperty("completed_at")]
        public string Completed_at { get; set; }

        [JsonProperty("Is_driver_started")]
        public bool? is_driver_started { get; set; }
        [JsonProperty("is_driver_arrived")]
        public bool? Is_driver_arrived { get; set; }
        [JsonProperty("is_trip_start")]
        public bool? Is_trip_start { get; set; }
        [JsonProperty("is_completed")]
        public bool? Is_completed { get; set; }

        [JsonProperty("is_cancelled")]
        public bool? Is_cancelled { get; set; }
        [JsonProperty("cancel_method")]
        public string Cancel_method { get; set; }

        [JsonProperty("payment_opt")]
        public string Payment_opt { get; set; }
        [JsonProperty("is_paid")]
        public string Is_paid { get; set; }
        [JsonProperty("user_rated")]
        public int? User_rated { get; set; }
        [JsonProperty("driver_rated")]
        public int? Driver_rated { get; set; }

        [JsonProperty("unit")]
        public int? Unit { get; set; }
        [JsonProperty("zone_type_id")]
        public long? Zone_type_id { get; set; }
        [JsonProperty("vehicle_type_name")]
        public string Vehicle_type_name { get; set; }
        [JsonProperty("pick_lat")]
        public decimal? Pick_lat { get; set; }

        [JsonProperty("pick_lng")]
        public decimal? Pick_lng { get; set; }
        [JsonProperty("drop_lat")]
        public decimal? Drop_lat { get; set; }
        [JsonProperty("drop_lng")]
        public decimal? Drop_lng { get; set; }
        [JsonProperty("pick_address")]
        public string Pick_address { get; set; }
        [JsonProperty("drop_address")]
        public string Drop_address { get; set; }

        [JsonProperty("driverDetail")]
        public DriverDetails DriverDetails { get; set; }

    }
}
