using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Models;
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
        public bool AddRole(TaxiAppzDBContext context, Roles roles, LoggedInUser loggedInUser)
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
                Insertdata.CreatedBy = loggedInUser.Email;
                context.TabRoles.Add(Insertdata);
                context.SaveChanges();
                //need to add menu access while create the role
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "AddRole", context);
                return false;
            }
        }
        public bool EditRole(TaxiAppzDBContext context, long id, Roles roles, LoggedInUser loggedInUser)
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
                    updatedate.CreatedBy = loggedInUser.Email;
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
 
        
       
        
        public bool DeleteRole(TaxiAppzDBContext context, long id, LoggedInUser loggedInUser)
        {
            try
            {
               
                var updatedate = context.TabRoles.Where(r => r.Roleid == id).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.DeletedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    updatedate.DeletedBy = loggedInUser.Email;
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

        public bool DisableRole(TaxiAppzDBContext context, long id, LoggedInUser loggedInUser)
        {
            try
            {
                
                var updatedate = context.TabRoles.Where(r => r.Roleid == id).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    updatedate.UpdatedBy = loggedInUser.Email;
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
