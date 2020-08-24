using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore
{
    public class DAUsers
    {
        public List<UserList> List(TaxiAppzDBContext context)
        {
            try
            {
                List<UserList> userListModel = new List<UserList>();
                var userlist = context.TabUser.Where(t => t.IsDelete == 0).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var user in userlist)
                {
                    userListModel.Add(new UserList()
                    {
                        Name = user.Firstname + ' ' + user.Lastname,
                        Email = user.Email,
                        Phoneno = user.PhoneNumber,
                        Status = user.IsActive,
                        Id = user.Id
                    });
                }
                return userListModel == null ? null : userListModel;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "List", context);
                return null;
            }
        }
        public List<UserList> BlockedList(TaxiAppzDBContext context)
        {
            try
            {
                List<UserList> userListModel = new List<UserList>();
                var userlist = context.TabUser.Where(u => u.IsActive == true && u.IsDelete == 0).ToList();
                foreach (var user in userlist)
                {
                    userListModel.Add(new UserList()
                    {
                        Name = user.Firstname + ' ' + user.Lastname,
                        Email = user.Email,
                        Phoneno = user.PhoneNumber,
                        Status = user.IsActive,
                        Id = user.Id
                    });
                }
                return userListModel == null ? null : userListModel;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "BlockedList", context);
                return null;
            }
        }

        
        public bool Delete(TaxiAppzDBContext context, long id, LoggedInUser loggedInUser)
        {
            try
            {
                var updatedate = context.TabUser.Where(u => u.Id == id && u.IsDelete == 0).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.DeletedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    updatedate.DeletedBy = "Admin";
                    updatedate.IsDelete = 1;
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "Delete", context);
                return false;
            }
        }

        
        public bool DisableUser(TaxiAppzDBContext context, long id, bool status, LoggedInUser loggedInUser)
        {
            try
            {

                var updatedate = context.TabUser.Where(u => u.Id == id && u.IsDelete == 0).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    updatedate.UpdatedBy = "Admin";
                    updatedate.IsActive = status;
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "DisableUser", context);
                return false;
            }
        }

    }
}
