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
    public class ReferralController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public ReferralController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetReferral")]
        [Authorize]
        public IActionResult GetReferral()
        {
            DAReferral dAReferral = new DAReferral();
            return this.OK<ManageReferral>(dAReferral.GetActiveReferral(_context));
        }


        [HttpGet]
        [Route("UserRefferal")]
        [Authorize]
        public IActionResult UserRefferal()
        {

            List<UserReferral> userReferrals = new List<UserReferral>();
            userReferrals.Add(new UserReferral() { Id = 1, ReferralCode = "REF_1234", AmountEarned = Convert.ToDecimal(0.00), UserName = "Praveen Kumar", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            userReferrals.Add(new UserReferral() { Id = 2, ReferralCode = "REF_1235", AmountEarned = Convert.ToDecimal(0.00), UserName = "Ramesh", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            userReferrals.Add(new UserReferral() { Id = 3, ReferralCode = "REF_1236", AmountEarned = Convert.ToDecimal(0.00), UserName = "Pavan", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            userReferrals.Add(new UserReferral() { Id = 4, ReferralCode = "REF_1237", AmountEarned = Convert.ToDecimal(0.00), UserName = "Moorthy", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            userReferrals.Add(new UserReferral() { Id = 5, ReferralCode = "REF_1238", AmountEarned = Convert.ToDecimal(0.00), UserName = "Venkat", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            userReferrals.Add(new UserReferral() { Id = 6, ReferralCode = "REF_1239", AmountEarned = Convert.ToDecimal(0.00), UserName = "Surya", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            return this.OK<List<UserReferral>>(userReferrals);
        }
        [HttpGet]
        [Route("DriverRefferal")]
        [Authorize]
        public IActionResult DriverRefferal()
        {
            List<DriverRefferal> driverRefferals = new List<DriverRefferal>();
            driverRefferals.Add(new DriverRefferal() { Id = 1, ReferralCode = "REF_4324", AmountEarned = Convert.ToDecimal(0.00), UserName = "Kumar" });
            driverRefferals.Add(new DriverRefferal() { Id = 2, ReferralCode = "REF_4325", AmountEarned = Convert.ToDecimal(0.00), UserName = "Arun" });
            driverRefferals.Add(new DriverRefferal() { Id = 3, ReferralCode = "REF_4326", AmountEarned = Convert.ToDecimal(0.00), UserName = "Naveen" });
            driverRefferals.Add(new DriverRefferal() { Id = 4, ReferralCode = "REF_4327", AmountEarned = Convert.ToDecimal(0.00), UserName = "Krishna" });
            driverRefferals.Add(new DriverRefferal() { Id = 5, ReferralCode = "REF_4328", AmountEarned = Convert.ToDecimal(0.00), UserName = "Sarathi" });
            driverRefferals.Add(new DriverRefferal() { Id = 6, ReferralCode = "REF_4329", AmountEarned = Convert.ToDecimal(0.00), UserName = "Naveen" });
            return this.OK<List<DriverRefferal>>(driverRefferals);
        }

        [HttpPost]
        [Route("saveReferral")]
        [Authorize]
        public IActionResult SaveReferral(ManageReferral manageReferral)
        {
            DAReferral dAReferral = new DAReferral();
            return this.OKResponse(dAReferral.SaveReferral(manageReferral, _context, User.ToAppUser()) ? "Inserted Successfully" : "Insertion Failed");
            List<UserReferral> userReferrals = new List<UserReferral>();
            userReferrals.Add(new UserReferral() { Id = 1, ReferralCode = "REF_1234", AmountEarned = Convert.ToDecimal(0.00), UserName = "Praveen Kumar", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            userReferrals.Add(new UserReferral() { Id = 2, ReferralCode = "REF_1235", AmountEarned = Convert.ToDecimal(0.00), UserName = "Ramesh", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            userReferrals.Add(new UserReferral() { Id = 3, ReferralCode = "REF_1236", AmountEarned = Convert.ToDecimal(0.00), UserName = "Pavan", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            userReferrals.Add(new UserReferral() { Id = 4, ReferralCode = "REF_1237", AmountEarned = Convert.ToDecimal(0.00), UserName = "Moorthy", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            userReferrals.Add(new UserReferral() { Id = 5, ReferralCode = "REF_1238", AmountEarned = Convert.ToDecimal(0.00), UserName = "Venkat", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            userReferrals.Add(new UserReferral() { Id = 6, ReferralCode = "REF_1239", AmountEarned = Convert.ToDecimal(0.00), UserName = "Surya", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            return this.OK<List<UserReferral>>(userReferrals);
        }
    }
}
