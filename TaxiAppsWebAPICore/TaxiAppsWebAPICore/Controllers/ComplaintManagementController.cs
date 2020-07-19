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
    public class ComplaintManagementController : ControllerBase
    {
        private readonly TaxiAppzDBContext _content;
        public ComplaintManagementController(TaxiAppzDBContext content)
        {
            _content = content;
        }
        [HttpGet]
        [Route("Manageuser")]
        [Authorize]
        public IActionResult Manageuser()
        {
            List<ManageUser> manageUsers = new List<ManageUser>();
            manageUsers.Add(new ManageUser() { Sno = 1, ComplaintType = "Suggestion", ComplaintTitle = "Test Complaint", Description = "Testing", RequestID = "REQ_280", CustomerName = "Vasudev", IsActive = "new" });
            manageUsers.Add(new ManageUser() { Sno = 2, ComplaintType = "Suggestion", ComplaintTitle = "Test Complaint", Description = "Demo", RequestID = "REQ_281", CustomerName = "Srijha", IsActive = "new" });
            manageUsers.Add(new ManageUser() { Sno = 3, ComplaintType = "Suggestion", ComplaintTitle = "Test Complaint", Description = "Sample", RequestID = "REQ_282", CustomerName = "Sri Devi", IsActive = "new" });
            return this.OK<List<ManageUser>>(manageUsers);
        }
        [HttpGet]
        [Route("ManageDriver")]
        [Authorize]
        public IActionResult ManageDriver()
        {
            List<ManageDriver> manageDrivers = new List<ManageDriver>();
            manageDrivers.Add(new ManageDriver() { Sno = 1, ComplaintType = "Complaint", ComplaintTitle = "not pick up the call", Description = "Testing", RequestID = "RES_81117", DriverName = "Vasudev", IsActive = "New" });

            return this.OK<List<ManageDriver>>(manageDrivers);
        }
    }
}
