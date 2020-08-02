using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.DataAccessLayer;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintManagementController : ControllerBase
    {
        private readonly TaxiAppzDBContext _content;
        public ComplaintManagementController(TaxiAppzDBContext content)
        {
            _content = content;
        }
        [HttpGet]
        [Route("Manageuser")]
        [Authorize]
        public IActionResult Manageuser()
        {
           DAComplaint dAComplaint = new DAComplaint();
            return this.OK<List<ManageUserComplaint>>(dAComplaint.ListUserComplaintTemplate(_content));
        }
        [HttpGet]
        [Route("UserComplainttemplateDtls")]
        [Authorize]
        public IActionResult UserComplainttemplateDtls(long promoid)
        {
            DAComplaint dAComplaint = new DAComplaint();
            return this.OK<ManageUserComplaint>(dAComplaint.UserComplainttemplateDtls(promoid, _content));
        }
        [HttpPost]
        [Route("AddUserComplainttemplate")]
        [Authorize]
        public IActionResult AddUserComplainttemplate(ManageUserComplaint managePromo)
        {
            DAComplaint dAComplaint = new DAComplaint();
            return this.OK(dAComplaint.AddUserComplainttemplate(managePromo, _content) ? "Recored Added Successfully" : "Failed to Add");
        }
        [HttpPut]
        [Route("EditUserComplainttemplate")]
        [Authorize]
        public IActionResult EditUserComplainttemplate(ManageUserComplaint managePromo)
        {
            DAComplaint dAComplaint = new DAComplaint();
            return this.OK(dAComplaint.EditUserComplainttemplate(managePromo, _content) ? "Recored Added Successfully" : "Failed to Add");
        }
        [HttpPut]
        [Route("IsActiveUserComplaintTemplate")]
        [Authorize]
        public IActionResult IsActiveUserComplaintTemplate(long promoid, bool activestatus)
        {
            DAComplaint dAComplaint = new DAComplaint();
            return this.OK(dAComplaint.IsActiveUserComplaintTemplate(promoid, activestatus, _content) ? "Recored Added Successfully" : "Failed to Add");
        }
        [HttpDelete]
        [Route("IsDeleteUserComplaintTemplate")]
        [Authorize]
        public IActionResult IsDeleteUserComplaintTemplate(long promoid)
        {
            DAComplaint dAComplaint = new DAComplaint();
            return this.OK(dAComplaint.IsDeleteUserComplaintTemplate(promoid, _content) ? "Recored Added Successfully" : "Failed to Add");
        }
        [HttpGet]
        [Route("ManageDriver")]
        [Authorize]
        public IActionResult ManageDriver()
        {
            List<ManagerDriver> manageDrivers = new List<ManagerDriver>();
            manageDrivers.Add(new ManagerDriver() { Sno = 1, ComplaintType = "Complaint", ComplaintTitle = "not pick up the call", Description = "Testing", RequestID = "RES_81117", DriverName = "Vasudev", IsActive = "New" });

            return this.OK<List<ManagerDriver>>(manageDrivers);
        }
    }
}
