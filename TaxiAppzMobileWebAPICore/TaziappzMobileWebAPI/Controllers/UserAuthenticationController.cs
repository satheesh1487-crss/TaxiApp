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

        #region Authentication_oTPValidate
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("oTPValidate")]
        public IActionResult OTPValidate(GeneralModel generalModel)
        {
            List<UserOTPValidateModel> userOTPValidateModel = new List<UserOTPValidateModel>();
            userOTPValidateModel[0].Token = "$2y$10$R5FO7pys3hgE8Sfy2gBR7.msCpEmviVTLjaRiq.l5NEwUjNAYiiZ.";
            return this.OK<List<UserOTPValidateModel>>(userOTPValidateModel, userOTPValidateModel == null ? "User_History_Not_Found" : "User_History_found", userOTPValidateModel == null ? 0 : 1);
        }
        #endregion

        #region Authentication_signup
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("signup")]
        public IActionResult Signup(GeneralModel generalModel)
        {
            List<UserSignUpModel> userSignUpModel = new List<UserSignUpModel>();
            userSignUpModel[0].User = new UserSignup();
            userSignUpModel[0].Sos = new List<UserSos>();
            userSignUpModel[0].User.Id = 32;
            userSignUpModel[0].User.FirstName = "RAJESH";
            userSignUpModel[0].User.LastName = "KANNAN";
            userSignUpModel[0].User.Email = "raj@gmail.com";
            userSignUpModel[0].User.Phone = "+919865365236";
            userSignUpModel[0].User.Login_By = "android";
            userSignUpModel[0].User.Login_Method = "manual";
            userSignUpModel[0].User.Token = "$2y$10$R5FO7pys3hgE8Sfy2gBR7.msCpEmviVTLjaRiq.l5NEwUjNAYiiZ.";
            userSignUpModel[0].User.Profile_Pic = "";
            userSignUpModel[0].User.Is_Active = 1;
            userSignUpModel[0].User.Corporate = 0;
            userSignUpModel[0].corporate = 0;
            return this.OK<List<UserSignUpModel>>(userSignUpModel, userSignUpModel == null ? "User_SignUp_Not_Found" : "User_SignUp_found", userSignUpModel == null ? 0 : 1);
        }
        #endregion

        #region Authentication_login
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public IActionResult Login(GeneralModel generalModel)
        {
            List<UserLoginModel> userLoginModel = new List<UserLoginModel>();
            userLoginModel[0].User = new UserLogin();
            userLoginModel[0].Sos = new List<LoginSos>();
            userLoginModel[0].User.Id = 32;
            userLoginModel[0].User.FirstName = "RAJESH";
            userLoginModel[0].User.LastName = "KANNAN";
            userLoginModel[0].User.Email = "raj@gmail.com";
            userLoginModel[0].User.Phone = "+919865365236";
            userLoginModel[0].User.Login_By = "android";
            userLoginModel[0].User.Login_Method = "manual";
            userLoginModel[0].User.Token = "$2y$10$R5FO7pys3hgE8Sfy2gBR7.msCpEmviVTLjaRiq.l5NEwUjNAYiiZ.";
            userLoginModel[0].User.Profile_Pic = "";
            userLoginModel[0].User.Is_Active = 1;
            userLoginModel[0].User.Corporate = 0;
            userLoginModel[0].corporate = 0;
            return this.OK<List<UserLoginModel>>(userLoginModel, userLoginModel == null ? "User_Login_Not_Found" : "User_Login_found", userLoginModel == null ? 0 : 1);
        }
        #endregion

        #region Authentication_otp
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("otp")]
        public IActionResult Otp(GeneralModel generalModel)
        {
            List<LoginOtpModel> loginOtpModel = new List<LoginOtpModel>();
            loginOtpModel[0].PhoneNumber = "+919653698745";
            return this.OK<List<LoginOtpModel>>(loginOtpModel, loginOtpModel == null ? "Login_OTP_Not_Found" : "Login_OTP_found", loginOtpModel == null ? 0 : 1);
        }
        #endregion

        #region Authentication_resendotp
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("resendotp")]
        public IActionResult Resendotp(GeneralModel generalModel)
        {
            List<LoginResendOtpModel> loginResendOtpModel = new List<LoginResendOtpModel>();
            loginResendOtpModel[0].Token = "$2y$10$kuh/fg8wdcFhuSK8wOx8/O2sZdGT4FbIFuSZRh0Oq1JD45UFmdv3u";
            return this.OK<List<LoginResendOtpModel>>(loginResendOtpModel, loginResendOtpModel == null ? "Resend_OTP_Not_Found" : "Resend_OTP_found", loginResendOtpModel == null ? 0 : 1);
        }
        #endregion

        #region Authentication_sendotp
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("sendotp")]
        public IActionResult Sendotp(GeneralModel generalModel)
        {
            List<LoginSendOtpModel> loginSendOtpModel = new List<LoginSendOtpModel>();
            loginSendOtpModel[0].Token = "$2y$10$kuh/fg8wdcFhuSK8wOx8/O2sZdGT4FbIFuSZRh0Oq1JD45UFmdv3u";
            return this.OK<List<LoginSendOtpModel>>(loginSendOtpModel, loginSendOtpModel == null ? "Send_OTP_Not_Found" : "Send_OTP_found", loginSendOtpModel == null ? 0 : 1);
        }
        #endregion

        #region Authentication_forgotpassword
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("forgotpassword")]
        public IActionResult ForgotPassword(GeneralModel generalModel)
        {
            List<ForgotPasswordModel> forgotPasswordModel = new List<ForgotPasswordModel>();
            forgotPasswordModel[0].User = new UserForgot();
            forgotPasswordModel[0].User.Is_Presented = true;
            return this.OK<List<ForgotPasswordModel>>(forgotPasswordModel, forgotPasswordModel == null ? "Forgot_Password_Not_Found" : "Forgot_Password_found", forgotPasswordModel == null ? 0 : 1);
        }
        #endregion
    }
}
