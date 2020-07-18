using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class SuperAdminController : ControllerBase
    { 
        
        private readonly TaxiAppzDBContext _context;
        public SuperAdminController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Use to display List of Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetsuperAdminData")]
        [Authorize(Policy = "superAdmin")]
        public IActionResult GetsuperAdminData()
        {
            DARoles dARoles = new DARoles();
            return this.OK<List<AdminList>>(dARoles.GetAdminList(_context));
        }
        /// <summary>
        /// Use to get Admin Details to Edit
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSuperAdminDetails")]
        [Authorize(Policy = "superAdmin")]
        public IActionResult GetSuperAdminDetails(long Adminid)
        {
            DARoles dARoles = new DARoles();
            return this.OK<AdminList>(dARoles.GetAdminDetails(Adminid, _context));
        }
    }
}
