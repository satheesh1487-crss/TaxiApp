using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.DALayer;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        public readonly TaxiAppzDBContext context;
        public readonly IOptions<SettingModel> settingModel;
        private IHubContext<MessageHub> _messageHubContext;

        public RequestController(TaxiAppzDBContext _context,IOptions<SettingModel> _settingmodel, IHubContext<MessageHub> messageHubContext)
        {
            context = _context;
            settingModel = _settingmodel;
            _messageHubContext = messageHubContext;
        }
        /// <summary>
        /// Use to Get List of Vehicels based on Zone once click book now
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("UserCreateRequest")]
        public IActionResult PostRequest([FromBody] LatLong latLong)
        {
            DARequest dARequest = new DARequest(settingModel);
           List<Zone> zone = new List<Zone>();
           zone = dARequest.GetRequest(latLong,User.ToAppUser(),context);
            return this.OK<List<Zone>>(zone, zone.Count == 0 ? "Request_Data_Not_Found" : "Request_Data_Found", zone.Count == 0 ? 0 : 1);
        }
        /// <summary>
        /// Use to Sent Push notification to Drivers based on User request
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("UserRequestprogress")]
        public IActionResult Requestprogress([FromBody] RequestVehicleType requestVehicleType)
        {
            DARequest dARequest = new DARequest(settingModel);
            UserTripRequest userTripRequest = new UserTripRequest();
            userTripRequest = dARequest.Requestprogress(requestVehicleType, User.ToAppUser(), context);
            if (userTripRequest.IsExist == 0)
                return this.OKStatus("No Data Found",0);
            _messageHubContext.Clients.All.SendAsync("Send", userTripRequest);
                return this.OKStatus(userTripRequest.IsExist == 1 ? "Data Found" : "No Data Found", userTripRequest.IsExist == 1 ? 1 : 0);
        }

        /// <summary>
        /// Use to Sent Push notification to Drivers based on User request
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("UserRequestCancel")]
        public IActionResult RequestCancel([FromBody] DriversCancel  driversCancel)
        {
            DARequest dARequest = new DARequest(settingModel);
            bool result = dARequest.RequestCancel(driversCancel, User.ToAppUser(), context);
            return this.OKStatus(result ? "Data Found" : "No Data Found", result ? 1 : 0);
        }
    }
}
