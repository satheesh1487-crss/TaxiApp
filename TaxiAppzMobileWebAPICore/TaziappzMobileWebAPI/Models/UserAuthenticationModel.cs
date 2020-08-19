using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Models
{
    public class UserOTPValidateModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }

    public class UserSignUpModel
    {
        [JsonProperty("corporate")]
        public int corporate { get; set; }

        [JsonProperty("user")]
        public UserSignup User { get; set; }

        [JsonProperty("sos")]
        public List<UserSos> Sos { get; set; }
    }
    public class UserSos
    {

    }
    public class UserSignup
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

    public class UserLoginModel
    {
        [JsonProperty("corporate")]
        public int corporate { get; set; }

        [JsonProperty("user")]
        public UserLogin User { get; set; }

        [JsonProperty("sos")]
        public List<LoginSos> Sos { get; set; }
    }
    public class LoginSos
    {

    }
    public class UserLogin
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
    public class LoginOtpModel
    {
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
    public class LoginResendOtpModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
    public class LoginSendOtpModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
    public class ForgotPasswordModel
    {
        [JsonProperty("user")]
        public UserForgot User { get; set; }
    }
    public class UserForgot
    {
        [JsonProperty("is_presented")]
        public bool Is_Presented { get; set; }
    }
}
