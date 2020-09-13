using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Helper;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DAComplaint
    { 
        public List<ManageUserComplaint> ListUserComplaintTemplate(TaxiAppzDBContext context)
        {
            try
            {
                var complaintlist = context.TabUserComplaint.Where(t => t.IsDelete == false).ToList();
                List<ManageUserComplaint> manageUserlist = new List<ManageUserComplaint>();
                if (complaintlist.Count > 0)
                {
                    foreach (var complaint in complaintlist)
                    {
                        manageUserlist.Add(new ManageUserComplaint()
                        {
                            UserComplaintType = complaint.UserComplaintType,
                            UserComplaintTitle = complaint.UserComplaintTitle,
                            IsActive = complaint.IsActive
                        });
                    }
                    return manageUserlist;
                }
                return null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListUserComplaintTemplate", context);
                return null;
            }
        }
        public ManageUserComplaint UserComplainttemplateDtls(long complaintid, TaxiAppzDBContext content)
        {
            try
            {
                ManageUserComplaint manageUser = new ManageUserComplaint();
                var complaintdtls = content.TabUserComplaint.Where(t => t.UserComplaintId == complaintid).FirstOrDefault();
                if (complaintdtls != null)
                {
                    manageUser.UserCompalintID = complaintdtls.UserComplaintId;
                    manageUser.ZoneId = complaintdtls.Zoneid;
                    manageUser.UserComplaintType = complaintdtls.UserComplaintType;
                    manageUser.UserComplaintTitle = complaintdtls.UserComplaintTitle;
                    return manageUser;
                }
                return null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "UserComplainttemplateDtls", content);
                return null;
            }
        }

        public bool AddUserComplainttemplate(ManageUserComplaint manageUser, TaxiAppzDBContext content, LoggedInUser loggedInUser)
        {
            var zoneexist = content.TabZone.FirstOrDefault(t => t.IsDeleted == 0 && t.Zoneid == manageUser.ZoneId);
            if (zoneexist == null)
                throw new DataValidationException($"Zone does not exists");

            TabUserComplaint tabUserComplaint = new TabUserComplaint();
            tabUserComplaint.UserComplaintType = manageUser.UserComplaintType;
            tabUserComplaint.UserComplaintTitle = manageUser.UserComplaintTitle;
            tabUserComplaint.Zoneid = manageUser.ZoneId;
            tabUserComplaint.IsActive = true;
            tabUserComplaint.CreatedAt = DateTime.UtcNow;
            tabUserComplaint.CreatedBy = loggedInUser.UserName;
            content.TabUserComplaint.Add(tabUserComplaint);
            content.SaveChanges();
            return true;

        }
        public bool EditUserComplainttemplate(ManageUserComplaint manageUser, TaxiAppzDBContext content, LoggedInUser loggedInUser)
        {
            var zoneexist = content.TabUserComplaint.FirstOrDefault(t => t.IsDelete == false && t.UserComplaintId == manageUser.UserCompalintID);
            if (zoneexist == null)
                throw new DataValidationException($"User complaints does not exists");

            var userComplaintdtls = content.TabUserComplaint.Where(t => t.UserComplaintId == manageUser.UserCompalintID && t.IsDelete ==false).FirstOrDefault();
            userComplaintdtls.UserComplaintTitle = manageUser.UserComplaintTitle;
            userComplaintdtls.UserComplaintType = manageUser.UserComplaintType;
            userComplaintdtls.Zoneid = manageUser.ZoneId;          
            userComplaintdtls.UpdatedAt = DateTime.UtcNow;
            userComplaintdtls.UpdatedBy = loggedInUser.UserName;
            content.TabUserComplaint.Update(userComplaintdtls);
            content.SaveChanges();
            return true;

        }
        public bool IsActiveUserComplaintTemplate(long usercomplaintid, bool activestatus, TaxiAppzDBContext content, LoggedInUser loggedInUser)
        {
            var zoneexist = content.TabUserComplaint.FirstOrDefault(t => t.IsDelete == false && t.UserComplaintId == usercomplaintid);
            if (zoneexist != null)
                throw new DataValidationException($"User complaints does not exists");

            var userComplaint = content.TabUserComplaint.Where(t => t.UserComplaintId == usercomplaintid).FirstOrDefault();
            userComplaint.IsActive = activestatus;
            userComplaint.UpdatedAt = DateTime.UtcNow;
            userComplaint.UpdatedBy = loggedInUser.UserName;
            content.TabUserComplaint.Update(userComplaint);
            content.SaveChanges();
            return true;

        }
        public bool IsDeleteUserComplaintTemplate(long usercomplaintid, TaxiAppzDBContext content, LoggedInUser loggedInUser)
        {
            var zoneexist = content.TabUserComplaint.FirstOrDefault(t => t.IsDelete == false && t.UserComplaintId == usercomplaintid);
            if (zoneexist != null)
                throw new DataValidationException($"User complaints does not exists");

            var userComplaint = content.TabUserComplaint.Where(t => t.UserComplaintId == usercomplaintid).FirstOrDefault();
            userComplaint.IsDelete = true;
            userComplaint.DeletedAt = DateTime.UtcNow;
            userComplaint.DeletedBy = loggedInUser.UserName;
            content.TabUserComplaint.Update(userComplaint);
            content.SaveChanges();
            return true;

        }

        //Drivers Complaint Details
        public List<ManageDriverComplaint> ListDriverComplaintTemplate(TaxiAppzDBContext context)
        {
            try
            {
                var complaintlist = context.TabDriverComplaint.Where(t => t.IsDelete == false).ToList();
                List<ManageDriverComplaint> managedriverlist = new List<ManageDriverComplaint>();
               
                    foreach (var complaint in complaintlist)
                    {
                        managedriverlist.Add(new ManageDriverComplaint()
                        {
                            DriverComplaintType = complaint.DriverComplaintType,
                            DriverComplaintTitle = complaint.DriverComplaintTitle,
                            IsActive = complaint.IsActive
                        });
                    }
                    return managedriverlist;
               
           
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListDriverComplaintTemplate", context);
                return null;
            }
        }
        public ManageDriverComplaint DriverComplainttemplateDtls(long complaintid, TaxiAppzDBContext content)
        {
            try
            {
                ManageDriverComplaint managedriver = new ManageDriverComplaint();
                var complaintdtls = content.TabDriverComplaint.Where(t => t.DriverComplaintId == complaintid).FirstOrDefault();
                if (complaintdtls != null)
                {
                    managedriver.DriverCompalintID = complaintdtls.DriverComplaintId;
                    managedriver.ZoneId = complaintdtls.Zoneid;
                    managedriver.DriverComplaintType = complaintdtls.DriverComplaintType;
                    managedriver.DriverComplaintTitle = complaintdtls.DriverComplaintTitle;
                    return managedriver;
                }
                return null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "DriverComplainttemplateDtls", content);
                return null;
            }
        }

        public bool AddDriverComplainttemplate(ManageDriverComplaint manageDriver, TaxiAppzDBContext content, LoggedInUser loggedInUser)
        {
            var zoneexist = content.TabZone.FirstOrDefault(t => t.IsDeleted == 0 && t.Zoneid == manageDriver.ZoneId);
            if (zoneexist == null)
                throw new DataValidationException($"Zone does not exists");

            TabDriverComplaint tabDriverComplaint = new TabDriverComplaint();
            tabDriverComplaint.DriverComplaintType = manageDriver.DriverComplaintType;
            tabDriverComplaint.DriverComplaintTitle = manageDriver.DriverComplaintTitle;
            tabDriverComplaint.Zoneid = manageDriver.ZoneId;
            tabDriverComplaint.IsActive = true;
            tabDriverComplaint.CreatedAt = DateTime.UtcNow;
            tabDriverComplaint.CreatedBy = loggedInUser.UserName;
            content.TabDriverComplaint.Add(tabDriverComplaint);
            content.SaveChanges();
            return true;

        }
        public bool EditDriverComplainttemplate(ManageDriverComplaint manageDriver, TaxiAppzDBContext content, LoggedInUser loggedInUser)
        {
            var roleExist = content.TabDriverComplaint.FirstOrDefault(t => t.IsDelete == false && t.DriverComplaintId == manageDriver.DriverCompalintID);
            if (roleExist == null)
                throw new DataValidationException($"Driver comlaints does not exists");

            var zoneexist = content.TabZone.FirstOrDefault(t => t.IsDeleted == 0 && t.Zoneid == manageDriver.ZoneId);
            if (zoneexist != null)
                throw new DataValidationException($"Zone does not exists");

            var driverComplaintdtls = content.TabDriverComplaint.Where(t => t.DriverComplaintId == manageDriver.DriverCompalintID).FirstOrDefault();
            driverComplaintdtls.DriverComplaintTitle = manageDriver.DriverComplaintTitle;
            driverComplaintdtls.DriverComplaintType = manageDriver.DriverComplaintType;
            driverComplaintdtls.Zoneid = manageDriver.ZoneId;
            driverComplaintdtls.IsActive = true;
            driverComplaintdtls.UpdatedAt = DateTime.UtcNow;
            driverComplaintdtls.UpdatedBy = loggedInUser.UserName;
            content.TabDriverComplaint.Update(driverComplaintdtls);
            content.SaveChanges();
            return true;

        }
        public bool IsActiveDriverComplaintTemplate(long usercomplaintid, bool activestatus, TaxiAppzDBContext content, LoggedInUser loggedInUser)
        {
            var roleExist = content.TabDriverComplaint.FirstOrDefault(t => t.IsDelete == false && t.DriverComplaintId == usercomplaintid);
            if (roleExist != null)
                throw new DataValidationException($"Driver comlaints does not exists");

            var driverComplaintdtls = content.TabDriverComplaint.Where(t => t.DriverComplaintId == usercomplaintid).FirstOrDefault();
            driverComplaintdtls.IsActive = activestatus;
            driverComplaintdtls.UpdatedAt = DateTime.UtcNow;
            driverComplaintdtls.UpdatedBy = loggedInUser.UserName;
            content.TabDriverComplaint.Update(driverComplaintdtls);
            content.SaveChanges();
            return true;

        }
        public bool IsDeleteDriverComplaintTemplate(long usercomplaintid, TaxiAppzDBContext content, LoggedInUser loggedInUser)
        {
            var roleExist = content.TabDriverComplaint.FirstOrDefault(t => t.IsDelete == false && t.DriverComplaintId == usercomplaintid);
            if (roleExist != null)
                throw new DataValidationException($"Driver comlaints does not exists");

            var driverComplaintdtls = content.TabDriverComplaint.Where(t => t.DriverComplaintId == usercomplaintid).FirstOrDefault();
            driverComplaintdtls.IsDelete = true;
            driverComplaintdtls.DeletedAt = DateTime.UtcNow;
            driverComplaintdtls.DeletedBy = loggedInUser.UserName;
            content.TabDriverComplaint.Update(driverComplaintdtls);
            content.SaveChanges();
            return true;

        }
    }

}
