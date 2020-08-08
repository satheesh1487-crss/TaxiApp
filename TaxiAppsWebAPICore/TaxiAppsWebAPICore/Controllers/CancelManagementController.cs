using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.DataAccessLayer;
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

        //TODO:: check parent record is deleted
        [HttpPost]
        [Route("SaveCancelUser")]
        [Authorize]
        public IActionResult SaveCancelUser(CancelUserInfo cancelUserInfo)
        {
            DACancel dACancel = new DACancel();
            return this.OKResponse(dACancel.SaveCancelUser(_context, cancelUserInfo, User.ToAppUser()) == true ? "Inserted Successfully" : "Insertion Failed");
        }

        //TODO:: check parent record is deleted
        [HttpDelete]
        [Route("DeleteUser")]
        [Authorize]
        public IActionResult DeleteUser(long usercancelid)
        {
            DACancel dACancel = new DACancel();
            return this.OKResponse(dACancel.DeleteUser(_context, usercancelid, User.ToAppUser()) == true ? "Deleted Successfully" : "Deletion Failed");
        }

        //TODO:: check parent record is deleted
        [HttpPut]
        [Route("StatusUser")]
        [Authorize]
        public IActionResult StatusUser(long usercancelid, bool status)
        {
            DACancel dACancel = new DACancel();
            return this.OKResponse(dACancel.StatusUser(_context, usercancelid, status, User.ToAppUser()) == true ? "Active Successfully" : "InActive Successfully");
        }

        //TODO:: check parent record is deleted
        [HttpPut]
        [Route("EditUser")]
        [Authorize]
        public IActionResult EditUser(CancelUserInfo cancelUserInfo)
        {
            DACancel dACancel = new DACancel();
            return this.OKResponse(dACancel.EditUser(_context, cancelUserInfo, User.ToAppUser()) == true ? "Updated Successfully" : "Updation Failed");
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

        //TODO:: check parent record is deleted
        [HttpPost]
        [Route("SaveCancelDriver")]
        [Authorize]
        public IActionResult SaveCancelDriver(CancelDriverInfo cancelDriverInfo)
        {
            DACancel dACancel = new DACancel();
            return this.OKResponse(dACancel.SaveCancelDriver(_context, cancelDriverInfo, User.ToAppUser()) == true ? "Inserted Successfully" : "Insertion Failed");
        }

        //TODO:: check parent record is deleted
        [HttpDelete]
        [Route("DeleteDriver")]
        [Authorize]
        public IActionResult DeleteDriver(long driverCancelId)
        {
            DACancel dACancel = new DACancel();
            return this.OKResponse(dACancel.DeleteDriver(_context, driverCancelId, User.ToAppUser()) == true ? "Deleted Successfully" : "Deletion Failed");
        }

        //TODO:: check parent record is deleted
        [HttpPut]
        [Route("StatusDriver")]
        [Authorize]
        public IActionResult StatusDriver(long driverCancelId, bool status)
        {
            DACancel dACancel = new DACancel();
            return this.OKResponse(dACancel.StatusDriver(_context, driverCancelId, status, User.ToAppUser()) == true ? "Active Successfully" : "InActive Successfully");
        }

        //TODO:: check parent record is deleted
        [HttpPut]
        [Route("EditDriver")]
        [Authorize]
        public IActionResult EditDriver(CancelDriverInfo cancelDriverInfo)
        {
            DACancel dACancel = new DACancel();
            return this.OKResponse(dACancel.EditDriver(_context, cancelDriverInfo, User.ToAppUser()) == true ? "Updated Successfully" : "Updation Failed");
        }
    }
}
