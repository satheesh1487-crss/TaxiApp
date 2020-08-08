using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

        //TODO:: check parent record is deleted
        [HttpPost]
        [Route("AddZone")]
        [Authorize]
        public IActionResult AddZone([FromBody] ManageZoneAdd manageZone)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.AddZone(manageZone, _context, User.ToAppUser()) ? "Zone Created" : "Zone Creation Failed");
        }

        //TODO:: check parent record is deleted
        [HttpPut]
        [Route("EditZone")]
        [Authorize]
        public IActionResult EditZone([FromBody] ManageZoneAdd manageZone)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.EditZone(manageZone, _context, User.ToAppUser()) ? "Zone Updated" : "Zone Updation Failed");
        }

        //TODO:: check parent record is deleted
        [HttpDelete]
        [Route("DeleteZone")]
        [Authorize]
        public IActionResult DeleteZone(long zoneid)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.DeleteZone(zoneid, _context, User.ToAppUser()) ? "Zone Deleted" : "Zone Deletion Failed");
        }
        [HttpPut]
        [Route("ActiveZone")]
        [Authorize]
        public IActionResult ActiveZone(long zoneid,bool isStatus)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.ActiveZone(zoneid, isStatus, _context, User.ToAppUser()) ? "Active Successfully" : "InActive Successfully");
        }
        [HttpGet]
        [Route("ListZoneType")]
        [Authorize]
        public IActionResult ListZoneType(long zoneid)
        {
            DAZone dAZone = new DAZone();
            return this.OK<List<ZoneTypeList>>(dAZone.ListZoneType(zoneid, _context));
        }

        //TODO:: check parent record is deleted
        [HttpPost]
        [Route("AddZoneType")]
        [Authorize]
        public IActionResult AddZoneType(long zoneid,ZoneTypeRelation zoneTypeRelation)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.AddZoneType(zoneid, zoneTypeRelation, _context, User.ToAppUser()) ? "Saved Successfully" : "Saved Failed");
        }
        [HttpGet]
        [Route("GetZoneTypebyid")]
        [Authorize]
        public IActionResult GetZoneTypebyid(long zoneid,long typeid)
        {
            DAZone dAZone = new DAZone();
            return this.OK<ZoneTypeRelation>(dAZone.GetZoneTypebyid(zoneid, typeid, _context));
        }

        //TODO:: check parent record is deleted
        [HttpPut]
        [Route("EditZoneType")]
        [Authorize]
        public IActionResult EditZoneType(ZoneTypeRelation zoneTypeRelation)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.EditZoneType(zoneTypeRelation, _context, User.ToAppUser()) ? "Updated Successfully" : "updation Failed");
        }
        [HttpPut]
        [Route("ActiveZoneType")]
        [Authorize]
        public IActionResult ActiveZoneType(long zoneid,long typeid,bool isactivestatus,ZoneTypeRelation zoneTypeRelation)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.ActiveZoneType(zoneid,typeid, isactivestatus, _context, User.ToAppUser()) ? "Active Successfully" : "InActive Successfully");
        }
        [HttpPut]
        [Route("DefaultZoneType")]
        [Authorize]
        public IActionResult DefaultZoneType(long zoneid, long typeid, ZoneTypeRelation zoneTypeRelation)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.IsDefaultZoneType(zoneid, typeid, _context, User.ToAppUser()) ? "Updated Successfully" : "updation Failed");
        }
        [HttpGet]
        [Route("GetSetprice")]
        [Authorize]
        public IActionResult GetSetprice(long zoneid, long typeid)
        {
            DAZone dAZone = new DAZone();
            return this.OK<List<SetPrice>>(dAZone.GetSetprice(zoneid, typeid, _context));
        }
        [HttpPut]
        [Route("EditSetprice")]
        [Authorize]
        public IActionResult EditSetprice([FromBody]List<SetPrice> setPrice)
        {
            DAZone dAZone = new DAZone();
            return this.OKResponse(dAZone.EditSetprice(setPrice, _context) ? "Update Successfully" : "Updation Failed");
        }
    }
}
