using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        /// <summary>
        /// Use to Get List of Vehicels based on Zone once click book now
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("CreateRequest")]
        public IActionResult PostRequest([FromBody] LatLong latLong)
        {
            DARequest dARequest = new DARequest();
           List<Zone> zone = new List<Zone>();
           zone = dARequest.GetRequest(latLong,User.ToAppUser(),context);
            return this.OK<Zone>(zone, zone.Count == 0 ? "Request_Data_Not_Found" : "Request_Data_Found");
        }
        /// <summary>
        /// Use to Sent Push notification to Drivers based on User request
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("Requestprogress")]
        public IActionResult Requestprogress([FromBody] RequestVehicleType requestVehicleType)
        {
            DARequest dARequest = new DARequest();
            bool result = dARequest.Requestprogress(requestVehicleType, User.ToAppUser(), context);
            return this.OKStatus(result ? "Data Found" : "No Data Found");
        }
    }
}
