using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly TaxiAppzDBContext _content;
        public DriverController(TaxiAppzDBContext content)
        {
            _content = content;
        }
        [HttpGet]
        [Route("DriverList")]
        [Authorize]
        public IActionResult DriverList()
        {
            List<Driver> driverlist = new List<Driver>();
            driverlist.Add(new Driver() { DriverId = 1,RegisterationCode="00123", DriverName = "Sundar",Rating="5",AcceptanceRatio="100%", OperatorName = "newtest", Phone = "9894996328", Email = "sasi28it@gmail.com", IsActive = true });
            driverlist.Add(new Driver() { DriverId = 2, RegisterationCode = "00124", DriverName = "Ganesh", Rating = "4.98", AcceptanceRatio = "98%", OperatorName = "sasi", Phone = "9894996328", Email = "sasikumarnplus@gmail.com",  IsActive = true });
            driverlist.Add(new Driver() { DriverId = 3, RegisterationCode = "00125", DriverName = "Dinesh", Rating = "4.60", AcceptanceRatio = "97%", OperatorName = "Something", Phone = "9894996328", Email = "company@mail.com", IsActive = false });
            return this.OK<List<Driver>>(driverlist);
        }
        [HttpGet]
        [Route("DriverListBlocked")]
        [Authorize]
        public IActionResult DriverListBlocked()
        {
            List<Driver> driverlist = new List<Driver>();
            driverlist.Add(new Driver() { DriverId = 1, RegisterationCode = "00123", DriverName = "Sundar", Rating = "5",   Phone = "9894996328", Email = "sasi28it@gmail.com",BlockedStatus= "Documents not uploaded", IsActive = false });
            driverlist.Add(new Driver() { DriverId = 2, RegisterationCode = "00124", DriverName = "Ganesh", Rating = "4.98",  Phone = "9894996328", Email = "sasikumarnplus@gmail.com", BlockedStatus = "Documents not uploaded", IsActive = false });
            driverlist.Add(new Driver() { DriverId = 3, RegisterationCode = "00125", DriverName = "Dinesh", Rating = "4.60",  Phone = "9894996328", Email = "company@mail.com", BlockedStatus = "Documents not uploaded", IsActive = false });
            return this.OK<List<Driver>>(driverlist);
        }
        [HttpGet]
        [Route("ManageFine")]
        [Authorize]
        public IActionResult ManageFine()
        {
            List<Driver> driverlist = new List<Driver>();
            driverlist.Add(new Driver() { DriverId = 1, RegisterationCode = "00123", DriverName = "Sundar", Amount = "JOD 25.00", FineReason="Testing", Phone = "9894996328",  IsActive = false });
            driverlist.Add(new Driver() { DriverId = 2, RegisterationCode = "00124", DriverName = "Ganesh", Amount = "JOD 54.00", FineReason = "Sample", Phone = "9894996328", IsActive = false });
            driverlist.Add(new Driver() { DriverId = 3, RegisterationCode = "00125", DriverName = "Dinesh", Amount = "JOD 23.00", FineReason = "Demo", Phone = "9894996328",  IsActive = false });
            return this.OK<List<Driver>>(driverlist);
        }
        [HttpGet]
        [Route("ManageBonus")]
        [Authorize]
        public IActionResult ManageBonus()
        {
            List<Driver> driverlist = new List<Driver>();
            driverlist.Add(new Driver() { DriverId = 1, RegisterationCode = "00123", DriverName = "Sundar", Amount = "JOD 25.00", BonusReason = "Testing", Phone = "9894996328", IsActive = false });
            driverlist.Add(new Driver() { DriverId = 2, RegisterationCode = "00124", DriverName = "Ganesh", Amount = "JOD 54.00", BonusReason = "Sample", Phone = "9894996328", IsActive = false });
            driverlist.Add(new Driver() { DriverId = 3, RegisterationCode = "00125", DriverName = "Dinesh", Amount = "JOD 23.00", BonusReason = "Demo", Phone = "9894996328", IsActive = false });
            return this.OK<List<Driver>>(driverlist);
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
