using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using TaxiAppsWebAPICore.Helper;
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
            return this.OK<Roles>(dARoles.GetRoleDtls(_context, Roleid));
        }
        /// <summary>
        /// Use to Add Roles
        /// //TODO:: check parent record is deleted
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddRole")]
        public IActionResult AddRole([FromBody] Roles roles)
        {
            try
            {
                DARoles dARoles = new DARoles();
                return this.OKResponse(dARoles.AddRole(_context, roles, User.ToAppUser()) ? "Inserted Successfully" : "Insertion Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }

        }
        /// <summary>
        /// Use to Edit Role
        /// //TODO:: check parent record is deleted
        /// </summary>
        /// <returns></returns>
        [HttpPut("EditRole")]
        public IActionResult EditRole(long id, [FromBody] Roles roles)
        {
            try
            {
                DARoles dARoles = new DARoles();
                return this.OKResponse(dARoles.EditRole(_context, id, roles, User.ToAppUser()) ? "Updated Successfully" : "Updation Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }


        //TODO:: check parent record is deleted
        [HttpPut("DisableRole")]
        public IActionResult DisableRole(long id)
        {
            try
            {
                DARoles dARoles = new DARoles();
                return this.OKResponse(dARoles.DisableRole(_context, id, User.ToAppUser()) ? "Active Successfully" : "InActive Successfully");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }

        //TODO:: check parent record is deleted
        [HttpPost]
        [Route("AddMenuAccess")]
        public IActionResult AddMenuAccess(long fromroleid, long toroleid)
        {
            try
            {
                DARoles dARoles = new DARoles();
                return this.OKResponse(dARoles.AddMenuAccess(fromroleid, toroleid, _context) ? "Updated Successfully" : "Updation Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }
    }
}
