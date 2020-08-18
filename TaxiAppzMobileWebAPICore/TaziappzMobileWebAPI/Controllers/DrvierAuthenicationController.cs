using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.Services;
using TaziappzMobileWebAPI.DALayer;
using TaziappzMobileWebAPI.Interface;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrvierAuthenicationController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        private IValidate validate;
        public ISign sign;
        public IToken token;
        public DrvierAuthenicationController(TaxiAppzDBContext context, ISign _sign, IToken _token)
        {
            _context = context;
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
            return this.OKStatus(status ? "phoneValidated" : "phoneInValidated");
        }
        #endregion

        /// <summary>
        /// Use to Get Existing user records
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("DriverSignIndetails")]
        public IActionResult DriverSignIndetails([FromBody] SignInmodel signInmodel)
        {
            sign = new DASign(_context, token);
            List<DetailsWithToken> detailsWithToken = new List<DetailsWithToken>();
            detailsWithToken = sign.SignIn(signInmodel,"DRIVER");
            return this.OK<DetailsWithToken>(detailsWithToken, detailsWithToken.Count == 1 ? "User_Signdetails_Found" : "User_SignDetails_Not_Found");
        }
    }
}
