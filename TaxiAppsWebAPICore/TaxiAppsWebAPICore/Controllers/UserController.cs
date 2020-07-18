using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
            public  UserController(TaxiAppzDBContext context)
            {
            _context = context;
           }
        //[HttpGet]
        //[Route("GetUserData")]
        //[Authorize(Policy = Policies.User)]
        //public IActionResult GetUserData()
        //{
        //    return Ok("This is a response from user method");
        //}
        /// <summary>
        /// Use to display List of Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetsuperAdminData")]
        [Authorize(Policy = "superAdmin")]
        public IActionResult GetsuperAdminData()
        {
           List<AdminList> adminLists = new List<AdminList>();
            var admindata = _context.TabAdmin.Include(l => l.LanguageNavigation).Include(r => r.RoleNavigation).
                Include(z => z.ZoneAccessNavigation).ToList();
            foreach (var admin in admindata)
            {
                adminLists.Add(new AdminList()
                {
                    RegistrationCode = admin.RegistrationCode,
                    FirstName = admin.Firstname,
                    LastName = admin.Lastname,
                    EmailID = admin.Email,
                    ContactNo = admin.PhoneNumber,
                    AreaName = admin.AreaName,
                    EmergencyContactNo = admin.EmergencyNumber,
                    IsActive = admin.IsActive.ToString(),
                    Role = new Roles() { RoleID = admin.RoleNavigation.Roleid, RoleName = admin.RoleNavigation.RoleName,
                        DisplayName = admin.RoleNavigation.DisplayName },
                    Language = new Language() { LanguageID = admin.LanguageNavigation.Languageid,
                        LongName = admin.LanguageNavigation.Name, ShortName = admin.LanguageNavigation.ShortLang },
                    Countrys = new Country() { CountryID = admin.ZoneAccessNavigation.CountryId,
                        TimeZone = admin.ZoneAccessNavigation.TimeZone }

                }) ;
            }
            return this.OK<List<AdminList>>(adminLists);
        }

     [HttpGet]
        [Route("GetUserData")]
        [Authorize]
        public IActionResult GetUserData()
        {
            List<UserListModel> adminLists = new List<UserListModel>();
            adminLists.Add(new UserListModel() { UserID=1,Name="Ram Kumar",EMail="ram@gmail.com",phoneNo="+919994203132" });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Ram Kumar", EMail = "ram@gmail.com", phoneNo = "+919994203134" });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Satheesh Kumar", EMail = "satheesh@gmail.com", phoneNo = "+919994203135" });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Prakash Kumar", EMail = "prakash@gmail.com", phoneNo = "+919994203136" });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Kannan Kumar", EMail = "kannan@gmail.com", phoneNo = "+919994203137" });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Sundar Kumar", EMail = "sundar@gmail.com", phoneNo = "+919994203139" });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Sundar Ganesh", EMail = "sundar@gmail.com", phoneNo = "+919994203130" });
            return this.OK<List<UserListModel>>(adminLists);
        }
        //[HttpGet("GetAdminData")]
       
        //[Authorize(Policy = Policies.Admin)]
        //public IActionResult GetAdminData()
        //{
        //    return Ok("This is a response from Admin method");
        //}
    }
}
