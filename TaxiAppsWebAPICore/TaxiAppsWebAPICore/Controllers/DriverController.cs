using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using TaxiAppsWebAPICore.DataAccessLayer;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {

        private readonly TaxiAppzDBContext _context;
        public DriverController(TaxiAppzDBContext context)
        {
            _context = context;
        }



        [HttpGet]
        [Route("driverList")]
        [Authorize]
        public IActionResult GetDriverList()
        {
            DADriver dADriver = new DADriver();
            return this.OK<List<DriverList>>(dADriver.List(_context));
        }

        [HttpGet]
        [Route("BlockedDriverList")]
        [Authorize]
        public IActionResult GetBlockedDriverList()
        {
            DADriver dADriver = new DADriver();
            return this.OK<List<DriverList>>(dADriver.BlockedList(_context));
        }

        [HttpGet]
        [Route("GetDriverEdit")]
        [Authorize]
        public IActionResult GetDriverEdit(long driverid)
        {
            DADriver dADriver = new DADriver();
            return this.OK<DriverList>(dADriver.GetbyId(driverid, _context));
        }

        //TODO:: check parent record is deleted
        [HttpDelete]
        [Route("DeleteDriver")]
        [Authorize]
        public IActionResult DeleteDriver(long driverid)
        {
            DADriver dADriver = new DADriver();
            return this.OKResponse(dADriver.Delete(_context, driverid, User.ToAppUser()) == true ? "Deleted Successfully" : "Deletion Failed");
        }

        //TODO:: check parent record is deleted
        [HttpPut]
        [Route("InActivedriver")]
        [Authorize]
        public IActionResult InActivedriver(long driverid, bool status)
        {
            DADriver dADriver = new DADriver();
            return this.OKResponse(dADriver.DisableUser(_context, driverid, status, User.ToAppUser()) == true ? "Active Successfully" : "InActive Successfully");
        }

        //TODO:: check parent record is deleted
        [HttpPut]
        [Route("Edit")]
        [Authorize]
        public IActionResult Edit(EditDriver editDriver)
        {
            DADriver dADriver = new DADriver();
            return this.OKResponse(dADriver.Edit(_context, editDriver, User.ToAppUser()) == true ? "Updated Successfully" : "Updation Failed");
        }

        //TODO:: check parent record is deleted
        [HttpPost]
        [Route("Save")]
        [Authorize]
        public IActionResult Save(DriverInfo driverInfo)
        {
            DADriver dADriver = new DADriver();
            return this.OKResponse(dADriver.Save(_context, driverInfo, User.ToAppUser()) == true ? "Inserted Successfully" : "Insertion Failed");
        }

        [HttpGet]
        [Route("downloadDriver")]
        [Authorize]
        public IActionResult DownloadDriver()
        {
            DADriver dADriver = new DADriver();
            var drivers = dADriver.List(_context);
            var driverlist = dADriver.List(_context);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < driverlist.Count; i++)
            {
                DriverList customer = driverlist[i];
                sb.Append(driverlist[i].Email + ',');
                sb.Append(driverlist[i].AcceptanceRatio + ',');
                sb.Append(driverlist[i].Document + ',');
                sb.Append(driverlist[i].DriverId + ',');
                sb.Append(driverlist[i].DriverName + ',');
                sb.Append(driverlist[i].PhoneNumber + ',');
                sb.Append(driverlist[i].Rating + ',');
                sb.Append(driverlist[i].RegistrationCode + ',');
                sb.Append("\r\n");

            }
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Grid.csv");
        }

        [HttpPost]
        [Route("downloadBlocked")]
        [Authorize]
        public IActionResult DownloadBlocked()
        {
            DADriver dADriver = new DADriver();
            var drivers = dADriver.BlockedList(_context);
            var driverlist = dADriver.List(_context);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < driverlist.Count; i++)
            {
                DriverList customer = driverlist[i];
                sb.Append(driverlist[i].Email + ',');
                sb.Append(driverlist[i].AcceptanceRatio + ',');
                sb.Append(driverlist[i].Document + ',');
                sb.Append(driverlist[i].DriverId + ',');
                sb.Append(driverlist[i].DriverName + ',');
                sb.Append(driverlist[i].PhoneNumber + ',');
                sb.Append(driverlist[i].Rating + ',');
                sb.Append(driverlist[i].RegistrationCode + ',');
                sb.Append("\r\n");

            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Grid.csv");
        }

        [HttpPost]
        [Route("AddWallet")]
        [Authorize]
        public IActionResult AddWallet(DriverAddWallet driverAddWallet)
        {
            DADriver dADriver = new DADriver();
            return this.OKResponse(dADriver.AddWallet(_context, driverAddWallet, User.ToAppUser()) == true ? "Inserted Successfully" : "Insertion Failed");
        }

        [HttpGet]
        [Route("driverWalletList")]
        [Authorize]
        public IActionResult GetDriverWalletList(long driverId)
        {
            DADriver dADriver = new DADriver();
            return this.OK<DriverListWallet>(dADriver.ListWallet(_context, driverId));
        }

        [HttpGet]
        [Route("driverFineList")]
        [Authorize]
        public IActionResult GetDriverFineList()
        {
            DADriver dADriver = new DADriver();
            return this.OK<List<DriverFineInfo>>(dADriver.ListFine(_context));
        }

        //TODO:: check parent record is deleted
        [HttpPost]
        [Route("addFine")]
        [Authorize]
        public IActionResult AddFine(DriverFineInfo driverFineInfo)
        {
            DADriver dADriver = new DADriver();
            return this.OKResponse(dADriver.AddFine(_context, driverFineInfo, User.ToAppUser()) == true ? "Inserted Successfully" : "Insertion Failed");
        }

        [HttpGet]
        [Route("GetDriverFineEdit")]
        [Authorize]
        public IActionResult GetDriverFineEdit(long driverid)
        {
            DADriver dADriver = new DADriver();
            return this.OK<DriverFineInfo>(dADriver.GetbyFineId(driverid, _context));
        }

        //TODO:: check parent record is deleted
        [HttpPut]
        [Route("EditFine")]
        [Authorize]
        public IActionResult EditFine(DriverFineInfo driverFineInfo)
        {
            DADriver dADriver = new DADriver();
            return this.OKResponse(dADriver.EditFine(_context, driverFineInfo, User.ToAppUser()) == true ? "Updated Successfully" : "Updation Failed");
        }

        //TODO:: check parent record is deleted
        [HttpDelete]
        [Route("DeleteFine")]
        [Authorize]
        public IActionResult DeleteFine(long Id)
        {
            DADriver dADriver = new DADriver();
            return this.OKResponse(dADriver.DeleteFine(_context, Id, User.ToAppUser()) == true ? "Deleted Successfully" : "Deletion Failed");
        }

        [HttpGet]
        [Route("driverBonusList")]
        [Authorize]
        public IActionResult DriverBonusList()
        {
            DADriver dADriver = new DADriver();
            return this.OK<List<DriverBonusList>>(dADriver.ListBonus(_context));
        }
        [HttpPost]
        [Route("addBonus")]
        [Authorize]
        public IActionResult AddBonus(DriverBonusInfo driverBonusInfo)
        {
            DADriver dADriver = new DADriver();
            return this.OKResponse(dADriver.AddBonus(_context, driverBonusInfo, User.ToAppUser()) == true ? "Inserted Successfully" : "Insertion Failed");
        }
        [HttpPut]
        [Route("editBonus")]
        [Authorize]
        public IActionResult EditBonus(DriverBonusInfo driverBonusInfo)
        {
            DADriver dADriver = new DADriver();
            return this.OKResponse(dADriver.EditBonus(_context, driverBonusInfo, User.ToAppUser()) == true ? "Inserted Successfully" : "Insertion Failed");
        }
        [HttpDelete]
        [Route("deleteBonus")]
        [Authorize]
        public IActionResult DeleteBonus(long  id)
        {
            DADriver dADriver = new DADriver();
            return this.OKResponse(dADriver.DeleteBonus(_context, id, User.ToAppUser()) == true ? "Deleted Successfully" : "Deletion Failed");
        }

        [HttpGet]
        [Route("getByBonusId")]
        [Authorize]
        public IActionResult GetByBonusId(long id)
        {
            DADriver dADriver = new DADriver();
            return this.OK<DriverBonusInfo>(dADriver.GetByBonusId(id,_context));
        }
    }
}
