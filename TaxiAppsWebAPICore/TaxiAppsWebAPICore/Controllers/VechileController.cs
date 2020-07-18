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
   public  class VechileController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public VechileController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listType")]
        [Authorize]
        public IActionResult ListType()
        {
            List<VehicleList> countryList = new List<VehicleList>();
            countryList.Add(new VehicleList() { Id=1, Image = "sasa", IsActive = true , Name = "mini" });
            countryList.Add(new VehicleList() { Id = 2, Image = "sasa", IsActive = true, Name = "Auto" });
            countryList.Add(new VehicleList() { Id = 3, Image = "sasa", IsActive = true, Name = "Suv" });
            countryList.Add(new VehicleList() { Id = 4, Image = "sasa", IsActive = true, Name = "mini" });
            countryList.Add(new VehicleList() { Id = 5, Image = "sasa", IsActive = true, Name = "mini" });
            countryList.Add(new VehicleList() { Id = 6, Image = "sasa", IsActive = true, Name = "Auto" });
            countryList.Add(new VehicleList() { Id = 7, Image = "sasa", IsActive = true, Name = "Suv" });
            countryList.Add(new VehicleList() { Id = 8, Image = "sasa", IsActive = true, Name = "mini" });
            return this.OK<List<VehicleList>>(countryList);
        }
    }
}
