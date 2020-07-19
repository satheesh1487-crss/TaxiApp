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
    public class PromoManagementController : ControllerBase
    {
        private readonly TaxiAppzDBContext _content;
        public PromoManagementController(TaxiAppzDBContext content)
        {
            _content = content;
        }
        [HttpGet]
        [Route("ManageOption")]
        [Authorize]
        public IActionResult ManageOption()
        {
            List<ManagePromo> managePromos = new List<ManagePromo>();
            managePromos.Add(new ManagePromo() { Sno = 1, CoupenCode = "TYP_1234", EstimateAmount = Convert.ToInt64(10), Value = 5, Type = "Fixed", Uses = Convert.ToInt64(50),StartDate= "2020-06-08",ExpiryDate= "2020-06-09",Operation= "All",IsActive=true });
            managePromos.Add(new ManagePromo() { Sno = 2, CoupenCode = "TYP_1235", EstimateAmount = Convert.ToInt64(100), Value = 5, Type = "Fixed", Uses = Convert.ToInt64(100), StartDate = "2020-05-13", ExpiryDate = "2020-05-31", Operation = "All", IsActive = true });
            managePromos.Add(new ManagePromo() { Sno = 3, CoupenCode = "TYP_1236", EstimateAmount = Convert.ToInt64(200), Value = 5, Type = "Fixed", Uses = Convert.ToInt64(200), StartDate = "2019-05-13", ExpiryDate = "2019-05-31", Operation = "All", IsActive = true });
            return this.OK<List<ManagePromo>>(managePromos);
        }
        [HttpGet]
        [Route("PromoTransaction")]
        [Authorize]
        public IActionResult PromoTransaction()
        {
            List<PromoTransaction> promoTransactions = new List<PromoTransaction>();
            promoTransactions.Add(new PromoTransaction() { Sno = 1, CoupenCode = "TYP_1234",  Value = 080606, Type = "Fixed", Uses = Convert.ToInt64(50), UserName="Jagan", Operation = "All"   });
            promoTransactions.Add(new PromoTransaction() { Sno = 2, CoupenCode = "TYP_1235", Value = 080606, Type = "Fixed", Uses = Convert.ToInt64(100), UserName="Dilip", Operation = "All"  });
            promoTransactions.Add(new PromoTransaction() { Sno = 3, CoupenCode = "TYP_1236",  Value = 080606, Type = "Fixed", Uses = Convert.ToInt64(200), UserName="Sundar V", Operation = "All"  });

            promoTransactions.Add(new PromoTransaction() { Sno = 4, CoupenCode = "TYP_1237", Value = 080606, Type = "Fixed", Uses = Convert.ToInt64(50), UserName = "Jagan", Operation = "All" });
            promoTransactions.Add(new PromoTransaction() { Sno = 5, CoupenCode = "TYP_1238", Value = 080606, Type = "Fixed", Uses = Convert.ToInt64(100), UserName = "Dilip", Operation = "All" });
            promoTransactions.Add(new PromoTransaction() { Sno = 6, CoupenCode = "TYP_1239", Value = 080606, Type = "Fixed", Uses = Convert.ToInt64(200), UserName = "Sundar V", Operation = "All" });

            return this.OK<List<PromoTransaction>>(promoTransactions);
        }
    }
}
