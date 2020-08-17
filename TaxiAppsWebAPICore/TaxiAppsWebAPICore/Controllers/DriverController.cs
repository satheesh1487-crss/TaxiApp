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
using TaxiAppsWebAPICore.Helper;
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
            return this.OK<DriverInfo>(dADriver.GetbyId(driverid, _context));
        }

        [HttpGet]
        [Route("GetRewardEdit")]
        [Authorize]
        public IActionResult GetRewardEdit(long driverid)
        {
            DADriver dADriver = new DADriver();
            return this.OK<EditReward>(dADriver.GetbyRewardPoint(driverid, _context));
        }

        [HttpPut]
        [Route("EditRewardPoint")]
        [Authorize]
        public IActionResult EditRewardPoint(EditReward editReward)
        {
            try
            {
                DADriver dADriver = new DADriver();
                return this.OKResponse(dADriver.EditRewardPoint(_context, editReward, User.ToAppUser()) == true ? "Updated Successfully" : "Updation Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteDriver")]
        [Authorize]
        public IActionResult DeleteDriver(long driverid)
        {
            DADriver dADriver = new DADriver();
            return this.OKResponse(dADriver.Delete(_context, driverid, User.ToAppUser()) == true ? "Deleted Successfully" : "Deletion Failed");
        }

        [HttpPut]
        [Route("InActivedriver")]
        [Authorize]
        public IActionResult InActivedriver(long driverid, bool status)
        {
            DADriver dADriver = new DADriver();
            return this.OKResponse(dADriver.DisableUser(_context, driverid, status, User.ToAppUser()) == true ? "Active Successfully" : "InActive Successfully");
        }

        [HttpPut]
        [Route("Edit")]
        [Authorize]
        public IActionResult Edit(EditDriver editDriver)
        {
            try
            {
                DADriver dADriver = new DADriver();
                return this.OKResponse(dADriver.Edit(_context, editDriver, User.ToAppUser()) == true ? "Updated Successfully" : "Updation Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }

        //TODO:: check parent record is deleted
        [HttpPost]
        [Route("Save")]
        [Authorize]
        public IActionResult Save(DriverInfo driverInfo)
        {
            try
            {
                DADriver dADriver = new DADriver();
                return this.OKResponse(dADriver.Save(_context, driverInfo, User.ToAppUser()) == true ? "Inserted Successfully" : "Insertion Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }

        //<summary>
        //Add wallet transcation Id not exists
        //</summary>

        [HttpPost]
        [Route("AddWallet")]
        [Authorize]
        public IActionResult AddWallet(DriverAddWallet driverAddWallet)
        {
            try
            {
                DADriver dADriver = new DADriver();
                return this.OKResponse(dADriver.AddWallet(_context, driverAddWallet, User.ToAppUser()) == true ? "Inserted Successfully" : "Insertion Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
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

        [HttpPut]
        [Route("EditFine")]
        [Authorize]
        public IActionResult EditFine(DriverFineInfo driverFineInfo)
        {
            try
            {
                DADriver dADriver = new DADriver();
                return this.OKResponse(dADriver.EditFine(_context, driverFineInfo, User.ToAppUser()) == true ? "Updated Successfully" : "Updation Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }

        }

        [HttpDelete]
        [Route("DeleteFine")]
        [Authorize]
        public IActionResult DeleteFine(long Id)
        {
            try
            {
                DADriver dADriver = new DADriver();
                return this.OKResponse(dADriver.DeleteFine(_context, Id, User.ToAppUser()) == true ? "Deleted Successfully" : "Deletion Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }

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
            try
            {
                DADriver dADriver = new DADriver();
                return this.OKResponse(dADriver.AddBonus(_context, driverBonusInfo, User.ToAppUser()) == true ? "Inserted Successfully" : "Insertion Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }
        [HttpPut]
        [Route("editBonus")]
        [Authorize]
        public IActionResult EditBonus(DriverBonusInfo driverBonusInfo)
        {
            try
            {
                DADriver dADriver = new DADriver();
                return this.OKResponse(dADriver.EditBonus(_context, driverBonusInfo, User.ToAppUser()) == true ? "Updated Successfully" : "Updation Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }
        [HttpDelete]
        [Route("deleteBonus")]
        [Authorize]
        public IActionResult DeleteBonus(long id)
        {
            try
            {
                DADriver dADriver = new DADriver();
                return this.OKResponse(dADriver.DeleteBonus(_context, id, User.ToAppUser()) == true ? "Deleted Successfully" : "Deletion Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }

        [HttpGet]
        [Route("getByBonusId")]
        [Authorize]
        public IActionResult GetByBonusId(long id)
        {
            DADriver dADriver = new DADriver();
            return this.OK<DriverBonusInfo>(dADriver.GetByBonusId(id, _context));
        }

        [HttpGet]
        [Route("WalletPaymentList")]
        [Authorize]
        public IActionResult WalletPaymentList()
        {
            List<PaymentList> paymentLists = new List<PaymentList>();
            paymentLists.Add(new PaymentList() { DriverId = 1, RegistrationCode = "5555", DriverName = "rajesh", Email = "rajesh@gmail.com", PhoneNumber = "9876787676", Rating = "5*", IsActive = true });
            paymentLists.Add(new PaymentList() { DriverId = 2, RegistrationCode = "8888", DriverName = "kumar", Email = "kumar@gmail.com", PhoneNumber = "9653842154", Rating = "3*", IsActive = false });
            paymentLists.Add(new PaymentList() { DriverId = 3, RegistrationCode = "4444", DriverName = "saron", Email = "saron@gmail.com", PhoneNumber = "9635626584", Rating = "2*", IsActive = true });
            paymentLists.Add(new PaymentList() { DriverId = 4, RegistrationCode = "2222", DriverName = "poobesh", Email = "poobesh@gmail.com", PhoneNumber = "9658436254", Rating = "4*", IsActive = false });

            return this.OK<List<PaymentList>>(paymentLists);
        }

        [HttpGet]
        [Route("AccountPaymentList")]
        [Authorize]
        public IActionResult AccountPaymentList()
        {
            List<PaymentList> paymentLists = new List<PaymentList>();
            paymentLists.Add(new PaymentList() { DriverId = 1, RegistrationCode = "5555", DriverName = "rajesh", Email = "rajesh@gmail.com", PhoneNumber = "9876787676", Rating = "5*", IsActive = true });
            paymentLists.Add(new PaymentList() { DriverId = 2, RegistrationCode = "8888", DriverName = "kumar", Email = "kumar@gmail.com", PhoneNumber = "9653842154", Rating = "3*", IsActive = false });
            paymentLists.Add(new PaymentList() { DriverId = 3, RegistrationCode = "4444", DriverName = "saron", Email = "saron@gmail.com", PhoneNumber = "9635626584", Rating = "2*", IsActive = true });
            paymentLists.Add(new PaymentList() { DriverId = 4, RegistrationCode = "2222", DriverName = "poobesh", Email = "poobesh@gmail.com", PhoneNumber = "9658436254", Rating = "4*", IsActive = false });

            return this.OK<List<PaymentList>>(paymentLists);
        }

        [HttpGet]
        [Route("EarningsPaymentList")]
        [Authorize]
        public IActionResult EarningsPaymentList()
        {
            List<PaymentList> paymentLists = new List<PaymentList>();
            paymentLists.Add(new PaymentList() { DriverId = 1, RegistrationCode = "5555", DriverName = "rajesh", Email = "rajesh@gmail.com", PhoneNumber = "9876787676", Rating = "5*", IsActive = true });
            paymentLists.Add(new PaymentList() { DriverId = 2, RegistrationCode = "8888", DriverName = "kumar", Email = "kumar@gmail.com", PhoneNumber = "9653842154", Rating = "3*", IsActive = false });
            paymentLists.Add(new PaymentList() { DriverId = 3, RegistrationCode = "4444", DriverName = "saron", Email = "saron@gmail.com", PhoneNumber = "9635626584", Rating = "2*", IsActive = true });
            paymentLists.Add(new PaymentList() { DriverId = 4, RegistrationCode = "2222", DriverName = "poobesh", Email = "poobesh@gmail.com", PhoneNumber = "9658436254", Rating = "4*", IsActive = false });

            return this.OK<List<PaymentList>>(paymentLists);
        }
    }
}
