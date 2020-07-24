using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore 
{
    public class DARoles
    {
        public List<Roles> GetRoleList(TaxiAppzDBContext context)
        {
            try
            {
                List<Roles> rolelist = new List<Roles>();
                var listroles = context.TabRoles.ToList();
                foreach (var role in listroles)
                {
                    rolelist.Add(new Roles()
                    {
                        RoleID = role.Roleid,
                        RoleName = role.RoleName,
                        DisplayName = role.DisplayName,
                        Description = role.Description,
                        IsActive = role.IsActive.ToString()
                    });
                }
                return rolelist != null ? rolelist : null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetRoleList", context);
                return null;
            }
        }
        public Roles GetRoleDtls(TaxiAppzDBContext context, long id)
        {
            try
            {
                Roles _role = new Roles();
                var roleresult = context.TabRoles.Where(r => r.Roleid == id).FirstOrDefault();
                if (roleresult != null)
                {
                    _role.RoleID = roleresult.Roleid;
                    _role.RoleName = roleresult.RoleName;
                    _role.DisplayName = roleresult.DisplayName;
                    _role.Description = roleresult.Description;
                    _role.IsActive = roleresult.IsActive.ToString();
                    return _role;
                }
                _role.Status = "No Data Found";
                return _role;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetRoleDtls", context);
                return null;
            }
        }
        public bool AddRole(TaxiAppzDBContext context, Roles roles)
        {
            try
            {
                TabRoles Insertdata = new TabRoles();
                Insertdata.RoleName = roles.RoleName;
                Insertdata.DisplayName = roles.DisplayName;
                Insertdata.Description = roles.Description;
                Insertdata.IsActive = 1;
                Insertdata.AllRights = 1;
                Insertdata.Locked = 1;
                Insertdata.CreatedBy = "Admin";
                context.TabRoles.Add(Insertdata);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "AddRole", context);
                return false;
            }
        }
        public bool EditRole(TaxiAppzDBContext context, long id, Roles roles)
        {
            try
            {
                TabRoles Insertdata = new TabRoles();
                var updatedate = context.TabRoles.Where(r => r.Roleid == id).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.RoleName = roles.RoleName;
                    updatedate.DisplayName = roles.DisplayName;
                    updatedate.Description = roles.Description;
                    updatedate.IsActive = roles.IsActive.ToUpper() == "INACTIVE" ? 0 : 1;
                    updatedate.AllRights = 1;
                    updatedate.Locked = 1;
                    updatedate.CreatedBy = "Admin";
                    updatedate.UpdatedAt = DateTime.Now;
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "EditRole", context);
                return false;
            }
        }

        public List<AdminList> GetAdminList(TaxiAppzDBContext context)
        {
            try
            {
                List<AdminList> adminLists = new List<AdminList>();
                var admindata = context.TabAdmin.Include(l => l.LanguageNavigation).Include(r => r.RoleNavigation).
                    Include(z => z.ZoneAccessNavigation).ToList();
                foreach (var admin in admindata)
                {
                    adminLists.Add(new AdminList()
                    {
                        AdminID = admin.Id,
                        RegistrationCode = admin.RegistrationCode,
                        FirstName = admin.Firstname,
                        LastName = admin.Lastname,
                        ContactNo = admin.PhoneNumber,
                        AreaName = admin.AreaName,
                        EmergencyContactNo = admin.EmergencyNumber,
                        IsActive = admin.IsActive.ToString(),
                        Roles = new Roles()
                        {
                            RoleID = admin.RoleNavigation.Roleid,
                            RoleName = admin.RoleNavigation.RoleName,
                            DisplayName = admin.RoleNavigation.DisplayName
                        },
                        Language = new Language()
                        {
                            LanguageID = admin.LanguageNavigation.Languageid,
                            LongName = admin.LanguageNavigation.Name,
                            ShortName = admin.LanguageNavigation.ShortLang
                        },
                        Country = new Country()
                        {
                            CountryID = admin.ZoneAccessNavigation.CountryId,
                            Name = admin.ZoneAccessNavigation.Name
                        }

                    });
                }
                return adminLists != null ? adminLists : null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetAdminList", context);
                return null;

            }
        }

        public AdminList GetAdminDetails(long roleid, TaxiAppzDBContext context)
        {
            try
            {
                AdminList admindetails = new AdminList();
                var admindata = context.TabAdmin.Include(l => l.LanguageNavigation).Include(r => r.RoleNavigation).
                    Include(z => z.ZoneAccessNavigation).Where(i => i.Id == roleid).FirstOrDefault();
                var timezone = context.TabTimezone.Where(t => t.Timezoneid == admindata.ZoneAccess1.Timezoneid).FirstOrDefault();
                var admindtls = context.TabAdminDetails.Where(d => d.AdminId == roleid).FirstOrDefault();
                admindetails.RegistrationCode = admindata.RegistrationCode;
                admindetails.FirstName = admindata.Firstname;
                admindetails.LastName = admindata.Lastname;
                // admindetails.EmailID = admindata.Email;
                admindetails.ContactNo = admindata.PhoneNumber;
                admindetails.AreaName = admindata.AreaName;
                admindetails.EmergencyContactNo = admindata.EmergencyNumber;
                admindetails.IsActive = admindata.IsActive.ToString();
                admindetails.Roles = new Roles()
                {
                    RoleID = admindata.RoleNavigation.Roleid,
                    RoleName = admindata.RoleNavigation.RoleName,
                    DisplayName = admindata.RoleNavigation.DisplayName
                };
                admindetails.Language = new Language()
                {
                    LanguageID = admindata.LanguageNavigation.Languageid,
                    LongName = admindata.LanguageNavigation.Name,
                    ShortName = admindata.LanguageNavigation.ShortLang
                };
                admindetails.Country = new Country()
                {
                    CountryID = admindata.ZoneAccessNavigation.CountryId,
                    Name = admindata.ZoneAccessNavigation.Name
                };
                admindetails.Timezones = new Timezone()
                {
                    TimeZoneid = admindata.ZoneAccess1.Timezoneid,
                    TimeZoneDescription = admindata.ZoneAccess1.Zonedescription
                };
                admindetails.AdminDetails = new AdminDetails()
                {
                    Address = admindtls.Address,
                    City = admindtls.City,
                    PostalCode = admindtls.PostalCode,
                    DocumentName = admindtls.Document,
                    Document = admindtls.Document,
                    DriverDocumentCount = admindtls.DriverDocumentCount,
                    IsActive = admindtls.IsActive.ToString()
                };
                return admindetails != null ? admindetails : null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetAdminDetails", context);
                return null;
            }
        }

        public bool EditAdminDetails(TaxiAppzDBContext context, AdminList adminList)
        {
            try
            {

                TabAdmin admin = new TabAdmin();
                var fetchadmin = context.TabAdmin.Where(a => a.Id == adminList.AdminID).FirstOrDefault();
                fetchadmin.Firstname = adminList.FirstName;
                fetchadmin.Lastname = adminList.LastName;
                //  admin.RegistrationCode = adminList.RegistrationCode;  // need to check for format with nPlus team
                fetchadmin.Email = adminList.EmailID;
                fetchadmin.PhoneNumber = adminList.ContactNo;
                fetchadmin.EmergencyNumber = adminList.EmergencyContactNo;
                fetchadmin.Language = Convert.ToInt32(adminList.Language.LanguageID); // need to pass only id
                 fetchadmin.ZoneAccess = Convert.ToInt32(adminList.Timezones.TimeZoneid); // need to pass only id 
                fetchadmin.Role = Convert.ToInt32(adminList.Role);
                //  admin.ProfilePic = adminList.ProfilePic;
                fetchadmin.AreaName = adminList.AreaName;
                fetchadmin.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                fetchadmin.IsActive = 1;
                context.Update(fetchadmin);
                context.SaveChanges();
                TabAdminDetails adminDetails = new TabAdminDetails();
                var admindetails = context.TabAdminDetails.Where(ad => ad.AdminId == adminList.AdminID).FirstOrDefault();
                admindetails.AdminId = adminDetails.AdminId;
                admindetails.Address = adminList.AdminDetails.Address;
                admindetails.PostalCode = adminList.AdminDetails.PostalCode;
                admindetails.CountryId = adminList.Country.CountryID;
                adminDetails.Timezone = adminList.Country.TimeZone;
                //   adminDetails.Document = adminList.AdminDetails.DocumentName;
                adminDetails.DocumentName = adminList.AdminDetails.DocumentName;
               // adminDetails.DriverDocumentCount = adminList.AdminDetails.DriverDocumentCount;
               adminDetails.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                adminDetails.IsActive = 1;
                context.Update(adminDetails);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "SaveAdminDetails", context);
                return false;
            }
        }

        public bool AddAdminDetails(TaxiAppzDBContext context, AdminList adminList)
        {
            try
            {
                TabAdmin admin = new TabAdmin();
                admin.Firstname = adminList.FirstName;
                admin.Lastname = adminList.LastName;
                //  admin.RegistrationCode = adminList.RegistrationCode;  // need to check for format with nPlus team
                admin.Email = adminList.EmailID;
                admin.PhoneNumber = adminList.ContactNo;
                admin.EmergencyNumber = adminList.EmergencyContactNo;
                admin.Language = Convert.ToInt32(adminList.Language.LanguageID); // need to pass only id
                admin.ZoneAccess = Convert.ToInt32(adminList.Timezones.TimeZoneid); // need to pass only id 
                admin.Role = Convert.ToInt32(adminList.Role);
                //  admin.ProfilePic = adminList.ProfilePic;
                admin.AreaName = adminList.AreaName;
                admin.CreatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                admin.IsActive = 1;
                context.TabAdmin.Add(admin);
                context.SaveChanges();
                long adminid = admin.Id;
                TabAdminDetails adminDetails = new TabAdminDetails();

                adminDetails.AdminId = adminid;
                adminDetails.Address = adminList.AdminDetails.Address;
                adminDetails.PostalCode = adminList.AdminDetails.PostalCode;
                adminDetails.CountryId = adminList.Country.CountryID;
                adminDetails.Timezone = adminList.Country.TimeZone;
                //   adminDetails.Document = adminList.AdminDetails.DocumentName;
                adminDetails.DocumentName = adminList.AdminDetails.DocumentName;
                adminDetails.DriverDocumentCount = adminList.AdminDetails.DriverDocumentCount;
                adminDetails.CreatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                adminDetails.IsActive = 1;
                context.Update(adminDetails);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "SaveAdminDetails", context);
                return false;
            }
        }

        public bool DeleteRole(TaxiAppzDBContext context, long id)
        {
            try
            {
               
                var updatedate = context.TabRoles.Where(r => r.Roleid == id).FirstOrDefault();
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
                Extention.insertlog(ex.Message, "Admin", "DeleteRole", context);
                return false;
            }
        }

        public bool DisableRole(TaxiAppzDBContext context, long id)
        {
            try
            {
                
                var updatedate = context.TabRoles.Where(r => r.Roleid == id).FirstOrDefault();
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
                Extention.insertlog(ex.Message, "Admin", "DisableRole", context);
                return false;
            }
        }
    }
}
