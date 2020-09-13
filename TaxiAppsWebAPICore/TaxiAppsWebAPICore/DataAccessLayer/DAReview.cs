using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DAReview
    {
        public List<UsertoDriver> ListUserRating(TaxiAppzDBContext context)
        {
            try
            {
                List<UsertoDriver> usertoDrivers = new List<UsertoDriver>();
                var userList = context.TabRequestRating.Include(t => t.User).Include(t => t.Driver).ToList();
                foreach (var user in userList)
                {
                    usertoDrivers.Add(new UsertoDriver()
                    {
                        Id = user.RatingId,
                        Comment = user.Comments,
                        DriverName = user.Driver == null ? "" : user.Driver.FirstName + ' ' + user.Driver.LastName,
                        UserName = user.User.Firstname + ' ' + user.User.Lastname,
                        Rating = user.UserRating,
                        RequestID = user.RequestId
                    });
                }
                return usertoDrivers;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListUserRating", context);
                return null;
            }
        }
        public List<DrivertoUser> ListDriverRating(TaxiAppzDBContext context)
        {
            try
            {
                List<DrivertoUser> drivertoUsers = new List<DrivertoUser>();
                var driverList = context.TabRequestRating.Include(t => t.User).Include(t => t.Driver).ToList();
                foreach (var driver in driverList)
                {
                    drivertoUsers.Add(new DrivertoUser()
                    {
                        Id = driver.RatingId,
                        Comment = driver.Comments,
                        DriverName = driver.Driver == null ? "" : driver.Driver.FirstName + ' ' + driver.Driver.LastName,
                        UserName = driver.User.Firstname + ' ' + driver.User.Lastname,
                        Rating = driver.UserRating,
                        RequestID = driver.RequestId
                    });
                }
                return drivertoUsers;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListDriverRating", context);
                return null;
            }
        }
    }
}
