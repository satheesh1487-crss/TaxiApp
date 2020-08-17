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
    public class UserController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        public ISign sign;
        public IToken token;
        public UserController(TaxiAppzDBContext context, ISign _sign, IToken _token)
        {
            _context = context;
           sign = _sign;
            token = _token;
          
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
            DetailsWithToken detailsWithToken = new DetailsWithToken();
            detailsWithToken = sign.SignIn(signInmodel);
            return this.OK<DetailsWithToken>(detailsWithToken, detailsWithToken.IsExist == 1 ? "User Data Found" : "Details Not Found", detailsWithToken.IsExist);
        }
        /// <summary>
        /// Use to Register User
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("RegisterUser")]
        public IActionResult RegisterUser([FromBody] SignUpmodel signUpmodel)
        {
            sign = new DASign(_context, token);
            bool result = sign.SignUp(signUpmodel);
            return this.OKStatus(result ? "User Creation Success" : "User Creation Failed", result ? 1 : 0);
        }

    }
}
