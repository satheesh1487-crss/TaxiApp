﻿using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("LoginUser"),AllowAnonymous]

        public IActionResult Login([FromBody] LoginRequest admin)
        {
            return this.OK<UserInfo>(_token.GenerateJWTTokenDtls(admin));
            //UserInfo userInfo = new UserInfo();
            //DARoles dARoles = new DARoles();
            //List<TabAdmin> adminlist = _context.TabAdmin.ToList();
            //var user = new UserInfo();
            //var IQAdmin = _context.TabAdmin.Include(a => a.RoleNavigation).Where(a => a.Email.ToLower().Contains(admin.Email.ToLower()) && a.Password == admin.Password).FirstOrDefault();
            //if (IQAdmin != null)
            //{
            //    var tokenString = Extention.GenerateJWTToken(IQAdmin, _context);
            //    user = new UserInfo() { Email = admin.Email, RememberToken = tokenString,
            //        Role = IQAdmin.RoleNavigation.RoleName,
            //        Menukey = dARoles.GetMenukey(IQAdmin.RoleNavigation.RoleName,_context),
            //        ExpireDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.AddMinutes(300)),InsertedDate = IQAdmin.CreatedAt };
            //    bool updatetoken = Extention.UpdateToken(IQAdmin.Id,user, _context);

            //    return this.OK<UserInfo>(user);
            //}
            //return this.OKFailed("Invalid Credentials");
        }
        //    return response;
        [HttpPost("RegenerateToken"), AllowAnonymous]
        public IActionResult RegenerateToken(string refreshtoken,string emailid)
        {
            return this.OK<UserInfo>(_token.ReGenerateJWTTokenDtls(refreshtoken,emailid));
            //UserInfo userInfo = new UserInfo();
            //DARoles dARoles = new DARoles();
            //List<TabAdmin> adminlist = _context.TabAdmin.ToList();
            //var user = new UserInfo();
            //var IQAdmin = _context.TabAdmin.Include(a => a.RoleNavigation).Where(a => a.Email.ToLower().Contains(admin.Email.ToLower()) && a.Password == admin.Password).FirstOrDefault();
            //if (IQAdmin != null)
            //{
            //    var tokenString = Extention.GenerateJWTToken(IQAdmin, _context);
            //    user = new UserInfo() { Email = admin.Email, RememberToken = tokenString,
            //        Role = IQAdmin.RoleNavigation.RoleName,
            //        Menukey = dARoles.GetMenukey(IQAdmin.RoleNavigation.RoleName,_context),
            //        ExpireDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.AddMinutes(300)),InsertedDate = IQAdmin.CreatedAt };
            //    bool updatetoken = Extention.UpdateToken(IQAdmin.Id,user, _context);

            //    return this.OK<UserInfo>(user);
            //}
            //return this.OKFailed("Invalid Credentials");
        }
    }
}

