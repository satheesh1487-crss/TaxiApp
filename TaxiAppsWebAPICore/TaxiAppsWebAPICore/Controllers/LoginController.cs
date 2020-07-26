using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
         private readonly TaxiAppzDBContext _context;
        public LoginController(TaxiAppzDBContext context)
        {
          _context = context;
       }      

        [HttpPost("LoginUser"),AllowAnonymous]

        public IActionResult Login([FromBody] LoginRequest admin)
        {
            UserInfo userInfo = new UserInfo();
            List<TabAdmin> adminlist = _context.TabAdmin.ToList();
            var user = new UserInfo();
            var IQAdmin = _context.TabAdmin.Include(a => a.RoleNavigation).Where(a => a.Email == admin.Email && a.Password == admin.Password).FirstOrDefault();
            if (IQAdmin != null)
            {
                var tokenString = Extention.GenerateJWTToken(IQAdmin, _context);
                user = new UserInfo() { Email = admin.Email, RememberToken = tokenString, Role = IQAdmin.RoleNavigation.RoleName, ExpireDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.AddMinutes(300)),InsertedDate = IQAdmin.CreatedAt };
                bool updatetoken = Extention.UpdateToken(IQAdmin.Id,user, _context);

                return this.OK<UserInfo>(user);
            }
            return this.OKFailed("Invalid Credentials");
        }
       //    return response;
    }
}

