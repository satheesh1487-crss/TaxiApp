using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.Models;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        [HttpGet]
        [Route("GetTripSettings")]
        [Authorize]
        public IActionResult GetTripSettings(long id)
        {
            DAVechile dATypes = new DAVechile();
            return this.OK<TripSettings>(dATypes.GetTripSettings(_context, id));
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
