using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class RequestInProgressModel
    {
        [JsonProperty("share_status")]
        public bool Share_Status { get; set; }

        [JsonProperty("enable_referral")]
        public bool Enable_Referral { get; set; }


        [JsonProperty("admin_phone_number")]
        public string Admin_Phone_Number { get; set; }

        [JsonProperty("customer_care_number")]
        public string Customer_Care_Number { get; set; }

        [JsonProperty("request")]
        public IsRequest Request { get; set; }

        [JsonProperty("driver_status")]
        public DriverStatus Driver_Status { get; set; }
        [JsonProperty("sos")]
        public List<string> Emergecy { get;set; }

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
}
