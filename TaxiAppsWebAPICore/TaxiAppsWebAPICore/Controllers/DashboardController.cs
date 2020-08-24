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
    public class DashboardController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public DashboardController(TaxiAppzDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Dashboard")]
        [Authorize]
        public IActionResult DashboardList()
        {
            DADashboard dADashboard = new DADashboard();

            Dashboard dashboard =dADashboard.UserList(_context);
            
            return this.OK<Dashboard>(dashboard);
        }
    }
}
