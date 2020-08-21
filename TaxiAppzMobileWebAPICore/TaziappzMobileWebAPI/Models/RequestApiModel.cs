using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class RequestInProgress
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
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
        public string Service_location_id { get; set; }

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

        [JsonProperty("onTripRequest")]
        public TripRequest OnTripRequest { get; set; }
        [JsonProperty("metaRequest")]
        public MetaRequest metaRequest { get; set; }
    }
    public class TripRequest
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
        public string is_driver_started { get; set; }
        [JsonProperty("is_driver_arrived")]
        public string Is_driver_arrived { get; set; }
        [JsonProperty("is_trip_start")]
        public string Is_trip_start { get; set; }
        [JsonProperty("is_completed")]
        public string Is_completed { get; set; }

        [JsonProperty("is_cancelled")]
        public string Is_cancelled { get; set; }
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

        [JsonProperty("userDetail")]
        public Details UserDetails { get; set; }

    }

    public class MetaRequest
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
        public string is_driver_started { get; set; }
        [JsonProperty("is_driver_arrived")]
        public string Is_driver_arrived { get; set; }
        [JsonProperty("is_trip_start")]
        public string Is_trip_start { get; set; }
        [JsonProperty("is_completed")]
        public string Is_completed { get; set; }

        [JsonProperty("is_cancelled")]
        public string Is_cancelled { get; set; }
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
        public decimal Pick_lat { get; set; }

        [JsonProperty("pick_lng")]
        public decimal Pick_lng { get; set; }
        [JsonProperty("drop_lat")]
        public decimal Drop_lat { get; set; }
        [JsonProperty("drop_lng")]
        public decimal Drop_lng { get; set; }
        [JsonProperty("pick_address")]
        public string Pick_address { get; set; }
        [JsonProperty("drop_address")]
        public string Drop_address { get; set; }

        [JsonProperty("userDetail")]
        public Details UserDetails { get; set; }

    }
    public class Details
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
        [JsonProperty("email_confirmed")]
        public string Email_confirmed { get; set; }
        [JsonProperty("mobile_confirmed")]
        public long Mobile_confirmed { get; set; }
        [JsonProperty("last_known_ip")]
        public string Last_known_ip { get; set; }
        [JsonProperty("last_login_at")]
        public DateTime? Last_login_at { get; set; }
    }
    public class IsRequest
    {
        [JsonProperty("trip")]
        public bool Trip { get; set; }
    }
    public class DriverStatus
    {
        [JsonProperty("is_active")]
        public int Is_Active { get; set; }
        [JsonProperty("is_approve")]
        public int Is_Approve { get; set; }
        [JsonProperty("is_available")]
        public int Is_Available { get; set; }
        [JsonProperty("document_upload_status")]
        public bool Document_Upload_Status { get; set; }
    }

    public class DriverHistoryListModel
    {
        [JsonProperty("history")]
        public History History { get; set; }
    }

    public class History
    {
        [JsonProperty("request_id")]
        public string Request_Id { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("later")]
        public int Later { get; set; }

        [JsonProperty("ride_later_custom_driver")]
        public int Ride_Later_Custom_Driver { get; set; }

        [JsonProperty("is_share")]
        public string Is_Share { get; set; }

        [JsonProperty("user_id")]
        public int User_Id { get; set; }

        [JsonProperty("pick_latitude")]
        public Double Pick_Latitude { get; set; }

        [JsonProperty("pick_longitude")]
        public Double Pick_Longitude { get; set; }

        [JsonProperty("drop_latitude")]
        public Double Drop_Latitude { get; set; }

        [JsonProperty("drop_longitude")]
        public Double Drop_Longitude { get; set; }

        [JsonProperty("pick_location")]
        public string Pick_Location { get; set; }

        [JsonProperty("drop_location")]
        public string Drop_Location { get; set; }

        [JsonProperty("trip_start_time")]
        public DateTime Trip_Start_Time { get; set; }

        [JsonProperty("is_completed")]
        public int Is_Completed { get; set; }

        [JsonProperty("is_cancelled")]
        public int Is_Cancelled { get; set; }

        [JsonProperty("driver_id")]
        public int Driver_Id { get; set; }

        [JsonProperty("car_model")]
        public string Car_Model { get; set; }

        [JsonProperty("car_number")]
        public string Car_Number { get; set; }

        [JsonProperty("driver_type")]
        public int Driver_Type { get; set; }

        [JsonProperty("user_profile_pic")]
        public string User_Profile_Pic { get; set; }

        [JsonProperty("type_icon")]
        public string Type_Icon { get; set; }

        [JsonProperty("type_name")]
        public string Type_Name { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("totalAdditionalCharge")]
        public int TotalAdditionalCharge { get; set; }

        [JsonProperty("AdditionalCharge")]
        public List<int> Charge { get; set; }
    }

    public class TripCancelModel
    {

    }

    public class TripStartModel
    {

    }

    public class HistoryDetailModel
    {
        [JsonProperty("request")]
        public Request Request { get; set; }
    }
    public class Request
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("bill")]
        public Bill Bill { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("is_share")]
        public int Is_Share { get; set; }

        [JsonProperty("later")]
        public int Later { get; set; }

        [JsonProperty("ride_later_custom_driver")]
        public int Ride_Later_Custom_Driver { get; set; }

        [JsonProperty("show_driver_start_btn")]
        public int Show_Driver_Start_Btn { get; set; }

        [JsonProperty("request_id")]
        public string Request_Id { get; set; }

        [JsonProperty("pick_latitude")]
        public Double Pick_Latitude { get; set; }

        [JsonProperty("pick_longitude")]
        public Double Pick_Longitude { get; set; }

        [JsonProperty("drop_latitude")]
        public Double Drop_Latitude { get; set; }

        [JsonProperty("drop_longitude")]
        public Double Drop_Longitude { get; set; }

        [JsonProperty("pick_location")]
        public string Pick_Location { get; set; }

        [JsonProperty("drop_location")]
        public string Drop_Location { get; set; }

        [JsonProperty("trip_start_time")]
        public DateTime Trip_Start_Time { get; set; }

        [JsonProperty("is_completed")]
        public int Is_Completed { get; set; }

        [JsonProperty("is_cancelled")]
        public int Is_Cancelled { get; set; }

        [JsonProperty("payment_opt")]
        public int Payment_Opt { get; set; }

        [JsonProperty("driver_id")]
        public int Driver_Id { get; set; }

        [JsonProperty("enable_dispute_button")]
        public bool Enable_Dispute_Button { get; set; }

        [JsonProperty("car_model")]
        public string Car_Model { get; set; }

        [JsonProperty("car_number")]
        public string Car_Number { get; set; }

        [JsonProperty("driver_type")]
        public int Driver_Type { get; set; }

        [JsonProperty("type_icon")]
        public string Type_Icon { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }
    }

    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("profile_pic")]
        public string Profile_Pic { get; set; }

        [JsonProperty("review")]
        public double Review { get; set; }

        [JsonProperty("phone_number")]
        public string Phone_Number { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
    public class Bill
    {
        [JsonProperty("base_price")]
        public int Base_Price { get; set; }

        [JsonProperty("ride_fare")]
        public int Ride_Fare { get; set; }

        [JsonProperty("base_distance")]
        public int Base_Distance { get; set; }

        [JsonProperty("price_per_distance")]
        public int Price_Per_Distance { get; set; }

        [JsonProperty("price_per_time")]
        public int Price_Per_Time { get; set; }

        [JsonProperty("distance_price")]
        public int Distance_Price { get; set; }

        [JsonProperty("time_price")]
        public int Time_Price { get; set; }

        [JsonProperty("waiting_price")]
        public int Waiting_Price { get; set; }

        [JsonProperty("tollgate_price")]
        public int Tollgate_Price { get; set; }

        [JsonProperty("tollgate_list")]
        public List<int> Tollgate_List { get; set; }

        [JsonProperty("service_tax")]
        public double Service_Tax { get; set; }

        [JsonProperty("service_tax_percentage")]
        public int Service_Tax_Percentage { get; set; }

        [JsonProperty("promo_amount")]
        public int Promo_Amount { get; set; }

        [JsonProperty("referral_amount")]
        public int Referral_Amount { get; set; }

        [JsonProperty("service_fee")]
        public double Service_Fee { get; set; }

        [JsonProperty("driver_amount")]
        public double Driver_Amount { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("show_bill")]
        public int Show_Bill { get; set; }

        [JsonProperty("unit")]
        public int Unit { get; set; }

        [JsonProperty("unit_in_words_without_lang")]
        public string Unit_In_Words_Without_Lang { get; set; }

        [JsonProperty("unit_in_words")]
        public string Unit_In_Words { get; set; }

        [JsonProperty("totalAdditionalCharge")]
        public int TotalAdditionalCharge { get; set; }


        [JsonProperty("AdditionalCharge")]
        public List<int> AdditionalCharge { get; set; }
    }

    public class RequestAcceptedModel
    {
        [JsonProperty("request")]
        public RequestAccept Request { get; set; }
    }
    public class RequestAccept
    {
        [JsonProperty("user")]
        public UserAccept User { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("is_share")]
        public int Is_Share { get; set; }

        [JsonProperty("later")]
        public int Later { get; set; }

        [JsonProperty("ride_later_custom_driver")]
        public int Ride_Later_Custom_Driver { get; set; }

        [JsonProperty("trip_start_time")]
        public DateTime Trip_Start_Time { get; set; }

        [JsonProperty("is_driver_started")]
        public int Is_Driver_Started { get; set; }

        [JsonProperty("is_driver_arrived")]
        public int Is_Driver_Arrived { get; set; }

        [JsonProperty("is_trip_start")]
        public int Is_Trip_Start { get; set; }

        [JsonProperty("is_completed")]
        public int Is_Completed { get; set; }

        [JsonProperty("payment_opt")]
        public int Payment_Opt { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("pick_latitude")]
        public Double Pick_Latitude { get; set; }

        [JsonProperty("pick_longitude")]
        public Double Pick_Longitude { get; set; }

        [JsonProperty("drop_latitude")]
        public Double Drop_Latitude { get; set; }

        [JsonProperty("drop_longitude")]
        public Double Drop_Longitude { get; set; }

        [JsonProperty("pick_location")]
        public string Pick_Location { get; set; }

        [JsonProperty("drop_location")]
        public string Drop_Location { get; set; }
    }
    public class UserAccept
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("profile_pic")]
        public string Profile_Pic { get; set; }

        [JsonProperty("review")]
        public double Review { get; set; }

        [JsonProperty("phone_number")]
        public string Phone_Number { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
    public class RequestBillModel
    {
        [JsonProperty("request")]
        public RequestBill Request { get; set; }
    }
    public class RequestBill
    {
        [JsonProperty("bill")]
        public BillReq Bill { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("request_id")]
        public string Request_Id { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("payment_opt")]
        public int Payment_Opt { get; set; }
    }
    public class BillReq
    {
        [JsonProperty("show_bill")]
        public int Show_Bill { get; set; }

        [JsonProperty("base_price")]
        public int Base_Price { get; set; }

        [JsonProperty("base_distance")]
        public int Base_Distance { get; set; }

        [JsonProperty("price_per_distance")]
        public int Price_Per_Distance { get; set; }

        [JsonProperty("price_per_time")]
        public int Price_Per_Time { get; set; }

        [JsonProperty("distance_price")]
        public int Distance_Price { get; set; }

        [JsonProperty("time_price")]
        public int Time_Price { get; set; }

        [JsonProperty("waiting_price")]
        public int Waiting_Price { get; set; }

        [JsonProperty("tollgate_price")]
        public int Tollgate_Price { get; set; }

        [JsonProperty("tollgate_lists")]
        public List<int> Tollgate_Lists { get; set; }

        [JsonProperty("service_tax")]
        public double Service_Tax { get; set; }

        [JsonProperty("service_tax_percentage")]
        public int Service_Tax_Percentage { get; set; }

        [JsonProperty("promo_amount")]
        public int Promo_Amount { get; set; }

        [JsonProperty("referral_amount")]
        public int Referral_Amount { get; set; }

        [JsonProperty("wallet_amount")]
        public int Wallet_Amount { get; set; }

        [JsonProperty("service_fee")]
        public double Service_Fee { get; set; }

        [JsonProperty("cancellation_fee")]
        public double Cancellation_Fee { get; set; }

        [JsonProperty("driver_amount")]
        public double Driver_Amount { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("conversion")]
        public string Conversion { get; set; }       

        [JsonProperty("unit")]
        public int Unit { get; set; }

        [JsonProperty("unit_in_words_without_lang")]
        public string Unit_In_Words_Without_Lang { get; set; }

        [JsonProperty("unit_in_words")]
        public string Unit_In_Words { get; set; }

        [JsonProperty("trip_start_time")]
        public string Trip_Start_Time { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("totalAdditionalCharge")]
        public int TotalAdditionalCharge { get; set; }

        [JsonProperty("AdditionalCharge")]
        public List<int> AdditionalCharge { get; set; }
    }
    public class TripArrivedModel
    {

    }
    public class RequestRejectModel
    {

    }

}
