using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.Helper;
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

        //TODO:Foreignkey not yet set Roles
        [HttpGet]
        [Route("list")]
        [Authorize(Policy = "superAdmin")]
        public IActionResult List()
        {
            DASuperAdmin dASuperAdmin = new DASuperAdmin();
            return this.OK<List<AdminList>>(dASuperAdmin.List(_context));
        }
        

        [HttpGet]
        [Route("getbyId")]
        [Authorize(Policy = "superAdmin")]
        public IActionResult GetbyId(long Adminid)
        {
            DASuperAdmin dASuperAdmin = new DASuperAdmin();
            return this.OK<AdminDetails>(dASuperAdmin.GetbyId(Adminid, _context));
        }

        //TODO:: check parent record is deleted
        [HttpPost]
        [Route("save")]
        [Authorize]
        public IActionResult Save(AdminDetails adminDetails)
        {
            try
            {
                DASuperAdmin dASuperAdmin = new DASuperAdmin();
                return this.OKResponse(dASuperAdmin.Save(_context, adminDetails, User.ToAppUser()) ? "Updated Successfully" : "Updation Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }            
        }

        //TODO:: check parent record is deleted
        [HttpPut]
        [Route("edit")]
        [Authorize]
        public IActionResult Edit(AdminDetails adminDetails)
        {
            try
            {
                DASuperAdmin dASuperAdmin = new DASuperAdmin();
                return this.OKResponse(dASuperAdmin.Edit(_context, adminDetails, User.ToAppUser()) ? "Updated Successfully" : "Updation Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }            
        }

        //TODO:: check parent record is deleted
        [HttpPut]
        [Route("status")]
        [Authorize]
        public IActionResult Status(long id,bool status)
        {
            DASuperAdmin dASuperAdmin = new DASuperAdmin();
            return this.OKResponse(dASuperAdmin.Status(_context, id, status, User.ToAppUser()) == true ? (status == true ? "Active Successfully" : "InActive Successfully") : "Failed to Update");
        }

        //TODO:: check parent record is deleted
        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public IActionResult Delete(long id)
        {
            DASuperAdmin dASuperAdmin = new DASuperAdmin();
            return this.OKResponse(dASuperAdmin.Delete(_context, id, User.ToAppUser()) ? "Deleted Successfully" : "Deletion Failed");
        }

        //TODO:: check parent record is deleted
        [HttpPut]
        [Route("editPassword")]
        [Authorize]
        public IActionResult EditPassword(AdminPassword adminPassword)
        {
            DASuperAdmin dASuperAdmin = new DASuperAdmin();
            return this.OKResponse(dASuperAdmin.EditPassword(_context, adminPassword, User.ToAppUser()) ? "Updated Successfully" : "Updation Failed");
        }

    }
}
