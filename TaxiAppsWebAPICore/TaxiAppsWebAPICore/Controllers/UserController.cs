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
        //[HttpGet]
        //[Route("GetsuperAdminData")]
        //[Authorize(Policy = "superAdmin")]
        //public IActionResult GetsuperAdminData()
        //{
        //    DARoles dARoles = new DARoles();
        //    return this.OK<List<AdminList>>(dARoles.GetAdminList(_context));
         
        //}

     [HttpGet]
        [Route("UserList")]
        [Authorize]
        public IActionResult GetUserList()
        {
            List<UserListModel> adminLists = new List<UserListModel>();
            adminLists.Add(new UserListModel() { UserID=1,Name="Ram Kumar",EMail="ram@gmail.com",PhoneNo="+919994203132", IsActive = true });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Ram Kumar", EMail = "ram@gmail.com", PhoneNo = "+919994203134", IsActive = true });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Satheesh Kumar", EMail = "satheesh@gmail.com", PhoneNo = "+919994203135", IsActive = true });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Prakash Kumar", EMail = "prakash@gmail.com", PhoneNo = "+919994203136", IsActive = true });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Kannan Kumar", EMail = "kannan@gmail.com", PhoneNo = "+919994203137", IsActive = true });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Sundar Kumar", EMail = "sundar@gmail.com", PhoneNo = "+919994203139", IsActive = true });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Sundar Ganesh", EMail = "sundar@gmail.com", PhoneNo = "+919994203130", IsActive = false });
            return this.OK<List<UserListModel>>(adminLists);
        }

        [HttpGet]
        [Route("BlockedUserList")]
        [Authorize]
        public IActionResult GetBlockedUserList()
        {
            List<UserListModel> adminLists = new List<UserListModel>();
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Ram Kumar", EMail = "ram@gmail.com", PhoneNo = "+919994203132",IsActive = false });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Ram Kumar", EMail = "ram@gmail.com", PhoneNo = "+919994203134", IsActive = false });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Satheesh Kumar", EMail = "satheesh@gmail.com", PhoneNo = "+919994203135", IsActive = false });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Prakash Kumar", EMail = "prakash@gmail.com", PhoneNo = "+919994203136", IsActive = false });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Kannan Kumar", EMail = "kannan@gmail.com", PhoneNo = "+919994203137", IsActive = false });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Sundar Kumar", EMail = "sundar@gmail.com", PhoneNo = "+919994203139", IsActive = false });
            adminLists.Add(new UserListModel() { UserID = 1, Name = "Sundar Ganesh", EMail = "sundar@gmail.com", PhoneNo = "+919994203130", IsActive = false });
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
