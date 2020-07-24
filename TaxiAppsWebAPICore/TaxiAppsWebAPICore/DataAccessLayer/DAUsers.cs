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
        public List<UserListModel> GetUserList(TaxiAppzDBContext context)
        {
            try
            {
                List<UserListModel> userListModel = new List<UserListModel>();
                var userlist = context.TabUser.ToList();
                foreach (var user in userlist)
                {
                    userListModel.Add(new UserListModel()
                    {
                        Name = user.Firstname + ' ' + user.Lastname,
                        EMail = user.Email,
                        PhoneNo = user.PhoneNumber,
                        IsActive = user.IsActive == 0 ? true : false,
                        UserID = user.Id
                    });
                }
                return userListModel == null ? null : userListModel;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetUserList", context);
                return null;
            }
        }
        public List<UserListModel> GetBlockedUserList(TaxiAppzDBContext context)
        {
            try
            {
                List<UserListModel> userListModel = new List<UserListModel>();
                var userlist = context.TabUser.Where(u => u.IsActive == 1).ToList();
                foreach (var user in userlist)
                {
                    userListModel.Add(new UserListModel()
                    {
                        Name = user.Firstname + ' ' + user.Lastname,
                        EMail = user.Email,
                        PhoneNo = user.PhoneNumber,
                        IsActive = user.IsActive == 0 ? true : false,
                        UserID = user.Id
                    });
                }
                return userListModel == null ? null : userListModel;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetBlockedUserList", context);
                return null;
            }
        }
        
        public  UserListModel  GetUserEdit(long userid,TaxiAppzDBContext context)
        {
            try
            {
                UserListModel userdtls = new UserListModel();
                var users = context.TabUser.Where(u => u.Id == userid).FirstOrDefault();

                userdtls.Name = users.Firstname;
                userdtls.LastName = users.Lastname;
                users.City = users.City;
                users.State = users.State;
                users.Gender = users.Gender;
                users.Address = users.Address;
                userdtls.EMail = users.Email;
                userdtls.PhoneNo = users.PhoneNumber;
                userdtls.IsActive = users.IsActive == 0 ? true : false;

                return userdtls == null ? null : userdtls;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetBlockedUserList", context);
                return null;
            }
           
        }
        public bool DeleteUser(TaxiAppzDBContext context, long id)
        {
            try
            {
              var updatedate = context.TabUser.Where(u => u.Id == id).FirstOrDefault();
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
                Extention.insertlog(ex.Message, "Admin", "DeleteUser", context);
                return false;
            }
        }

        public bool DisableUser(TaxiAppzDBContext context, long id)
        {
            try
            {
               
                var updatedate = context.TabUser.Where(u => u.Id == id).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    updatedate.UpdatedBy = "Admin";
                    updatedate.IsActive = 1;
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
