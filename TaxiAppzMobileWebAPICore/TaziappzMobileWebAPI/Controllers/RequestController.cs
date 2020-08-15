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
        [Route("PostRequest")]
        public IActionResult PostRequest([FromBody] LatLong latLong)
        {
            DARequest dARequest = new DARequest();
            Zone zone = new Zone();
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var countryid = tokenS.Claims.First(claim => claim.Type == "country").Value;

            zone = dARequest.GetRequest(latLong, Convert.ToInt64(countryid), context);
            return this.OK<Zone>(zone, zone.IsExist == 0 ? "No Data Found" : "Data Found", zone == null ? 0 : 1);
        }
    }
}
