using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TaxiAppsWebAPICore.Helper;
using TaxiAppsWebAPICore.Services;
using TaziappzMobileWebAPI.DALayer;
using TaziappzMobileWebAPI.Interface;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        public  IValidate validate;
        public  ISign sign;
        public   IToken token;
        public   readonly IOptions<JWT> jwt;
        public OTPController(TaxiAppzDBContext context,IValidate _validate,ISign _sign,IToken _token,IOptions<JWT> _jwt)
        {
            _context = context;
            validate = _validate;
            sign = _sign;
            token = _token;
            jwt = _jwt;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("GenerateOTP")]
        public IActionResult GenerateOTP([FromBody] OTPModel otpmodel)
        {
            DAOTP otp = new DAOTP();
            return this.OKResponse(otp.GenerateOTP(otpmodel,_context));

        }
        [HttpGet]
        [AllowAnonymous]
        [Route("ValidateOTP")]
        public IActionResult ValidateOTP(long OTP)
        {
            DAOTP otp = new DAOTP();
            return this.OK<UserInfo>(otp.ValidateOTP(OTP, _context));
        }
        /// <summary>
        /// Use to Validate User Contact No
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("ValidateContactNo")]
        public IActionResult ValidateMobileno(string contactno)
        {
            SignInmodel signinmodel = new SignInmodel();
            signinmodel.Contactno = contactno;
            validate = new DAUserValidate(_context);
            bool status = validate.MobileValidation(signinmodel);
            return this.OKStatus(status ? "phoneValidated" : "phoneInValidated", status ? 1 : 0);
        }
        /// <summary>
        /// Use to Get Existing user records
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("UserSignIndetails")]
        public IActionResult UserSignIndetails([FromBody] SignInmodel signInmodel)
        {
            sign = new DASign(_context, token);
            return this.OK<DetailsWithToken>(sign.SignIn(signInmodel));
        }
        /// <summary>
        /// Use to Regenerate AccessToken once Session Exipred
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("RegenerateAccessToken")]
        public IActionResult RegenerateAccessToken(string refreshtoken, string contactno)
        {
            token = new Token(_context, jwt);
            return this.OK<DetailsWithToken>(token.ReGenerateJWTTokenDtls(refreshtoken,contactno));
        }
        /// <summary>
        /// Use to Register User
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[AllowAnonymous]
        //[Route("RegisterUser")]
        //public IActionResult RegisterUser(SignUpmodel signUpmodel)
        //{
        //    token = new Token(_context, jwt);
        //    return this.OK<DetailsWithToken>(token.RegisterUser(refreshtoken, contactno));
        //}


        [HttpGet]
        [Route("getCountry")]
        [Authorize]
        public IActionResult GetCountry()
        {
            DAOTP dAOTP = new DAOTP();
            return this.OK<List<CountryModel>>(dAOTP.GetCountryList(_context));
        }

        [HttpGet]
        [Route("list")]
        [Authorize]
        public IActionResult List(long id)
        {
            DAOTP dAOTP = new DAOTP();
            return this.OK<List<ServiceLocationModel>>(dAOTP.ListService(id,_context));
        }

    }
}
