using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TaziappzMobileWebAPI.DALayer;

namespace TaziappzMobileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IHubContext<MessageHub> _messageHubContext;

        public MessageController(IHubContext<MessageHub> messageHubContext)
        {
            _messageHubContext = messageHubContext;
        }
        [AllowAnonymous]
        [Route("TriggerMessage")]
        [HttpPost]
        public IActionResult Post()
        {
            //Broadcast message to client  
            _messageHubContext.Clients.All.SendAsync("send", "Hello from the hub server at " +
DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));

            return Ok();
        }
    }
}
