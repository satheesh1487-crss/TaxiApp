using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.Services;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
       //  private readonly TaxiAppzDBContext _context;
        private readonly IToken _token;
        public LoginController(IToken token)
        {
         // _context = context;
            _token = token;
        }
        /// <summary>
        /// Use to Generate Fresh JWT Token
        /// </summary>
        /// <returns></returns>
        [HttpPost("LoginUser"),AllowAnonymous]

        public IActionResult Login([FromBody] LoginRequest admin)
        {
            return this.OK<UserInfo>(_token.GenerateJWTTokenDtls(admin));
         
        }
        /// <summary>
        /// Use to Re-Generate JWT Token once expried current expired time is 5 mins
        /// </summary>
        /// <returns></returns>
        [HttpPost("RegenerateToken"), AllowAnonymous]
        public IActionResult RegenerateToken(string refreshtoken,string emailid)
        {
            return this.OK<UserInfo>(_token.ReGenerateJWTTokenDtls(refreshtoken,emailid));
         
        }
    }
}

