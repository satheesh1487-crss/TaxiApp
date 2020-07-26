using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
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
            DATypes dATypes = new DATypes();
            return this.OK<List<VehicleTypeList>>(dATypes.ListType(_context));
            
        }

        //TODO:: GET user name 
        //TODO:: Duplicate record check
        [HttpPost]
        [Route("saveType")]
        [Authorize]
        public IActionResult SaveType([FromBody] VehicleTypeInfo vehicleTypeInfo)
        {
            DATypes dATypes = new DATypes();
            return this.OKResponse(dATypes.AddType(_context, vehicleTypeInfo) ? "Inserted Successfully" : "Insertion Failed");
        }

        //TODO:: GET user name 
        //TODO:: Duplicate record check
        [HttpPut]
        [Route("editType")]
        [Authorize]
        public IActionResult EditType([FromBody] VehicleTypeInfo vehicleTypeInfo)
        {
            DATypes dATypes = new DATypes();
            return this.OKResponse(dATypes.EditType(_context, vehicleTypeInfo) ? "Updated Successfully" : "Updation Failed");
        }

        //TODO:: check parent record is deleted
        //TODO:: GET user name
        [HttpDelete]
        [Route("deleteType")]
        [Authorize]
        public IActionResult DeleteType(long id)
        {
            DATypes dATypes = new DATypes();
            return this.OKResponse(dATypes.DeleteType(_context, id) ? "Deleted Successfully" : "Deletion Failed");
        }

        [HttpGet]
        [Route("getTypebyId")]
        [Authorize]
        public IActionResult GetTypebyId(long id)
        {
            DATypes dATypes = new DATypes();
            return this.OK<VehicleTypeInfo>(dATypes.GetbyTypeId(_context, id));
        }

        [HttpPut]
        [Route("statusType")]
        [Authorize]
        public IActionResult StatusType(long id, bool isStatus)
        {
            DATypes dATypes = new DATypes();
            return this.OKResponse(dATypes.StatusType(_context, id, isStatus) ? "Inserted Successfully" : "Insertion Failed");
        }

        [HttpGet]
        [Route("manageVehiclePrice")]
        [Authorize]
        public IActionResult ManageVehiclePrice()
        {
            List<ManageVehiclePriceList> countryList = new List<ManageVehiclePriceList>();
            countryList.Add(new ManageVehiclePriceList() { Id = 1, Image = "sasa", IsActive = true, Name = "mini" });
            countryList.Add(new ManageVehiclePriceList() { Id = 2, Image = "sasa", IsActive = true, Name = "Auto" });
            countryList.Add(new ManageVehiclePriceList() { Id = 3, Image = "sasa", IsActive = true, Name = "Suv" });
            countryList.Add(new ManageVehiclePriceList() { Id = 4, Image = "sasa", IsActive = true, Name = "mini" });
            countryList.Add(new ManageVehiclePriceList() { Id = 5, Image = "sasa", IsActive = true, Name = "mini" });
            countryList.Add(new ManageVehiclePriceList() { Id = 6, Image = "sasa", IsActive = true, Name = "Auto" });
            countryList.Add(new ManageVehiclePriceList() { Id = 7, Image = "sasa", IsActive = true, Name = "Suv" });
            countryList.Add(new ManageVehiclePriceList() { Id = 8, Image = "sasa", IsActive = true, Name = "mini" });
            return this.OK<List<ManageVehiclePriceList>>(countryList);
        }
        //[HttpPost]
        //[Route("managezontype")]
        //[Authorize]
        //public ActionResult ManageZoneType([FromBody] ZoneTypeRleation)
        //{

        //}
    }
}
