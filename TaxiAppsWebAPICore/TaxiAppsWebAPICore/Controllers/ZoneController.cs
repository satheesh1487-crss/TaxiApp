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
            DAZone dAZone = new DAZone();
            return this.OK<List<ManageZone>>(dAZone.ListZone(_context));
        }
        [HttpGet]
        [Route("GetZonedetails")]
        [Authorize]
        public IActionResult GetZonedetails(long zoneid)
        {
            DAZone dAZone = new DAZone();
            return this.OK<ManageZone>(dAZone.GetZonedetails(zoneid, _context));
        }
        [HttpPost]
        [Route("AddZone")]
        [Authorize]
        public IActionResult AddZone([FromBody] ManageZoneAdd manageZone)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.AddZone(manageZone, _context) ? "Zone Created" : "Zone Creation Failed");
        }
        [HttpPut]
        [Route("EditZone")]
        [Authorize]
        public IActionResult EditZone([FromBody] ManageZoneAdd manageZone)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.EditZone(manageZone, _context) ? "Zone Updated" : "Zone Updation Failed");
        }
        [HttpDelete]
        [Route("DeleteZone")]
        [Authorize]
        public IActionResult DeleteZone(long zoneid)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.DeleteZone(zoneid, _context) ? "Zone Deleted" : "Zone Deletion Failed");
        }
        [HttpPut]
        [Route("ActiveZone")]
        [Authorize]
        public IActionResult ActiveZone(long zoneid,bool isStatus)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.ActiveZone(zoneid, isStatus, _context) ? "Zone Active/Inactive" : "Failed");
        }
    }
}
