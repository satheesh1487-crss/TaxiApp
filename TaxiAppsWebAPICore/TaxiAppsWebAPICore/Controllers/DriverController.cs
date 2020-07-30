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
            return this.OKResponse(dADriver.DisableUser(_context, driverid, status, User.ToAppUser()) == true ? "Disabled Successfully" : "Disabled Failed");
        }

        //TODO:: check parent record is deleted
        [HttpPut]
        [Route("Edit")]
        [Authorize]
        public IActionResult Edit(DriverInfo driverInfo)
        {
            DADriver dADriver = new DADriver();
            return this.OKResponse(dADriver.Edit(_context, driverInfo, User.ToAppUser()) == true ? "Updated Successfully" : "Updation Failed");
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

        

        [HttpGet]
        [Route("WalletList")]
        [Authorize]
        public IActionResult WalletList()
        {
            List<ManageWallet> wallet = new List<ManageWallet>();
            wallet.Add(new ManageWallet() { WalletID = 1, RegisterationCode = "00123", Name = "Sundar", Rating = "5", Phone = "9894996328", Email = "sasi28it@gmail.com", IsActive = true });
            wallet.Add(new ManageWallet() { WalletID = 2, RegisterationCode = "00124", Name = "Ganesh", Rating = "4.98", Phone = "9894996328", Email = "sasikumarnplus@gmail.com", IsActive = true });
            wallet.Add(new ManageWallet() { WalletID = 3, RegisterationCode = "00125", Name = "Dinesh", Rating = "4.60", Phone = "9894996328", Email = "company@mail.com", IsActive = false });
            return this.OK<List<ManageWallet>>(wallet);
        }

        [HttpGet]
        [Route("AccountPaymentList")]
        [Authorize]
        public IActionResult AccountPaymentList()
        {
            List<ManageAccountPayment> Accountpayment = new List<ManageAccountPayment>();
            Accountpayment.Add(new ManageAccountPayment() { AccountID = 1, RegisterationCode = "00123", Name = "Sundar", Rating = "5", Phone = "9894996328", Email = "sasi28it@gmail.com", IsActive = true });
            Accountpayment.Add(new ManageAccountPayment() { AccountID = 2, RegisterationCode = "00124", Name = "Ganesh", Rating = "4.98", Phone = "9894996328", Email = "sasikumarnplus@gmail.com", IsActive = true });
            Accountpayment.Add(new ManageAccountPayment() { AccountID = 3, RegisterationCode = "00125", Name = "Dinesh", Rating = "4.60", Phone = "9894996328", Email = "company@mail.com", IsActive = false });
            return this.OK<List<ManageAccountPayment>>(Accountpayment);
        }
        [HttpGet]
        [Route("EarningPaymentList")]
        [Authorize]
        public IActionResult EarningPaymentList()
        {
            List<ManageEarningPayment> Earningpayment = new List<ManageEarningPayment>();
            Earningpayment.Add(new ManageEarningPayment() { EarningID = 1, RegisterationCode = "00123", Name = "Sundar", Rating = "5", Phone = "9894996328", Email = "sasi28it@gmail.com", IsActive = true });
            Earningpayment.Add(new ManageEarningPayment() { EarningID = 2, RegisterationCode = "00124", Name = "Ganesh", Rating = "4.98", Phone = "9894996328", Email = "sasikumarnplus@gmail.com", IsActive = true });
            Earningpayment.Add(new ManageEarningPayment() { EarningID = 3, RegisterationCode = "00125", Name = "Dinesh", Rating = "4.60", Phone = "9894996328", Email = "company@mail.com", IsActive = false });
            return this.OK<List<ManageEarningPayment>>(Earningpayment);
        }
    }
}
