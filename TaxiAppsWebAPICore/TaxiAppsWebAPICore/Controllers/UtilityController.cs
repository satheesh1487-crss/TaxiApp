using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;
using System.Web;
namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public UtilityController(TaxiAppzDBContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Use to display List of Country
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getCountry")]
        [Authorize]
        public IActionResult GetCountry()
        {
            DAAdmin dAAdmin = new DAAdmin();
            return this.OK<List<CountryList>>(dAAdmin.GetCountryList(_context));
        }
        /// <summary>
        /// Use to Get Zone zone list by passing country id 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetZoneAccess")]
        [Authorize]
        public IActionResult GetZoneAccess(long countryid)
        {
            DAAdmin dAAdmin = new DAAdmin();
            return this.OK<List<Timezone>>(dAAdmin.GetTimeZoneList(_context,countryid));
        }
        /// <summary>
        /// Use to Get list of languages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetLanguageList")]
        [Authorize]
        public IActionResult GetLanguageList()
        {
            DAAdmin dAAdmin = new DAAdmin();
            return this.OK<List<Language>>(dAAdmin.GetLanguageList(_context));
        }
       
        //TODO:: Please add table name 
        //[HttpGet]
        //[Route("getCurrency")]
        //[Authorize]
        //public IActionResult GetCurrency()
        //{
        //    List<CurrencyList> curList = new List<CurrencyList>();
        //    var countryData = _context.t.ToList();
        //    foreach (var currency in curList)
        //    {
        //        curList.Add(new CurrencyList()
        //        {
        //            CurrencyId = currency.CurrencyId,
        //            CurrencyName = currency.CurrencyName

        //        });
        //    }
        //    return this.OK<List<CurrencyList>>(curList);
        //}

    }
}
