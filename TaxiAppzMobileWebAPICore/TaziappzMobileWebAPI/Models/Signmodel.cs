﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI 
{
    public class SignUpmodel
    {
        
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        [JsonProperty("mobileno")]
        public string Mobileno { get; set; }
        [JsonProperty("emailid")]
        public string Emailid { get; set; }
        [JsonProperty("servicelocationid")]
        public long Servicelocationid { get; set; }
        //[JsonProperty("timezone")]
        //public long Timezone { get; set; }

    }
    public class DetailsWithToken : SignUpmodel
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("token")]
        public string AccessToken { get; set; }
        [JsonProperty("refreshtoken")]
        public string RefreshToken { get; set; }
        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }
        //[JsonProperty("success_message")]
        //public string Status { get; set; }
        //[JsonProperty("success")]
        //public bool Success { get; set; }
        [JsonProperty("isExist")]
        public int IsExist { get; set; }

    }
    public class DetailsWithDriverToken : SignUpmodel
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("token")]
        public string AccessToken { get; set; }
        [JsonProperty("refreshtoken")]
        public string RefreshToken { get; set; }
        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }
        [JsonProperty("login_by")]
        public string Login_by { get; set; }
        [JsonProperty("login_method")]
        public bool Login_method { get; set; }
        [JsonProperty("is_approve")]
        public bool Is_approve { get; set; }
        [JsonProperty("is_available")]
        public bool Is_available { get; set; }
        [JsonProperty("car_model")]
        public bool Car_model { get; set; }
        [JsonProperty("car_number")]
        public bool Car_number { get; set; }
        [JsonProperty("type_name")]
        public bool Type_name { get; set; }
        [JsonProperty("isExist")]
        public int IsExist { get; set; }

    }
    public class SignInmodel
    {
        [JsonProperty("loginMethod")]
        public string LoginMethod { get; set; }
        [JsonProperty("contactno")]
        public string Contactno { get; set; }
        [JsonProperty("devicetoken")]
        public string Devicetoken { get; set; }
        [JsonProperty("loginBy")]
        public string LoginBy { get; set; }

    }
}
