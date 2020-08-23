using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class ETAListTypesModel
    {
        [JsonProperty("data")]
        public List<ETAData> Data { get; set; }

        [JsonProperty("types")]
        public List<ETAData> Types { get; set; }
    }
    public class ETAData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type_id")]
        public int Type_Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("capacity")]
        public int Capacity { get; set; }

        [JsonProperty("driver_search_radius")]
        public string Driver_Search_Radius { get; set; }

        [JsonProperty("is_accept_share_ride")]
        public int Is_Accept_Share_Ride { get; set; }

        [JsonProperty("payment_type")]
        public List<Payment_Type> Payment_Type { get; set; }

        [JsonProperty("active")]
        public int Active { get; set; }

        [JsonProperty("preferred_payment")]
        public int Preferred_Payment { get; set; }
    }
    public class Payment_Type
    {
        [JsonProperty("card")]
        public int Card { get; set; }

        [JsonProperty("cash")]
        public int Cash { get; set; }

        [JsonProperty("wallet")]
        public int Wallet { get; set; }
    }
   
    public class ETAListModel
    {
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

        [JsonProperty("type_name")]
        public string Type_Name { get; set; }

        [JsonProperty("is_accept_share_ride")]
        public int Is_Accept_Share_Ride { get; set; }

        [JsonProperty("base_share_ride_price")]
        public int Base_Share_Ride_Price { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("share_ride_details")]
        public Share_Ride Share_Ride_Details { get; set; }       

        [JsonProperty("unit_in_words_without_lang")]
        public string Unit_In_Words_Without_Lang { get; set; }

        [JsonProperty("unit_in_words")]
        public string Unit_In_Words { get; set; }

        [JsonProperty("driver_arival_estimation")]
        public string Driver_Arival_Estimation { get; set; }
    }    
}
