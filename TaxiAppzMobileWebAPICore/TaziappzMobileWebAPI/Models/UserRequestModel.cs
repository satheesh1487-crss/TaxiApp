using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class UserHistoryModel
    {
        [JsonProperty("request")]
        public UserRequest UserRequest { get; set; }
    }
    public class UserRequest
    {
        [JsonProperty("driver")]
        public Drivers Driver { get; set; }

        [JsonProperty("userBill")]
        public UserBill UserBill { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("is_share")]
        public int Is_Share { get; set; }

        [JsonProperty("later")]
        public int Later { get; set; }

        [JsonProperty("user_id")]
        public int User_Id { get; set; }

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

        [JsonProperty("enable_dispute_button")]
        public bool Enable_Dispute_Button { get; set; }

        [JsonProperty("driver_type")]
        public int Driver_Type { get; set; }

        [JsonProperty("type_icon")]
        public string Type_Icon { get; set; }

        [JsonProperty("type_name")]
        public string Type_Name { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }
    }
    public class Drivers
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("profile_pic")]
        public string Profile_Pic { get; set; }

        [JsonProperty("car_model")]
        public string Car_Model { get; set; }

        [JsonProperty("car_number")]
        public string Car_Number { get; set; }

        [JsonProperty("review")]
        public double Review { get; set; }

        [JsonProperty("phone_number")]
        public string Phone_Number { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
    public class UserBill
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

        [JsonProperty("wallet_amount")]
        public int Wallet_Amount { get; set; }

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

    public class UserHistoryListModel
    {
        [JsonProperty("history")]
        public UserHistory History { get; set; }
    }

    public class UserHistory
    {
        [JsonProperty("request_id")]
        public string Request_Id { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("later")]
        public int Later { get; set; }

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

        [JsonProperty("driver_profile_pic")]
        public string Driver_Profile_Pic { get; set; }

        [JsonProperty("type_icon")]
        public string Type_Icon { get; set; }

        [JsonProperty("type_name")]
        public string Type_Name { get; set; }

        [JsonProperty("ride_fare")]
        public int Ride_Fare { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("totalAdditionalCharge")]
        public int TotalAdditionalCharge { get; set; }

        [JsonProperty("AdditionalCharge")]
        public List<int> Charge { get; set; }

        [JsonProperty("enable_dispute_button")]
        public bool Enable_Dispute_Button { get; set; }
    }
    public class TempTokenModel
    {
        [JsonProperty("corporate")]
        public int Corporate { get; set; }

        [JsonProperty("request")]
        public Request Request { get; set; }

        [JsonProperty("sos")]
        public string Sos { get; set; }

        [JsonProperty("user_sos")]
        public string User_Sos { get; set; }
    }
    public class CreateRequestModel
    {

    }

    public class CancelRequestModel
    {

    }
    public class PaymentStatusModel
    {

    }
    public class CreateRequestFirebaseModel
    {
        [JsonProperty("request")]
        public CreateRequest CreateRequest { get; set; }

        [JsonProperty("user")]
        public RequestUser User { get; set; }
    }
    public class CreateRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("request_id")]
        public string Request_Id { get; set; }

        [JsonProperty("pick_latitude")]
        public string Pick_Latitude { get; set; }

        [JsonProperty("pick_longitude")]
        public string Pick_Longitude { get; set; }

        [JsonProperty("drop_latitude")]
        public string Drop_Latitude { get; set; }

        [JsonProperty("drop_longitude")]
        public string Drop_Longitude { get; set; }

        [JsonProperty("pick_location")]
        public string Pick_Location { get; set; }

        [JsonProperty("drop_location")]
        public string Drop_Location { get; set; }

        [JsonProperty("time_left")]
        public string Time_Left { get; set; }
    }
    public class RequestUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("profile_pic")]
        public string Profile_Pic { get; set; }

        [JsonProperty("phone_number")]
        public string Phone_Number { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
    public class EtaFirebaseModel
    {
        [JsonProperty("share_ride_details")]
        public Share_Ride Share_Ride_Details { get; set; }

        [JsonProperty("show_price")]
        public int Show_Price { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("base_distance")]
        public int Base_Distance { get; set; }

        [JsonProperty("base_price")]
        public int Base_Price { get; set; }

        [JsonProperty("price_per_distance")]
        public int Price_Per_Distance { get; set; }

        [JsonProperty("price_per_time")]
        public int Price_Per_Time { get; set; }

        [JsonProperty("distance_price")]
        public double Distance_Price { get; set; }

        [JsonProperty("time_price")]
        public double time_price { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("approximate_value")]
        public int Approximate_Value { get; set; }

        [JsonProperty("min_amount")]
        public int Min_Amount { get; set; }

        [JsonProperty("max_amount")]
        public double Max_Amount { get; set; }

        [JsonProperty("tax")]
        public string Tax { get; set; }

        [JsonProperty("tax_amount")]
        public double Tax_Amount { get; set; }

        [JsonProperty("ride_fare")]
        public double Ride_Fare { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("type_id")]
        public string Type_Id { get; set; }

        [JsonProperty("is_private_key_trip")]
        public bool Is_Private_Key_Trip { get; set; }

        [JsonProperty("type_name")]
        public string Type_Name { get; set; }

        [JsonProperty("is_accept_share_ride")]
        public int Is_Accept_Share_Ride { get; set; }

        [JsonProperty("base_share_ride_price")]
        public int Base_Share_Ride_Price { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("unit_in_words_without_lang")]
        public string Unit_In_Words_Without_Lang { get; set; }

        [JsonProperty("unit_in_words")]
        public string Unit_In_Words { get; set; }

        [JsonProperty("driver_arival_estimation")]
        public string Driver_Arival_Estimation { get; set; }

        [JsonProperty("drop_out_of_zone_fee")]
        public string Drop_Out_Of_Zone_Fee { get; set; }

        [JsonProperty("promo_available")]
        public int Promo_Available { get; set; }
    }
    public class Share_Ride
    {
        [JsonProperty("number_of_seats")]
        public int Number_Of_Seats { get; set; }

        [JsonProperty("subtotal_price")]
        public double Subtotal_Price { get; set; }

        [JsonProperty("tax_amount")]
        public double Tax_Amount { get; set; }

        [JsonProperty("total_price")]
        public double Total_Price { get; set; }
    }   
}
