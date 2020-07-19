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
    public class ReferralController : ControllerBase
    {
        private readonly TaxiAppzDBContext _content;
        public ReferralController(TaxiAppzDBContext content)
        {
            _content = content;
        }
        [HttpGet]
        [Route("UserRefferal")]
        [Authorize]
        public IActionResult UserRefferal()
        {
            List<UserReferral> userReferrals = new List<UserReferral>();
            userReferrals.Add(new UserReferral() { SNo = 1, ReferralCode = "REF_1234",  AmountEarned = Convert.ToDecimal(0.00), UserName = "Praveen Kumar", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00)  });
            userReferrals.Add(new UserReferral() { SNo = 2, ReferralCode = "REF_1235", AmountEarned = Convert.ToDecimal(0.00), UserName = "Ramesh", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            userReferrals.Add(new UserReferral() { SNo = 3, ReferralCode = "REF_1236", AmountEarned = Convert.ToDecimal(0.00), UserName = "Pavan", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            userReferrals.Add(new UserReferral() { SNo = 4, ReferralCode = "REF_1237", AmountEarned = Convert.ToDecimal(0.00), UserName = "Moorthy", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });

            userReferrals.Add(new UserReferral() { SNo =5, ReferralCode = "REF_1238", AmountEarned = Convert.ToDecimal(0.00), UserName = "Venkat", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            userReferrals.Add(new UserReferral() { SNo = 6, ReferralCode = "REF_1239", AmountEarned = Convert.ToDecimal(0.00), UserName = "Surya", AmountSpent = Convert.ToDecimal(0.00), AmountBalance = Convert.ToDecimal(0.00) });
            return this.OK<List<UserReferral>>(userReferrals);
        }
        [HttpGet]
        [Route("DriverRefferal")]
        [Authorize]
        public IActionResult DriverRefferal()
        {
            List<DriverRefferal> driverRefferals = new List<DriverRefferal>();
            driverRefferals.Add(new DriverRefferal() { SNo = 1, ReferralCode = "REF_4324", AmountEarned = Convert.ToDecimal(0.00), UserName = "Kumar"  });
            driverRefferals.Add(new DriverRefferal() { SNo = 2, ReferralCode = "REF_4325", AmountEarned = Convert.ToDecimal(0.00), UserName = "Arun"  });
            driverRefferals.Add(new DriverRefferal() { SNo = 3, ReferralCode = "REF_4326", AmountEarned = Convert.ToDecimal(0.00), UserName = "Naveen"  });
            driverRefferals.Add(new DriverRefferal() { SNo = 4, ReferralCode = "REF_4327", AmountEarned = Convert.ToDecimal(0.00), UserName = "Krishna"  });

            driverRefferals.Add(new DriverRefferal() { SNo = 5, ReferralCode = "REF_4328", AmountEarned = Convert.ToDecimal(0.00), UserName = "Sarathi"  });
            driverRefferals.Add(new DriverRefferal() { SNo = 6, ReferralCode = "REF_4329", AmountEarned = Convert.ToDecimal(0.00), UserName = "Naveen"  });
            return this.OK<List<DriverRefferal>>(driverRefferals);
        }
    }
}
