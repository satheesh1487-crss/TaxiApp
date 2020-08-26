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
using TaxiAppsWebAPICore.Helper;

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


        //TODO:: Duplicate record check
        //TODO:: check parent record is deleted
        [HttpPost]
        [Route("saveCurrency")]
        [Authorize]
        public IActionResult SaveCurrency(CurrencyInfo currencyInfo)
        {
            try
            {
                DACurrency dACurrency = new DACurrency();
                return this.OKResponse(dACurrency.AddCurrency(_context, currencyInfo, User.ToAppUser()) ? "Inserted Successfully" : "Insertion Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }

        }


        //TODO:: Duplicate record check
        [HttpPut]
        [Route("editCurrency")]
        [Authorize]
        public IActionResult EditCurrency(CurrencyInfo currencyInfo)
        {
            try
            {
                DACurrency dACurrency = new DACurrency();
                return this.OKResponse(dACurrency.EditCurrency(_context, currencyInfo, User.ToAppUser()) ? "Updated Successfully" : "Updation Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }

        }

        //TODO:: check parent record is deleted
        [HttpDelete]
        [Route("deleteCurrency")]
        [Authorize]
        public IActionResult DeleteCurrency(long id)
        {
            try
            {
                DACurrency dACurrency = new DACurrency();
                return this.OKResponse(dACurrency.DeleteCurrency(_context, id, User.ToAppUser()) ? "Deleted Successfully" : "Deletion Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
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
            try
            {
                DACurrency dACurrency = new DACurrency();
                return this.OKResponse(dACurrency.StatusType(_context, id, isStatus, User.ToAppUser()) == true ? (isStatus == true ? "Active Successfully" : "InActive Successfully") : "Failed to Update");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
            
        }

    }

}
