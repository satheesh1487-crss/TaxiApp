using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiAppsWebAPICore.Models;
using System.Linq;
using TaxiAppsWebAPICore.TaxiModels;
using System.Collections.Generic;
using TaxiAppsWebAPICore.DataAccessLayer;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public CurrencyController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        //TODO:: Please update table name 
        [HttpGet]
        [Route("listStandard")]
        [Authorize]
        public IActionResult ListStandard()
        {

            DACurrency dACurrency = new DACurrency();
            return this.OK<List<StandardList>>(dACurrency.ListStandard(_context));
        }

        //TODO:: Please updfate table name 
        [HttpGet] 
        [Route("listCurrency")]
        [Authorize]
        public IActionResult ListCurrency()
        {

            DACurrency dACurrency = new DACurrency();
            return this.OK<List<CurrencyList>>(dACurrency.ListCurrency(_context));
        }

        //TODO:: GET user name 
        //TODO:: Duplicate record check
        //TODO:: check parent record is deleted
        //TODO:: GET user name
        [HttpPost]
        [Route("saveCurrency")]
        [Authorize]
        public IActionResult SaveCurrency(CurrencyInfo currencyInfo)
        {
            DACurrency dACurrency = new DACurrency();
            return this.OKResponse(dACurrency.AddCurrency(_context, currencyInfo) ? "Inserted Successfully" : "Insertion Failed");
        }

        //TODO:: GET user name 
        //TODO:: Duplicate record check
        [HttpPut]
        [Route("editCurrency")]
        [Authorize]
        public IActionResult EditCurrency(CurrencyInfo currencyInfo)
        {
            DACurrency dACurrency = new DACurrency();
            return this.OKResponse(dACurrency.EditCurrency(_context, currencyInfo) ? "Inserted Successfully" : "Insertion Failed");
        }
        //TODO:: check parent record is deleted
        //TODO:: GET user name
        [HttpDelete]
        [Route("deleteCurrency")]
        [Authorize]
        public IActionResult DeleteCurrency(long id)
        {
            DACurrency dACurrency = new DACurrency();
            return this.OKResponse(dACurrency.DeleteCurrency(_context, id) ? "Deleted Successfully" : "Deletion Failed");
        }

        [HttpGet]
        [Route("getCurrencybyId")]
        [Authorize]
        public IActionResult GetTypebyId(long id)
        {
            DACurrency dACurrency = new DACurrency();
            return this.OK<CurrencyInfo>(dACurrency.GetbyCurrencyId(_context, id));
        }

        [HttpPut]
        [Route("statusType")]
        [Authorize]
        public IActionResult StatusType(long id, bool isStatus)
        {
            DACurrency dACurrency = new DACurrency();
            return this.OKResponse(dACurrency.StatusType(_context, id, isStatus) ? "Inserted Successfully" : "Insertion Failed");
        }

    }

}
