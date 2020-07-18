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
    public class ZoneController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public ZoneController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ZoneList")]
        [Authorize]
        public IActionResult ZoneList()
        {
            List<ManageZone> zonelist = new List<ManageZone>();
            zonelist.Add(new ManageZone() { Zoneid = 1, ZoneName = "Chennai", IsActive = true  });
            zonelist.Add(new ManageZone() { Zoneid = 2, ZoneName = "Australia", IsActive = true });
            zonelist.Add(new ManageZone() { Zoneid = 3, ZoneName = "Tunisia", IsActive = true });
            zonelist.Add(new ManageZone() { Zoneid = 4, ZoneName = "palani", IsActive = true });
            zonelist.Add(new ManageZone() { Zoneid = 5, ZoneName = "Canada", IsActive = true });
            zonelist.Add(new ManageZone() { Zoneid = 6, ZoneName = "coimbatore", IsActive = true });
            
            return this.OK<List<ManageZone>>(zonelist);
        }
    }
}
