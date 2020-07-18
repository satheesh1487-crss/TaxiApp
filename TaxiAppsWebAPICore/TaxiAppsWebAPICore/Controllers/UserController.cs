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


        //[HttpGet("GetAdminData")]
       
        //[Authorize(Policy = Policies.Admin)]
        //public IActionResult GetAdminData()
        //{
        //    return Ok("This is a response from Admin method");
        //}
    }
}
