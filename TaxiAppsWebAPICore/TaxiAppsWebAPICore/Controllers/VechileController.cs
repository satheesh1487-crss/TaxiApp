using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using TaxiAppsWebAPICore.Helper;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;
using TaziappzMobileWebAPI.Models;

namespace TaxiAppsWebAPICore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VechileController : ControllerBase
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
            DAVechile dATypes = new DAVechile();
            return this.OK<List<VehicleTypeList>>(dATypes.ListType(_context));
        }


        //TODO:: Duplicate record check
        [HttpPost]
        [Route("saveType")]
        [Authorize]
        public IActionResult SaveType([FromBody] VehicleTypeInfo vehicleTypeInfo)
        {
            try
            {
                Validator.validateVehicle(vehicleTypeInfo);
                DAVechile dATypes = new DAVechile();
                return this.OKResponse(dATypes.AddType(_context, vehicleTypeInfo, User.ToAppUser()) ? "Inserted Successfully" : "Insertion Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }          
        }


        //TODO:: Duplicate record check
        [HttpPut]
        [Route("editType")]
        [Authorize]
        public IActionResult EditType([FromBody] VehicleTypeInfo vehicleTypeInfo)
        {
            try
            {
                Validator.validateVehicle(vehicleTypeInfo);
                DAVechile dATypes = new DAVechile();
                return this.OKResponse(dATypes.EditType(_context, vehicleTypeInfo, User.ToAppUser()) ? "Updated Successfully" : "Updation Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }            
        }

        //TODO:: check parent record is deleted
        [HttpDelete]
        [Route("deleteType")]
        [Authorize]
        public IActionResult DeleteType(long id)
        {
            DAVechile dATypes = new DAVechile();
            return this.OKResponse(dATypes.DeleteType(_context, id, User.ToAppUser()) ? "Deleted Successfully" : "Deletion Failed");
        }

        [HttpGet]
        [Route("getTypebyId")]
        [Authorize]
        public IActionResult GetTypebyId(long id)
        {
            DAVechile dATypes = new DAVechile();
            return this.OK<VehicleTypeInfo>(dATypes.GetbyTypeId(_context, id));
        }

        [HttpPut]
        [Route("statusType")]
        [Authorize]
        public IActionResult StatusType(long id, bool isStatus)
        {
            DAVechile dATypes = new DAVechile();
            return this.OKResponse(dATypes.StatusType(_context, id, isStatus, User.ToAppUser()) == true ? (isStatus == true ? "Active Successfully" : "Blocked Successfully") : "Failed to Update");
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


        [HttpGet]
        [Route("listEmer")]
        [Authorize]
        public IActionResult ListEmer()
        {
            DAVechile dAVechile = new DAVechile();
            return this.OK<List<VehicleEmerList>>(dAVechile.ListEmer(_context));

        }

        //TODO:: Duplicate record checkGetSetprice
        [HttpPost]
        [Route("saveEmer")]
        [Authorize]
        public IActionResult SaveEmer([FromBody] VehicleEmerInfo vehicleEmerInfo)
        {
            try
            {
                Validator.validateEmerAddVehicle(vehicleEmerInfo);
                DAVechile dAVechile = new DAVechile();
                return this.OKResponse(dAVechile.SaveEmer(_context, vehicleEmerInfo, User.ToAppUser()) ? "Inserted Successfully" : "Insertion Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }            
        }

        //TODO:: Duplicate record check
        [HttpPut]
        [Route("editEmer")]
        [Authorize]
        public IActionResult EditEmer([FromBody] VehicleEmerInfo vehicleEmerInfo)
        {
            try
            {
                Validator.validateEmerEditVehicle(vehicleEmerInfo);
                DAVechile dAVechile = new DAVechile();
                return this.OKResponse(dAVechile.EditEmer(_context, vehicleEmerInfo, User.ToAppUser()) ? "Updated Successfully" : "Updation Failed");
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }           
        }

        //TODO:: check parent record is deleted
        [HttpDelete]
        [Route("deleteEmer")]
        [Authorize]
        public IActionResult DeleteEmer(long id)
        {
            DAVechile dAVechile = new DAVechile();
            return this.OKResponse(dAVechile.DeleteEmer(_context, id, User.ToAppUser()) ? "Deleted Successfully" : "Deletion Failed");
        }

        [HttpGet]
        [Route("getbyEmerId")]
        [Authorize]
        public IActionResult GetbyEmerId(long id)
        {
            DAVechile dAVechile = new DAVechile();
            return this.OK<VehicleEmerInfo>(dAVechile.GetbyEmerId(_context, id));
        }

        [HttpPut]
        [Route("statusEmer")]
        [Authorize]
        public IActionResult StatusEmer(long id, bool isStatus)
        {
            DAVechile dAVechile = new DAVechile();
            return this.OKResponse(dAVechile.StatusEmer(_context, id, isStatus, User.ToAppUser()) == true ? (isStatus == true ? "Active Successfully" : "InActive Successfully") : "Failed to Update");
        }


        [HttpGet]
        [Route("listTypeWithZone")]
        [Authorize]
        public IActionResult ListTypeWithZone()
        {
            DAVechile dATypes = new DAVechile();
            return this.OK<List<VehicleTypeZoneList>>(dATypes.ListTypeWithZone(_context));

        }

        [HttpGet]
        [Route("GetSurgePrice")]
        [Authorize]
        public IActionResult GetSurgePrice(long id)
        {
            DAVechile dATypes = new DAVechile();
            return this.OK<SurgePrice>(dATypes.GetSurgePrice(_context,id));
        }

        [HttpPost]
        [Route("saveSurgePrice")]
        [Authorize]
        public IActionResult SaveSurgePrice(SurgePrice surgePrice)
        {
            try
            {
                DAVechile dATypes = new DAVechile();
                return this.OKResponse(dATypes.SaveSurgePrice(surgePrice, _context, User.ToAppUser()) ? "Updated Successfully" : "Failed to Update");
            }
            catch (TaxiAppsWebAPICore.Helper.DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }
    }
}
