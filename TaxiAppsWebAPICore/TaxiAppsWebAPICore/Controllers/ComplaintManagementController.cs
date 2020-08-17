using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.DataAccessLayer;
using TaxiAppsWebAPICore.Helper;
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
            try
            {
                DAComplaint dAComplaint = new DAComplaint();
                return this.OK(dAComplaint.AddUserComplainttemplate(managePromo, _content, User.ToAppUser()) ? "Recored Added Successfully" : "Failed to Add");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }

        }
        [HttpPut]
        [Route("EditUserComplainttemplate")]
        [Authorize]
        public IActionResult EditUserComplainttemplate(ManageUserComplaint managePromo)
        {
            try
            {
                DAComplaint dAComplaint = new DAComplaint();
                return this.OK(dAComplaint.EditUserComplainttemplate(managePromo, _content, User.ToAppUser()) ? "Recored Edited Successfully" : "Failed to Edit");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }

        }
        [HttpPut]
        [Route("IsActiveUserComplaintTemplate")]
        [Authorize]
        public IActionResult IsActiveUserComplaintTemplate(long promoid, bool activestatus)
        {
            try
            {
                DAComplaint dAComplaint = new DAComplaint();
                return this.OK(dAComplaint.IsActiveUserComplaintTemplate(promoid, activestatus, _content, User.ToAppUser()) ? "Active Successfully" : "InActive Successfully");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }
        [HttpDelete]
        [Route("IsDeleteUserComplaintTemplate")]
        [Authorize]
        public IActionResult IsDeleteUserComplaintTemplate(long promoid)
        {
            try
            {
                DAComplaint dAComplaint = new DAComplaint();
                return this.OK(dAComplaint.IsDeleteUserComplaintTemplate(promoid, _content, User.ToAppUser()) ? "Recored Deleted Successfully" : "Failed to Delete");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
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
        [HttpGet]
        [Route("DriverComplainttemplateDtls")]
        [Authorize]
        public IActionResult DriverComplainttemplateDtls(long promoid)
        {
            DAComplaint dAComplaint = new DAComplaint();
            return this.OK<ManageDriverComplaint>(dAComplaint.DriverComplainttemplateDtls(promoid, _content));
        }
        [HttpPost]
        [Route("AddDriverComplainttemplate")]
        [Authorize]
        public IActionResult AddDriverComplainttemplate(ManageDriverComplaint managePromo)
        {
            try
            {
                DAComplaint dAComplaint = new DAComplaint();
                return this.OK(dAComplaint.AddDriverComplainttemplate(managePromo, _content, User.ToAppUser()) ? "Recored Added Successfully" : "Failed to Add");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }

        }
        [HttpPut]
        [Route("EditDriverComplainttemplate")]
        [Authorize]
        public IActionResult EditDriverComplainttemplate(ManageDriverComplaint managePromo)
        {
            try
            {
                DAComplaint dAComplaint = new DAComplaint();
                return this.OK(dAComplaint.EditDriverComplainttemplate(managePromo, _content, User.ToAppUser()) ? "Recored Edited Successfully" : "Failed to Edit");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }

        }
        [HttpPut]
        [Route("IsActiveDriverComplaintTemplate")]
        [Authorize]
        public IActionResult IsActiveDriverComplaintTemplate(long promoid, bool activestatus)
        {
            try
            {
                DAComplaint dAComplaint = new DAComplaint();
                return this.OK(dAComplaint.IsActiveDriverComplaintTemplate(promoid, activestatus, _content, User.ToAppUser()) ? "Active Successfully" : "InActive Successfully");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }
        [HttpDelete]
        [Route("IsDeleteDriverComplaintTemplate")]
        [Authorize]
        public IActionResult IsDeleteDriverComplaintTemplate(long promoid)
        {
            try
            {
                DAComplaint dAComplaint = new DAComplaint();
                return this.OK(dAComplaint.IsDeleteDriverComplaintTemplate(promoid, _content, User.ToAppUser()) ? "Recored Deleted Successfully" : "Failed to Delete");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }
    }
}
