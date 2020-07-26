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
        [HttpGet]
        [Route("ListZoneType")]
        [Authorize]
        public IActionResult ListZoneType(long zoneid)
        {
            DAZone dAZone = new DAZone();
            return this.OK<List<ZoneTypeList>>(dAZone.ListZoneType(zoneid, _context));
        }
        [HttpPost]
        [Route("AddZoneType")]
        [Authorize]
        public IActionResult AddZoneType(long zoneid,ZoneTypeRelation zoneTypeRelation)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.AddZoneType(zoneid, zoneTypeRelation, _context) ? "Saved Successfully" : "Saved Failed");
        }
        [HttpGet]
        [Route("GetZoneTypebyid")]
        [Authorize]
        public IActionResult GetZoneTypebyid(long zoneid,long typeid, ZoneTypeRelation zoneTypeRelation)
        {
            DAZone dAZone = new DAZone();
            return this.OK<ZoneTypeRelation>(dAZone.GetZoneTypebyid(zoneid, typeid, _context));
        }
        [HttpPut]
        [Route("EditZoneType")]
        [Authorize]
        public IActionResult EditZoneType(ZoneTypeRelation zoneTypeRelation)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.EditZoneType(zoneTypeRelation, _context) ? "Updated Successfully" : "updation Failed");
        }
        [HttpPut]
        [Route("ActiveZoneType")]
        [Authorize]
        public IActionResult ActiveZoneType(long zoneid,long typeid,bool isactivestatus,ZoneTypeRelation zoneTypeRelation)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.ActiveZoneType(zoneid,typeid, isactivestatus, _context) ? "Updated Successfully" : "updation Failed");
        }
        [HttpPut]
        [Route("DefaultZoneType")]
        [Authorize]
        public IActionResult DefaultZoneType(long zoneid, long typeid, ZoneTypeRelation zoneTypeRelation)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.IsDefaultZoneType(zoneid, typeid, _context) ? "Updated Successfully" : "updation Failed");
        }
    }
}
