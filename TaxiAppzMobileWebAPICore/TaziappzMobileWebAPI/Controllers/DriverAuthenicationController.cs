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
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverAuthenicationController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        private IValidate validate;
        public ISign sign;
        public IToken token;
        public readonly IOptions<JWT> jwt;
        public DriverAuthenicationController(TaxiAppzDBContext context, ISign _sign, IToken _token, IOptions<JWT> _jwt)
        {
            _context = context;
            token = _token;
            sign = _sign;
            jwt = _jwt;
        }

        #region Driver Mobile no Validation
        /// <summary>
        /// Driver Contact Number Validation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("DriverValidateContactNo")]
        public IActionResult ValidateMobileno(string contactno)
        {
            SignInmodel signinmodel = new SignInmodel();
            signinmodel.Contactno = contactno;
            validate = new DADriverValidate(_context);
            bool status = validate.MobileValidation(signinmodel);
            return this.OKStatus(status ? "phoneValidated" : "phoneInValidated", status ? 1 : 0);
        }
        #endregion

        /// <summary>
        /// Use to Get Existing Driver records
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("DriverSignIndetails")]
        public IActionResult DriverSignIndetails([FromBody] SignInmodel signInmodel)
        {
            sign = new DASign(_context, token);
            List<DetailsWithDriverToken> detailsWithToken = new List<DetailsWithDriverToken>();
            detailsWithToken = sign.SignInDriver(signInmodel);
            return this.OK<List<DetailsWithDriverToken>>(detailsWithToken, detailsWithToken.Count == 0 ? "User_SignDetails_Not_Found" : "User_Signdetails_Found", detailsWithToken.Count == 0 ? 0 : 1);
        }
        /// <summary>
        /// Use to Register Driver
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("RegisterDriver")]
        public IActionResult RegisterDriver([FromBody] SignUpDrivermodel signUpmodel)
        {
            sign = new DASign(_context, token);
            bool result = sign.SignUpDriver(signUpmodel);
            return this.OKStatus(result ? "Driver_Creation_Success" : "Driver_Creation_Failed", result ? 1 : 0);
        }
        /// <summary>
        /// Use to Regenerate AccessToken once Session Exipred
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("DriverRegenerateAccessToken")]
        public IActionResult RegenerateAccessToken(string refreshtoken, string contactno)
        {
            token = new Token(_context, jwt);
            List<DetailsWithDriverToken> detailsWithToken = new List<DetailsWithDriverToken>();
            detailsWithToken = token.ReGenerateDriverJWTTokenDtls(refreshtoken, contactno); //(List)token.ReGenerateJWTTokenDtls(refreshtoken, contactno);
            return this.OK<List<DetailsWithDriverToken>>(detailsWithToken, detailsWithToken.Count == 0 ? "Access token Generation Failed" : "Access token Generated Successfully", detailsWithToken.Count == 0 ? 0 : 1);
        }


    }
}
