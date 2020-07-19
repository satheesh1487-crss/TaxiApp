using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancelManagementController : ControllerBase
    {
        private readonly TaxiAppzDBContext _content;
        public CancelManagementController(TaxiAppzDBContext content)
        {
            _content = content;
        }
        [HttpGet]
        [Route("ManageUser")]
        [Authorize]
        public IActionResult ManageUser()
        {
            List<CancelUser> cancelUsers = new List<CancelUser>();
            cancelUsers.Add(new CancelUser() { Sno = 1, CancellationList = "Driver dont need to go to destination", PayingStatus = "Free", Type = "User", ArrivalStatus = "After Arrived", IsActive = true });
            cancelUsers.Add(new CancelUser() { Sno = 2, CancellationList = "car breakdown", PayingStatus = "Free", Type = "User", ArrivalStatus = "Before Arrive", IsActive = true });
            cancelUsers.Add(new CancelUser() { Sno = 3, CancellationList = "test reason", PayingStatus = "Free", Type = "User", ArrivalStatus = "After Arrived", IsActive = true });
            return this.OK<List<CancelUser>>(cancelUsers);
        }
        [HttpGet]
        [Route("ManageDrivers")]
        [Authorize]
        public IActionResult ManageDrivers()
        {
            List<CancelDriver> cancelDrivers = new List<CancelDriver>();
            cancelDrivers.Add(new CancelDriver() { Sno = 1, CancellationList = "Test reason", PayingStatus = "Free", Type = "User", ArrivalStatus = "Before Arrive", IsActive = true });
            return this.OK<List<CancelDriver>>(cancelDrivers);
        }
    }
}
