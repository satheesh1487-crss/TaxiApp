using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.DataAccessLayer;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public SettingsController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetTripSettings")]
        [Authorize]
        public IActionResult GetTripSettings()
        {
            DASettings dASettings = new DASettings();
            return this.OK<TripSettings>(dASettings.GetTripSettings(_context));
        }

        [HttpPost]
        [Route("saveSurgePrice")]
        [Authorize]
        public IActionResult SaveTripSettings(TripSettings tripSettings)
        {
            try
            {
                DASettings dASettings = new DASettings();
                return this.OKResponse(dASettings.SaveTripSettings(tripSettings, _context, User.ToAppUser()) ? "Updated Successfully" : "Failed to Update");
            }
            catch (TaxiAppsWebAPICore.Helper.DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }
    }
}
