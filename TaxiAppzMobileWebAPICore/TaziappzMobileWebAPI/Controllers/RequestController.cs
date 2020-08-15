using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.DALayer;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        public readonly TaxiAppzDBContext context;
        public RequestController(TaxiAppzDBContext _context)
        {
            context = _context;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("PostRequest")]
        public IActionResult PostRequest([FromBody] LatLong latLong)
        {
            DARequest dARequest = new DARequest();
            Zone zone = new Zone();
            zone = dARequest.GetRequest(latLong, context);
            return this.OK<Zone>(zone, zone.IsExist == 0 ? "No Data Found" : "Data Found", zone == null ? 0 : 1);
        }
    }
}
