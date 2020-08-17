using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaziappzMobileWebAPI.DALayer;
using TaziappzMobileWebAPI.TaxiModels;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace TaziappzMobileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneAccessController : ControllerBase
    {
        public readonly TaxiAppzDBContext context;
        public ZoneAccessController(TaxiAppzDBContext _context)
        {
            context = _context;
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetPolygon([FromBody] LatLong latLong, long servicelocationid)
        {
            DAZone daZone = new DAZone();
            List<LatLong> latLongs = new List<LatLong>();
            latLongs = daZone.GetPolygon(latLong, servicelocationid, context);
            return this.OK<LatLong>(latLongs, latLongs.Count == 0 ? "Data Found" : "No Data Found");
        }
    }
}
