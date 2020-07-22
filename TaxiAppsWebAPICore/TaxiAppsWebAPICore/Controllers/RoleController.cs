using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public RoleController(TaxiAppzDBContext context)
        {
            _context = context;
        }
 
        /// <summary>
        /// Use to List Roles
        /// </summary>
        /// <returns></returns>

        [Authorize]
        [HttpGet("RoleList")]
        public IActionResult RoleList()
        {
            DARoles dARoles = new DARoles();
           return this.OK<List<Roles>>(dARoles.GetRoleList(_context));
        }
        /// <summary>
        /// Use to Get Role Details based on ID
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetRole")]
        public IActionResult RoleDetails(long Roleid)
        {
            DARoles dARoles = new DARoles();
           return this.OK<Roles>(dARoles.GetRoleDtls(_context,Roleid));
        }
        /// <summary>
        /// Use to Add Roles
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddRole")]
        public IActionResult AddRole([FromBody] Roles roles)
        {
            DARoles dARoles = new DARoles();
            return this.OKResponse(dARoles.AddRole(_context, roles) ? "Inserted Successfully" : "Insertion Failed");
        }
        /// <summary>
        /// Use to Edit Role
        /// </summary>
        /// <returns></returns>
        [HttpPut("EditRole")]
        public IActionResult EditRole(long id,[FromBody] Roles roles)
        {
            DARoles dARoles = new DARoles();
            return this.OKResponse(dARoles.EditRole(_context,id, roles) ? "Updated Successfully" : "Updation Failed");
        }
        [HttpPut("DeleteRole")]
        public IActionResult DeleteRole(long id)
        {
            DARoles dARoles = new DARoles();
            return this.OKResponse(dARoles.DeleteRole(_context, id) ? "Updated Successfully" : "Updation Failed");
        }
        [HttpPut("DisableRole")]
        public IActionResult DisableRole(long id)
        {
            DARoles dARoles = new DARoles();
            return this.OKResponse(dARoles.DisableRole(_context, id) ? "Updated Successfully" : "Updation Failed");
        }
    }
}
