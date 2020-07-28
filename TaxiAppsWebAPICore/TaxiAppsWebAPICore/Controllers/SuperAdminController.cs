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
        
        [HttpPost]
        [Route("save")]
        [Authorize]
        public IActionResult Save(AdminDetails adminDetails)
        {
            DASuperAdmin dASuperAdmin = new DASuperAdmin();
            return this.OKResponse(dASuperAdmin.Save(_context, adminDetails, User.ToAppUser()) ? "Inserted Successfully" : "Insertion Failed");
        }

        [HttpPut]
        [Route("edit")]
        [Authorize]
        public IActionResult Edit(AdminDetails adminDetails)
        {
            DASuperAdmin dASuperAdmin = new DASuperAdmin();
            return this.OKResponse(dASuperAdmin.Edit(_context, adminDetails, User.ToAppUser()) ? "Updated Successfully" : "Updation Failed");
        }

        [HttpPut]
        [Route("status")]
        [Authorize]
        public IActionResult Status(long id,bool status)
        {
            DASuperAdmin dASuperAdmin = new DASuperAdmin();
            return this.OKResponse(dASuperAdmin.Status(_context, id, status, User.ToAppUser()) ? "Status Changed Successfully" : "Status Changed Failed");
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public IActionResult Delete(long id)
        {
            DASuperAdmin dASuperAdmin = new DASuperAdmin();
            return this.OKResponse(dASuperAdmin.Delete(_context, id, User.ToAppUser()) ? "Deleted Successfully" : "Deletion Failed");
        }

        [HttpPut]
        [Route("editpassword")]
        [Authorize]
        public IActionResult Editpassword(AdminDetails adminDetails)
        {
            DASuperAdmin dASuperAdmin = new DASuperAdmin();
            return this.OKResponse(dASuperAdmin.Editpassword(_context, adminDetails, User.ToAppUser()) ? "Updated Successfully" : "Updation Failed");
        }
       
    }
}
