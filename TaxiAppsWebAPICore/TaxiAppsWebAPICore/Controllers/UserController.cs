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
        

     [HttpGet]
        [Route("UserList")]
        [Authorize]
        public IActionResult GetUserList()
        {
            DAUsers dAUsers = new DAUsers();
            return this.OK<List<UserListModel>>(dAUsers.GetUserList(_context));
        }

        [HttpGet]
        [Route("BlockedUserList")]
        [Authorize]
        public IActionResult GetBlockedUserList()
        {
            DAUsers dAUsers = new DAUsers();
            return this.OK<List<UserListModel>>(dAUsers.GetBlockedUserList(_context));
        }
        [HttpGet]
        [Route("GetUserEdit")]
        [Authorize]
        public IActionResult GetUserEdit(long userid)
        {
            DAUsers dAUsers = new DAUsers();
            return this.OK<UserListModel>(dAUsers.GetUserEdit(userid, _context));
        }
        [HttpGet]
        [Route("DeleteUser")]
        [Authorize]
        public IActionResult DeleteUser(long userid)
        {
            DAUsers dAUsers = new DAUsers();
            return this.OKResponse(dAUsers.DeleteUser(_context,userid) == true ? "Deleted Successfully" : "Deletion Failed");
        }
        [HttpGet]
        [Route("InActiveuser")]
        [Authorize]
        public IActionResult InActiveuser(long userid)
        {
            DAUsers dAUsers = new DAUsers();
            return this.OKResponse(dAUsers.DisableUser(_context, userid) == true ? "Disabled Successfully" : "Disabled Failed");
        }
    }
}
