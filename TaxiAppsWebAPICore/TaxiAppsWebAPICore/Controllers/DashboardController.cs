using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.Models;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        [Route("Dashboard")]
        [Authorize]
        public IActionResult DashboardList()
        {
            List<Dashboard> dashboard = new List<Dashboard>();
            dashboard.Add(new Dashboard() 
            { 
                Cancelled_Trips=100,
                Company_Earnings=500,
                Completed_Trips=200,
                Driver_Earnings=150,
                On_Going_Trips=123,
                Payment_Cards=1350,
                Payment_Cash=256,
                Payment_Withdraw=235,
                Total_Active_Users=550,
                Total_Admin_Earnings=3000,
                Total_Active_Drivers=1200,
                Total_Approval_Drivers =250,
                Total_Blocked_Drivers=150,
                Total_Drivers=213,
                Total_Driver_Earnings=125,
                Total_Earnings=2000,
                Total_InActive_Users=150,
                Total_Deleted_Users=125,
                Total_Trips =2500,
                Total_Turnover=550,
                Total_Users=1500                
            });
            return this.OK<List<Dashboard>>(dashboard);
        }
    }
}
