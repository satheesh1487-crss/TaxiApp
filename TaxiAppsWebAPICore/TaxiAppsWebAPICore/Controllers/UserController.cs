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
            return this.OK<List<UserList>>(dAUsers.List(_context));
        }

        [HttpGet]
        [Route("BlockedUserList")]
        [Authorize]
        public IActionResult GetBlockedUserList()
        {
            DAUsers dAUsers = new DAUsers();
            return this.OK<List<UserListModel>>(dAUsers.BlockedList(_context));
        }
        [HttpGet]
        [Route("GetUserEdit")]
        [Authorize]
        public IActionResult GetUserEdit(long userid)
        {
            DAUsers dAUsers = new DAUsers();
            return this.OK<UserListModel>(dAUsers.GetbyId(userid, _context));
        }
        [HttpDelete]
        [Route("DeleteUser")]
        [Authorize]
        public IActionResult DeleteUser(long userid)
        {
            DAUsers dAUsers = new DAUsers();
            return this.OKResponse(dAUsers.Delete(_context,userid) == true ? "Deleted Successfully" : "Deletion Failed");
        }
        [HttpPut]
        [Route("InActiveuser")]
        [Authorize]
        public IActionResult InActiveuser(long userid,bool status)
        {
            DAUsers dAUsers = new DAUsers();
            return this.OKResponse(dAUsers.DisableUser(_context, userid,status) == true ? "Disabled Successfully" : "Disabled Failed");
        }
        [HttpPut]
        [Route("Edit")]
        [Authorize]
        public IActionResult Edit(UserInfoList userInfoList)
        {
            DAUsers dAUsers = new DAUsers();
            return this.OKResponse(dAUsers.Edit(_context, userInfoList) == true ? "Disabled Successfully" : "Disabled Failed");
        }
        [HttpPost]
        [Route("Save")]
        [Authorize]
        public IActionResult Save(UserInfoList userInfoList)
        {
            DAUsers dAUsers = new DAUsers();
            return this.OKResponse(dAUsers.Save(_context, userInfoList) == true ? "Disabled Successfully" : "Disabled Failed");
        }
    }
}
