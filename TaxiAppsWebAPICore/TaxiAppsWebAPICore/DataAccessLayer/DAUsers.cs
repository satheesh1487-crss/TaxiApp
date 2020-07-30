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
                        Status = user.IsActive == 1 ? true : false,
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
                var userlist = context.TabUser.Where(u => u.IsActive == 0 && u.IsDelete == 0).ToList();
                foreach (var user in userlist)
                {
                    userListModel.Add(new UserList()
                    {
                        Name = user.Firstname + ' ' + user.Lastname,
                        Email = user.Email,
                        Phoneno = user.PhoneNumber,
                        Status = user.IsActive == 1 ? true : false,
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

        public UserListModel GetbyId(long userid, TaxiAppzDBContext context)
        {
            try
            {
                UserListModel userdtls = new UserListModel();
                var users = context.TabUser.Where(u => u.Id == userid && u.IsDelete == 0).FirstOrDefault();

                userdtls.Name = users.Firstname;
                userdtls.LastName = users.Lastname;
                userdtls.City = users.City;
                userdtls.State = users.State;
                userdtls.Gender = users.Gender;
                userdtls.Address = users.Address;
                userdtls.EMail = users.Email;
                userdtls.PhoneNo = users.PhoneNumber;
                userdtls.IsActive = users.IsActive == 1 ? true : false;

                return userdtls == null ? null : userdtls;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbyId", context);
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

        public bool Save(TaxiAppzDBContext context, UserInfoList userInfoList, LoggedInUser loggedInUser)
        {
            try
            {
               
                TabUser tabUser = new TabUser();
                tabUser.Address = userInfoList.Address;
                tabUser.City = userInfoList.City;
                tabUser.Countryid = userInfoList.Country;
                tabUser.Email = userInfoList.Email;
                tabUser.Firstname = userInfoList.Firstname;
                tabUser.Lastname = userInfoList.Lastname;
                tabUser.Password = userInfoList.Password;
                tabUser.PhoneNumber = userInfoList.Phonenumber;
                tabUser.ProfilePic = userInfoList.ProfilePicture;
                tabUser.State = userInfoList.State;
                tabUser.Timezoneid = userInfoList.TimeZone;
                tabUser.CreatedAt = tabUser.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                tabUser.CreatedBy = tabUser.UpdatedBy = "Admin";
                tabUser.IsDelete = 0;
                tabUser.IsActive = 1;
                context.Add(tabUser);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "Save", context);
                return false;
            }
        }

        public bool Edit(TaxiAppzDBContext context, UserInfoList userInfoList, LoggedInUser loggedInUser)
        {
            try
            {
                var tabUser = context.TabUser.Where(r => r.Id == userInfoList.Id && r.IsDelete == 0).FirstOrDefault();
                if (tabUser != null)
                {
                    tabUser.Address = userInfoList.Address;
                    tabUser.City = userInfoList.City;
                    tabUser.Countryid = userInfoList.Country;
                    tabUser.Email = userInfoList.Email;
                    tabUser.Firstname = userInfoList.Firstname;
                    tabUser.Lastname = userInfoList.Lastname;
                   // tabUser.Password = userInfoList.Password;
                    tabUser.PhoneNumber = userInfoList.Phonenumber;
                    tabUser.ProfilePic = userInfoList.ProfilePicture;
                    tabUser.State = userInfoList.State;
                    tabUser.Timezoneid = userInfoList.TimeZone;
                    tabUser.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    tabUser.UpdatedBy = "Admin";
                    context.Update(tabUser);
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
                    updatedate.IsActive = status == false ? 0 : 1;
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
