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

        //TODO:: Please updfate table name 
        [HttpGet]
        [Route("listCurrency")]
        [Authorize]
        public IActionResult ListCurrency()
        {
            List<CountryList> countryList = new List<CountryList>();
            var countryData = _context.TabCountry.ToList();
            foreach (var country in countryData)
            {
                countryList.Add(new CountryList()
                {
                    CountryId = country.CountryId,
                    CountryCode = country.Code,
                    CountryName = country.Name,
                    MobileCode = country.DCode,
                });
            }
            return this.OK<List<CountryList>>(countryList);
        }

        [HttpPost]
        [Route("saveCurrency")]
        [Authorize]
        public IActionResult SaveCurrency(CurrencyInfo currencyInfo)
        {
            DACurrency dARoles = new DACurrency();
            return this.OKResponse(dARoles.AddCurrency(_context, currencyInfo) ? "Inserted Successfully" : "Insertion Failed");
        }

        [HttpPut]
        [Route("editCurrency")]
        [Authorize]
        public IActionResult EditCurrency(CurrencyInfo currencyInfo)
        {
            DACurrency dARoles = new DACurrency();
            return this.OKResponse(dARoles.EditCurrency(_context, currencyInfo) ? "Inserted Successfully" : "Insertion Failed");
        }
    }

}
