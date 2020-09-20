using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.DataAccessLayer;
using TaxiAppsWebAPICore.Helper;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancelManagementController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public CancelManagementController(TaxiAppzDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("ManageUser")]
        [Authorize]
        public IActionResult ManageUser()
        {
            DACancel dACancel = new DACancel();
            return this.OK<List<CancelUser>>(dACancel.UserList(_context));            
        }

        [HttpGet]
        [Route("GetUserCancelEdit")]
        [Authorize]
        public IActionResult GetUserCancelEdit(long userCancelId)
        {
            DACancel dACancel = new DACancel();
            return this.OK<CancelUserInfo>(dACancel.GetbyUserCancelId(userCancelId, _context));
        }

        [HttpPost]
        [Route("SaveCancelUser")]
        [Authorize]
        public IActionResult SaveCancelUser(CancelUserInfo cancelUserInfo)
        {
            try
            {
                Validator.validataeCancelUser(cancelUserInfo);
                DACancel dACancel = new DACancel();
                return this.OKResponse(dACancel.SaveCancelUser(_context, cancelUserInfo, User.ToAppUser()) == true ? "Inserted Successfully" : "Insertion Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);              
            }            
        }
        [HttpDelete]
        [Route("DeleteUser")]
        [Authorize]
        public IActionResult DeleteUser(long usercancelid)
        {
            try
            {
                DACancel dACancel = new DACancel();
                return this.OKResponse(dACancel.DeleteUser(_context, usercancelid, User.ToAppUser()) == true ? "Deleted Successfully" : "Deletion Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }            
        }

        [HttpPut]
        [Route("StatusUser")]
        [Authorize]
        public IActionResult StatusUser(long usercancelid, bool status)
        {
            try
            {
                DACancel dACancel = new DACancel();
                return this.OKResponse(dACancel.StatusUser(_context, usercancelid, status, User.ToAppUser()) == true ? (status == true ? "Active Successfully" : "InActive Successfully") : "Failed to Update");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }            
        }

        [HttpPut]
        [Route("EditUser")]
        [Authorize]
        public IActionResult EditUser(CancelUserInfo cancelUserInfo)
        {
            try
            {
                Validator.validataeCancelUser(cancelUserInfo);
                DACancel dACancel = new DACancel();
                return this.OKResponse(dACancel.EditUser(_context, cancelUserInfo, User.ToAppUser()) == true ? "Updated Successfully" : "Updation Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }


        [HttpGet]
        [Route("ManageDrivers")]
        [Authorize]
        public IActionResult ManageDrivers()
        {
            DACancel dACancel = new DACancel();
            return this.OK<List<CancelDriver>>(dACancel.DriverList(_context));            
        }

        [HttpGet]
        [Route("GetDriverCancelEdit")]
        [Authorize]
        public IActionResult GetDriverCancelEdit(long driverCancelId)
        {
            DACancel dACancel = new DACancel();
            return this.OK<CancelDriverInfo>(dACancel.GetbyDriverCancelId(driverCancelId, _context));
        }

        [HttpPost]
        [Route("SaveCancelDriver")]
        [Authorize]
        public IActionResult SaveCancelDriver(CancelDriverInfo cancelDriverInfo)
        {
            try
            {
                Validator.validateAddCancelDriver(cancelDriverInfo);
                DACancel dACancel = new DACancel();
                return this.OKResponse(dACancel.SaveCancelDriver(_context, cancelDriverInfo, User.ToAppUser()) == true ? "Inserted Successfully" : "Insertion Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }           
        }

        [HttpDelete]
        [Route("DeleteDriver")]
        [Authorize]
        public IActionResult DeleteDriver(long driverCancelId)
        {
            try
            {
                DACancel dACancel = new DACancel();
                return this.OKResponse(dACancel.DeleteDriver(_context, driverCancelId, User.ToAppUser()) == true ? "Deleted Successfully" : "Deletion Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }  
        }

        [HttpPut]
        [Route("StatusDriver")]
        [Authorize]
        public IActionResult StatusDriver(long driverCancelId, bool status)
        {
            try
            {
                DACancel dACancel = new DACancel();
                return this.OKResponse(dACancel.StatusDriver(_context, driverCancelId, status, User.ToAppUser()) == true ? (status == true ? "Active Successfully" : "InActive Successfully") : "Failed to Update");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }           
        }
         
        [HttpPut]
        [Route("EditDriver")]
        [Authorize]
        public IActionResult EditDriver(CancelDriverInfo cancelDriverInfo)
        {
            try
            {
                Validator.validateEditCancelDriver(cancelDriverInfo);
                DACancel dACancel = new DACancel();
                return this.OKResponse(dACancel.EditDriver(_context, cancelDriverInfo, User.ToAppUser()) == true ? "Updated Successfully" : "Updation Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }  
        }
    }
}
