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
    public class ReviewManagementController : ControllerBase
    {
        private readonly TaxiAppzDBContext _content;
        public ReviewManagementController(TaxiAppzDBContext content)
        {
            _content = content;
        }
        [HttpGet]
        [Route("UsertoDriver")]
        [Authorize]
        public IActionResult UsertoDriver()
        {
            List<UsertoDriver> usertoDrivers = new List<UsertoDriver>();
            usertoDrivers.Add(new UsertoDriver() { Sno = 1, UserName = "Jagan", Rating = Convert.ToDecimal(0), Comment="" ,RequestID = 280, DriverName = "Vasudev", IsActive = true });
            usertoDrivers.Add(new UsertoDriver() { Sno = 2, UserName = "Dilip", Rating = Convert.ToDecimal(4.95), Comment = "", RequestID = 281, DriverName = "Lakshman", IsActive = true });
            usertoDrivers.Add(new UsertoDriver() { Sno = 3, UserName = "Sasi", Rating = Convert.ToDecimal(3.0), Comment = "", RequestID = 282, DriverName = "Raju", IsActive = true });
            usertoDrivers.Add(new UsertoDriver() { Sno = 4, UserName = "Arjun", Rating = Convert.ToDecimal(4.5), Comment = "", RequestID = 283, DriverName = "Anandh", IsActive = true });
            return this.OK<List<UsertoDriver>>(usertoDrivers);
        }
        [HttpGet]
        [Route("DrivertoUser")]
        [Authorize]
        public IActionResult DrivertoUser()
        {
            List<DrivertoUser> drivertoUsers = new List<DrivertoUser>();
            drivertoUsers.Add(new DrivertoUser() { Sno = 1, UserName = "Ranjith", Rating = Convert.ToDecimal(4.96), Comment = "Additional Comments", RequestID = 280, DriverName = "Rajesh", IsActive = true });
            drivertoUsers.Add(new DrivertoUser() { Sno = 2, UserName = "Kumar", Rating = Convert.ToDecimal(4.98), Comment = "Additional Comments", RequestID = 281, DriverName = "Kannan", IsActive = true });
            drivertoUsers.Add(new DrivertoUser() { Sno = 3, UserName = "Sathish", Rating = Convert.ToDecimal(4.96), Comment = "Additional Comments", RequestID = 282, DriverName = "Jalil", IsActive = true });
            drivertoUsers.Add(new DrivertoUser() { Sno = 4, UserName = "Sundar", Rating = Convert.ToDecimal(4.95), Comment = "Additional Comments", RequestID = 283, DriverName = "Akash", IsActive = true });
            return this.OK<List<DrivertoUser>>(drivertoUsers);
        }
    }
}
