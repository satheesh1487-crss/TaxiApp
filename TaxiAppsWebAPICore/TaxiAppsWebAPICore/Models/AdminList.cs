using Newtonsoft.Json;
using System;

namespace TaxiAppsWebAPICore
{
    public class AdminList
    {
        private string isactive;
        [JsonProperty("registerCode")]
        public string RegistrationCode { get; set; }
        //[JsonProperty("language")]
        //public string Language { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        //[JsonProperty("emailID")]
        //public string EmailID { get; set; }
        [JsonProperty("contactNo")]
        public string ContactNo { get; set; }
        //[JsonProperty("role")]
        //public string Role { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("isActive")]
        public string IsActive { 
            get { return isactive; }  
            set { isactive = value == "1" ? "ACTIVE" : "INACTIVE"; } 
        }
        [JsonProperty("areaName")]
        public string AreaName { get; set; }
        [JsonProperty("emergencyContactNo")]
        public string EmergencyContactNo { get; set; }
        // public long RoleID { get; set; }
        [JsonProperty("role")]
        public Roles Role { set; get; }
        [JsonProperty("language")]
        public Language Language { set; get; }
        [JsonProperty("country")]
        public Country Country { set; get; }
        [JsonProperty("adminDetails")]
        public AdminDetails AdminDetails { set; get; }
    }
}
