using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Helper;
using TaxiAppsWebAPICore.Models;
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
                var data = context.TabAdmin.Include(t=>t.TabAdminDetails).Where(t => t.Id == id && t.IsDeleted == 0).FirstOrDefault();
                if (data != null)
                {
                    adminInfo.Country = 0;             
                    adminInfo.Email = data.Email;
                    adminInfo.Emerphonenumber = data.EmergencyNumber;
                    adminInfo.Firstname = data.Firstname;
                    adminInfo.Languagename = data.Language;
                    adminInfo.Lastname = data.Lastname;
                    adminInfo.Password = data.Password;
                    adminInfo.Phonenumber = data.PhoneNumber;
                    adminInfo.RoleId = data.Role;              
                    
                }

                var tabAdmin = context.TabAdminDetails.Where(t => t.AdminId == id && t.IsDeleted == 0).FirstOrDefault();
                if (tabAdmin != null)
                {
                    adminInfo.Address = tabAdmin.Address;
                    adminInfo.Postalcode = tabAdmin.PostalCode;
                    adminInfo.Country = tabAdmin.CountryId;
                    adminInfo.Postalcode = tabAdmin.PostalCode;
                    adminInfo.DocumentName = tabAdmin.DocumentName;
                    
                }

                    return adminInfo != null ? adminInfo : null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbyId", context);
                return null;
            }
        }
        public bool Save(TaxiAppzDBContext context, AdminDetails adminDetails, LoggedInUser loggedInUser)
        {
            try
            {

                var emailid = context.TabAdmin.Where(t => t.Email.Contains(adminDetails.Email.ToLower()) && t.IsDeleted == 0).FirstOrDefault();
                if (emailid != null)
                    throw new DataValidationException($"user name with name '{adminDetails.Email}' already exists.");
                //if (context.TabAdmin.Any(t => t.Email.ToLowerInvariant() == adminDetails.Email.ToLowerInvariant() && t.IsDeleted == 0))
                //    throw new DataValidationException($"user name with name '{adminDetails.Email}' already exists.");

                TabAdmin tabAdmin = new TabAdmin();
                tabAdmin.AdminKey = "";
                tabAdmin.AdminReference = 0;
                tabAdmin.AreaName = adminDetails.Area;
                tabAdmin.Email = adminDetails.Email.ToLower();
                tabAdmin.EmergencyNumber = adminDetails.Emerphonenumber;
                tabAdmin.Firstname = adminDetails.Firstname;
                tabAdmin.Language = adminDetails.Languagename;
                tabAdmin.Lastname = adminDetails.Lastname;
                tabAdmin.Password = adminDetails.Password;
                tabAdmin.PhoneNumber = adminDetails.Phonenumber;
                tabAdmin.ProfilePic = adminDetails.ProfilePicture;
                tabAdmin.RegistrationCode = (context.TabAdmin.Count() + 1).ToString();
                tabAdmin.Role = adminDetails.RoleId;
                tabAdmin.IsActive = 1;
                tabAdmin.IsDeleted = 0;
                tabAdmin.CreatedAt = DateTime.UtcNow;
                tabAdmin.UpdatedAt = DateTime.UtcNow;
                tabAdmin.UpdatedBy = tabAdmin.CreatedBy = loggedInUser.Email;
                context.TabAdmin.Add(tabAdmin);
                context.SaveChanges();

                TabAdminDetails tabAdminDetails = new TabAdminDetails();

                tabAdminDetails.AdminId = tabAdmin.Id;
                tabAdminDetails.City = "";
                tabAdminDetails.Address = adminDetails.Address;
                tabAdminDetails.PostalCode = adminDetails.Postalcode;
              
                tabAdminDetails.CountryId = adminDetails.Country;
                tabAdminDetails.Timezone = adminDetails.TimeZone;

                context.TabAdminDetails.Add(tabAdminDetails);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "Save", context);
                return false;
            }
        }

        public bool Edit(TaxiAppzDBContext context, AdminDetails adminDetails, LoggedInUser loggedInUser)
        {
            try
            {
                //if (context.TabAdmin.Any(t => t.Email.ToLowerInvariant() == adminDetails.Email.ToLowerInvariant() && t.IsDeleted == 0 && t.Id != adminDetails.Id))
                //  throw new DataValidationException($"user name with name '{adminDetails.Email}' already exists.");

                var tabAdmin = context.TabAdmin.Include(t=>t.TabAdminDetails).Where(r => r.Id == adminDetails.Id && r.IsDeleted == 0).FirstOrDefault();
                if (tabAdmin != null)
                {                   
                    tabAdmin.AreaName = adminDetails.Area;
                    tabAdmin.Email = adminDetails.Email;
                    tabAdmin.EmergencyNumber = adminDetails.Emerphonenumber;
                    tabAdmin.Firstname = adminDetails.Firstname;
                    tabAdmin.Language = adminDetails.Languagename;
                    tabAdmin.Lastname = adminDetails.Lastname;                  
                    tabAdmin.PhoneNumber = adminDetails.Phonenumber;
                    tabAdmin.ProfilePic = adminDetails.ProfilePicture;
                    tabAdmin.Role = adminDetails.RoleId;

                    tabAdmin.UpdatedAt = DateTime.UtcNow;
                    tabAdmin.UpdatedBy = loggedInUser.Email;
                    context.TabAdmin.Update(tabAdmin);
                    context.SaveChanges();

                }else
                {
                    TabAdmin tab = new TabAdmin();

                    tab.AreaName = adminDetails.Area;
                    tab.Email = adminDetails.Email;
                    tab.EmergencyNumber = adminDetails.Emerphonenumber;
                    tab.Firstname = adminDetails.Firstname;
                    tab.Language = adminDetails.Languagename;
                    tab.Lastname = adminDetails.Lastname;
                    tab.Password = adminDetails.Password;
                    tab.PhoneNumber = adminDetails.Phonenumber;
                    tab.ProfilePic = adminDetails.ProfilePicture;
                    tab.Role = adminDetails.RoleId;
                    tab.UpdatedAt = DateTime.UtcNow;
                    tab.UpdatedBy = loggedInUser.Email;
                    context.TabAdmin.Add(tab);
                    context.SaveChanges();
                }

                var tabAdmindetails = context.TabAdminDetails.Where(r => r.AdminId == adminDetails.Id && r.IsDeleted == 0).FirstOrDefault();
                if (tabAdmindetails != null)
                {
                    tabAdmindetails.AdminId = tabAdmin.Id;
                    tabAdmindetails.City = "";
                    tabAdmindetails.Address = adminDetails.Address;
                    tabAdmindetails.PostalCode =adminDetails.Postalcode;
                    tabAdmindetails.CountryId = adminDetails.Country;
                    tabAdmindetails.Timezone = adminDetails.TimeZone;
                    tabAdmindetails.UpdatedAt = DateTime.UtcNow;
                    tabAdmindetails.UpdatedBy = loggedInUser.Email;
                    context.TabAdminDetails.Update(tabAdmindetails);
                    context.SaveChanges();                   
                }else
                {
                    TabAdminDetails details = new TabAdminDetails();
                    details.AdminId = tabAdmin.Id;
                    details.City = "";
                    details.Address = adminDetails.Address;
                    details.PostalCode = adminDetails.Postalcode;
                    details.CountryId = adminDetails.Country;
                    details.Timezone = adminDetails.TimeZone;
                    details.UpdatedAt = DateTime.UtcNow;
                    details.UpdatedBy = loggedInUser.Email;
                    context.TabAdminDetails.Add(details);
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
        public bool Delete(TaxiAppzDBContext context, long id, LoggedInUser loggedInUser)
        {
            try
            {
                var tabAdmin = context.TabAdmin.Where(r => r.Id == id && r.IsDeleted == 0).FirstOrDefault();
                if (tabAdmin != null)
                {
                    tabAdmin.IsDeleted = 1;
                    tabAdmin.DeletedAt = DateTime.UtcNow;
                    tabAdmin.DeletedBy = loggedInUser.Email;
                    context.TabAdmin.Update(tabAdmin);
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
        public bool Status(TaxiAppzDBContext context, long id, bool status, LoggedInUser loggedInUser)
        {
            try
            {
                var tabAdmin = context.TabAdmin.Where(r => r.Id == id && r.IsDeleted == 0).FirstOrDefault();
                if (tabAdmin != null)
                {
                    tabAdmin.IsActive = status == true ? 1 : 0;
                    tabAdmin.UpdatedAt = DateTime.UtcNow;
                    tabAdmin.UpdatedBy = loggedInUser.Email;
                    context.Update(tabAdmin);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "Status", context);
                return false;
            }
        }

        public bool EditPassword(TaxiAppzDBContext context, AdminPassword adminPassword, LoggedInUser loggedInUser)
        {
            try
            {

                var emailid = context.TabAdmin.Where(t => t.Id == adminPassword.Id && t.IsDeleted == 0).FirstOrDefault();
                if (emailid == null)
                    throw new DataValidationException($"This user does not exists.");
                //if (context.TabAdmin.Any(t => t.Email.ToLowerInvariant() == adminDetails.Email.ToLowerInvariant() && t.IsDeleted == 0))
                //    throw new DataValidationException($"user name with name '{adminDetails.Email}' already exists.");

                emailid.Password = adminPassword.Password;
                emailid.UpdatedAt = DateTime.UtcNow;
                emailid.UpdatedBy = loggedInUser.Email;
                context.TabAdmin.Update(emailid);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "EditPassword", context);
                return false;
            }
        }
    }
}
