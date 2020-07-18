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

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public CountryController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getCountry")]
        [Authorize]
        public IActionResult GetCountry()
        {
            List<CountryList> countryList = new List<CountryList>();
            var countryData = _context.TabCountry.ToList();
            foreach (var country in countryData)
            {
                countryList.Add(new CountryList()
                {
                    CountryId = country.CountryId,
                    CountryCode = country.Code,
                    CountryName= country.Name,
                    MobileCode = country.DCode,
                });
            }
            return this.OK<List<CountryList>>(countryList);
        }

    }
}
