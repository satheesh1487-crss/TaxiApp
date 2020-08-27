using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DADashboard
    {
        public Dashboard UserList(TaxiAppzDBContext context)
        {
            try
            {

                Dashboard dashboard = new Dashboard();
                var userlist = context.TabRequest.ToList();


                dashboard.Cancelled_Trips = userlist.Where(t => t.IsCancelled == "").Count();
                dashboard.Company_Earnings = 500;
                dashboard.Completed_Trips = 200;
                dashboard.Driver_Earnings = 150;
                dashboard.On_Going_Trips = userlist.Where(t => t.IsDriverStarted == "false").Count();
                dashboard.Payment_Cards = 1350;
                dashboard.Payment_Cash = 256;
                dashboard.Payment_Withdraw = 235;
                dashboard.Total_Active_Users = context.TabUser.Where(t => t.IsDelete == 0 && t.IsActive == true).Count(); ;
                dashboard.Total_Admin_Earnings = 3000;
                dashboard.Total_Active_Drivers = context.TabDrivers.Where(t => t.IsDelete == false && t.IsActive == true).Count(); ;
                dashboard.Total_Approval_Drivers = context.TabDrivers.Where(t => t.IsDelete == false && t.IsActive == true).Count();
                dashboard.Total_Blocked_Drivers = context.TabDrivers.Where(t => t.IsDelete == false && t.IsActive == false).Count();
                dashboard.Total_Drivers = context.TabDrivers.Where(t => t.IsDelete == false).Count(); ;
                dashboard.Total_Driver_Earnings = 125;
                dashboard.Total_Earnings = 2000;
                dashboard.Total_InActive_Users =  context.TabUser.Where(t => t.IsDelete == 0 && t.IsActive == false).Count(); 
                dashboard.Total_Deleted_Users = context.TabUser.Where(t => t.IsDelete ==  1).Count();
                dashboard.Total_Trips = userlist.Count();
                dashboard.Total_Turnover = 550;
                dashboard.Total_Users = context.TabUser.Where(t => t.IsDelete == 0).Count();

                dashboard.ZoneDash = new List<ZoneDash>();

                foreach (var zone in context.TabZone.Where(t => t.IsDeleted == 0 && t.IsActive == 1).ToList())
                {
                    ZoneDash zoneDash = new ZoneDash();
                    zoneDash.DriverCount = context.TabDrivers.Where(t => t.IsDelete == false && t.IsActive == true && t.Zoneid == zone.Zoneid).Count();
                    zoneDash.Total_Driver = context.TabDrivers.Where(t => t.IsDelete == false && t.IsActive == true).Count();
                    zoneDash.ZoneName = zone.Zonename;
                    dashboard.ZoneDash.Add(zoneDash);

                }
               


                return dashboard;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "UserList", context);
                return null;
            }
        }
    }
}
