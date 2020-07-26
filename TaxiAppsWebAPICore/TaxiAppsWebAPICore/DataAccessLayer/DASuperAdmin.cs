﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore
{
    public class DASuperAdmin
    {
        public List<AdminList> List(TaxiAppzDBContext context)
        {
            try
            {
                List<AdminList> addAdminList = new List<AdminList>();
                var addAdmin = context.TabAdmin.Where(t => t.IsDeleted == 0).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var admin in addAdmin)
                {
                    addAdminList.Add(new AdminList()
                    {
                        Email = admin.Email,
                        Id = admin.Id,
                        Name = admin.Firstname + ' ' + admin.Lastname,
                        Role = admin.Role.ToString(),
                        Operations = "",
                        Phoneno = admin.PhoneNumber,
                        Rgcode = admin.RegistrationCode,
                        Status = admin.IsActive == 1 ? true : false
                    });
                }
                return addAdminList;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "List", context);
                return null;
            }
        }

        public AdminDetails GetbyId(long id, TaxiAppzDBContext context)
        {
            try
            {
                AdminDetails adminInfo = new AdminDetails();
                var data = context.TabAdmin.FirstOrDefault(t => t.Id == id && t.IsDeleted == 0);
                if (data != null)
                {
                    adminInfo.Address = "";
                    adminInfo.Country = "";
                    adminInfo.Document = "";
                    adminInfo.DocumentName = "";
                    adminInfo.Email = data.Email;
                    adminInfo.Emerphonenumber = data.EmergencyNumber;
                    adminInfo.Firstname = data.Firstname;
                    adminInfo.Languagename = data.Language;
                    adminInfo.Lastname = data.Lastname;
                    adminInfo.Password = data.Password;
                    adminInfo.Phonenumber = data.PhoneNumber;
                    adminInfo.Postalcode = "";
                    adminInfo.ProfilePicture = "";
                    adminInfo.Rolename = data.Role;
                    adminInfo.TimeZone = data.ZoneAccess;
                    adminInfo.Userlogin = data.Email;

                }

                return adminInfo != null ? adminInfo : null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbyId", context);
                return null;
            }
        }
        public bool Save(TaxiAppzDBContext context, AdminDetails adminDetails)
        {
            try
            {
                TabAdmin tabAdmin = new TabAdmin();
                tabAdmin.AdminKey = "";
                tabAdmin.AdminReference = 0;
                tabAdmin.AreaName = adminDetails.Area.ToString();
                tabAdmin.Email = adminDetails.Email;
                tabAdmin.EmergencyNumber = adminDetails.Emerphonenumber;
                tabAdmin.Firstname = adminDetails.Firstname;
                tabAdmin.Language = adminDetails.Languagename;
                tabAdmin.Lastname = adminDetails.Lastname;
                tabAdmin.Password = adminDetails.Password;
                tabAdmin.PhoneNumber = adminDetails.Phonenumber;
                tabAdmin.ProfilePic = adminDetails.ProfilePicture;
                tabAdmin.RegistrationCode = (context.TabAdmin.Count() + 1).ToString();
                tabAdmin.Role = adminDetails.Rolename;
                tabAdmin.ZoneAccess = adminDetails.TimeZone;
                tabAdmin.IsActive = 1;
                tabAdmin.IsDeleted = 0;
                tabAdmin.CreatedAt = DateTime.UtcNow;
                tabAdmin.UpdatedAt = DateTime.UtcNow;
                tabAdmin.CreatedBy = "admin";
                tabAdmin.UpdatedBy = "admin";
                context.TabAdmin.Add(tabAdmin);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "Save", context);
                return false;
            }
        }

        public bool Edit(TaxiAppzDBContext context, AdminDetails adminDetails)
        {
            try
            {
                var tabAdmin = context.TabAdmin.Where(r => r.Id == adminDetails.Id && r.IsDeleted == 0).FirstOrDefault();
                if (tabAdmin != null)
                {
                    tabAdmin.AdminKey = "";
                    tabAdmin.AdminReference = 0;
                    tabAdmin.AreaName = adminDetails.Area.ToString();
                    tabAdmin.Email = adminDetails.Email;
                    tabAdmin.EmergencyNumber = adminDetails.Emerphonenumber;
                    tabAdmin.Firstname = adminDetails.Firstname;
                    tabAdmin.Language = adminDetails.Languagename;
                    tabAdmin.Lastname = adminDetails.Lastname;
                    tabAdmin.Password = adminDetails.Password;
                    tabAdmin.PhoneNumber = adminDetails.Phonenumber;
                    tabAdmin.ProfilePic = adminDetails.ProfilePicture;
                    tabAdmin.Role = adminDetails.Rolename;
                    tabAdmin.ZoneAccess = adminDetails.TimeZone;
                    tabAdmin.UpdatedAt = DateTime.UtcNow;
                    tabAdmin.UpdatedBy = "admin";
                    context.TabAdmin.Add(tabAdmin);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "Edit", context);
                return false;
            }
        }
        public bool Delete(TaxiAppzDBContext context, long id)
        {
            try
            {
                var tabAdmin = context.TabAdmin.Where(r => r.Id == id && r.IsDeleted == 0).FirstOrDefault();
                if (tabAdmin != null)
                {
                    tabAdmin.IsDeleted = 1;
                    tabAdmin.DeletedAt = DateTime.UtcNow;
                    tabAdmin.DeletedBy = "admin";
                    context.TabAdmin.Add(tabAdmin);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "Delete", context);
                return false;
            }
        }
        public bool Status(TaxiAppzDBContext context, long id, bool status)
        {
            try
            {
                var tabAdmin = context.TabAdmin.Where(r => r.Id == id && r.IsDeleted == 0).FirstOrDefault();
                if (tabAdmin != null)
                {
                    tabAdmin.IsActive = status == true ? 1 : 0;
                    tabAdmin.UpdatedAt = DateTime.UtcNow;
                    tabAdmin.UpdatedBy = "admin";
                    context.TabAdmin.Add(tabAdmin);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "Status", context);
                return false;
            }
        }
    }
}