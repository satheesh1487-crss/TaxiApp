using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaziappzMobileWebAPI.Interface;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        private IValidate validate;
        public UserAuthenticationController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("oTPValidate")]
        public IActionResult OTPValidate(GeneralModel generalModel)
        {
            UserOTPValidateModel userOTPValidateModel = new UserOTPValidateModel();
            userOTPValidateModel.Token = "$2y$10$R5FO7pys3hgE8Sfy2gBR7.msCpEmviVTLjaRiq.l5NEwUjNAYiiZ.";
            return this.OKRESPONSE<UserOTPValidateModel>(userOTPValidateModel, userOTPValidateModel == null ? "User_History_Not_Found" : "User_History_found");
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult Signup(GeneralModel generalModel)
        {
            UserSignUpModel userSignUpModel = new UserSignUpModel();
            userSignUpModel.User = new UserSignup();
            userSignUpModel.Sos = new List<UserSos>();
            userSignUpModel.User.Id = 32;
            userSignUpModel.User.FirstName = "RAJESH";
            userSignUpModel.User.LastName = "KANNAN";
            userSignUpModel.User.Email = "raj@gmail.com";
            userSignUpModel.User.Phone = "+919865365236";
            userSignUpModel.User.Login_By = "android";
            userSignUpModel.User.Login_Method = "manual";
            userSignUpModel.User.Token = "$2y$10$R5FO7pys3hgE8Sfy2gBR7.msCpEmviVTLjaRiq.l5NEwUjNAYiiZ.";
            userSignUpModel.User.Profile_Pic = "";
            userSignUpModel.User.Is_Active = 1;
            userSignUpModel.User.Corporate = 0;
            userSignUpModel.corporate = 0;
            return this.OKRESPONSE<UserSignUpModel>(userSignUpModel, userSignUpModel == null ? "User_SignUp_Not_Found" : "User_SignUp_found");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(GeneralModel generalModel)
        {
            UserLoginModel userLoginModel = new UserLoginModel();
            userLoginModel.User = new UserLogin();
            userLoginModel.Sos = new List<LoginSos>();
            userLoginModel.User.Id = 32;
            userLoginModel.User.FirstName = "RAJESH";
            userLoginModel.User.LastName = "KANNAN";
            userLoginModel.User.Email = "raj@gmail.com";
            userLoginModel.User.Phone = "+919865365236";
            userLoginModel.User.Login_By = "android";
            userLoginModel.User.Login_Method = "manual";
            userLoginModel.User.Token = "$2y$10$R5FO7pys3hgE8Sfy2gBR7.msCpEmviVTLjaRiq.l5NEwUjNAYiiZ.";
            userLoginModel.User.Profile_Pic = "";
            userLoginModel.User.Is_Active = 1;
            userLoginModel.User.Corporate = 0;
            userLoginModel.corporate = 0;
            return this.OKRESPONSE<UserLoginModel>(userLoginModel, userLoginModel == null ? "User_Login_Not_Found" : "User_Login_found");
        }

        [HttpPost]
        [Route("otp")]
        public IActionResult Otp(GeneralModel generalModel)
        {
            LoginOtpModel loginOtpModel = new LoginOtpModel();
            loginOtpModel.PhoneNumber = "+919653698745";
            return this.OKRESPONSE<LoginOtpModel>(loginOtpModel, loginOtpModel == null ? "Login_OTP_Not_Found" : "Login_OTP_found");
        }

        [HttpPost]
        [Route("resendotp")]
        public IActionResult Resendotp(GeneralModel generalModel)
        {
            LoginResendOtpModel loginResendOtpModel = new LoginResendOtpModel();
            loginResendOtpModel.Token = "$2y$10$kuh/fg8wdcFhuSK8wOx8/O2sZdGT4FbIFuSZRh0Oq1JD45UFmdv3u";
            return this.OKRESPONSE<LoginResendOtpModel>(loginResendOtpModel, loginResendOtpModel == null ? "Resend_OTP_Not_Found" : "Resend_OTP_found");
        }

        [HttpPost]
        [Route("sendotp")]
        public IActionResult Sendotp(GeneralModel generalModel)
        {
            LoginSendOtpModel loginSendOtpModel = new LoginSendOtpModel();
            loginSendOtpModel.Token = "$2y$10$kuh/fg8wdcFhuSK8wOx8/O2sZdGT4FbIFuSZRh0Oq1JD45UFmdv3u";
            return this.OKRESPONSE<LoginSendOtpModel>(loginSendOtpModel, loginSendOtpModel == null ? "Send_OTP_Not_Found" : "Send_OTP_found");
        }

        [HttpPost]
        [Route("forgotpassword")]
        public IActionResult ForgotPassword(GeneralModel generalModel)
        {
            ForgotPasswordModel forgotPasswordModel = new ForgotPasswordModel();
            forgotPasswordModel.User = new UserForgot();
            forgotPasswordModel.User.Is_Presented = true;
            return this.OKRESPONSE<ForgotPasswordModel>(forgotPasswordModel, forgotPasswordModel == null ? "Forgot_Password_Not_Found" : "Forgot_Password_found");
        }
    }
}
