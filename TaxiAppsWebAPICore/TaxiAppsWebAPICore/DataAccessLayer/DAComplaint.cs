using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DAComplaint
    {
        // User Complaint Details
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
            catch(Exception ex)
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

        public bool AddUserComplainttemplate(ManageUserComplaint manageUser, TaxiAppzDBContext content)
        {
            try
            {
                TabUserComplaint tabUserComplaint = new TabUserComplaint();
                tabUserComplaint.UserComplaintType = manageUser.UserComplaintType;
                tabUserComplaint.UserComplaintTitle = manageUser.UserComplaintTitle;
                tabUserComplaint.Zoneid = manageUser.ZoneId;
                tabUserComplaint.IsActive = true;
                tabUserComplaint.CreatedAt = DateTime.UtcNow;
                tabUserComplaint.CreatedBy = "Admin";
                content.TabUserComplaint.Add(tabUserComplaint);
                content.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "AddUserComplainttemplate", content);
                return false;
            }
        }
        public bool EditUserComplainttemplate(ManageUserComplaint manageUser, TaxiAppzDBContext content)
        {
            try
            {
                var userComplaintdtls = content.TabUserComplaint.Where(t => t.UserComplaintId == manageUser.UserCompalintID).FirstOrDefault();
                userComplaintdtls.UserComplaintTitle = manageUser.UserComplaintTitle;
                userComplaintdtls.UserComplaintType = manageUser.UserComplaintType;
                userComplaintdtls.Zoneid = manageUser.ZoneId;
                userComplaintdtls.IsActive = true;
                userComplaintdtls.UpdatedAt = DateTime.UtcNow;
                userComplaintdtls.UpdatedBy = "Admin";
                content.TabUserComplaint.Update(userComplaintdtls);
                content.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "EditUserComplainttemplate", content);
                return false;
            }
        }
        public bool IsActiveUserComplaintTemplate(long usercomplaintid, bool activestatus, TaxiAppzDBContext content)
        {
            try
            {
                var userComplaint = content.TabUserComplaint.Where(t => t.UserComplaintId == usercomplaintid).FirstOrDefault();
                userComplaint.IsActive = activestatus;
                userComplaint.UpdatedAt = DateTime.UtcNow;
                userComplaint.UpdatedBy = "Admin";
                content.TabUserComplaint.Update(userComplaint);
                content.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "IsActiveUserComplaintTemplate", content);
                return false;
            }
        }
        public bool IsDeleteUserComplaintTemplate(long usercomplaintid, TaxiAppzDBContext content)
        {
            try
            {
                var userComplaint = content.TabUserComplaint.Where(t => t.UserComplaintId == usercomplaintid).FirstOrDefault();
                userComplaint.IsDelete = true;
                userComplaint.DeletedAt = DateTime.UtcNow;
                userComplaint.DeletedBy = "Admin";
                content.TabUserComplaint.Update(userComplaint);
                content.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "IsDeleteUserComplaintTemplate", content);
                return false;
            }
        }

        //Drivers Complaint Details
        public List<ManageDriverComplaint> ListDriverComplaintTemplate(TaxiAppzDBContext context)
        {
            try
            {
                var complaintlist = context.TabDriverComplaint.Where(t => t.IsDelete == false).ToList();
                List<ManageDriverComplaint> managedriverlist = new List<ManageDriverComplaint>();
                if (complaintlist.Count > 0)
                {
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
                return null;
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

        public bool AddDriverComplainttemplate(ManageDriverComplaint manageDriver, TaxiAppzDBContext content)
        {
            try
            {
                TabDriverComplaint tabDriverComplaint = new TabDriverComplaint();
                tabDriverComplaint.DriverComplaintType = manageDriver.DriverComplaintType;
                tabDriverComplaint.DriverComplaintTitle = manageDriver.DriverComplaintTitle;
                tabDriverComplaint.Zoneid = manageDriver.ZoneId;
                tabDriverComplaint.IsActive = true;
                tabDriverComplaint.CreatedAt = DateTime.UtcNow;
                tabDriverComplaint.CreatedBy = "Admin";
                content.TabDriverComplaint.Add(tabDriverComplaint);
                content.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "AddDriverComplainttemplate", content);
                return false;
            }
        }
        public bool EditDriverComplainttemplate(ManageDriverComplaint manageDriver, TaxiAppzDBContext content)
        {
            try
            {
                var driverComplaintdtls = content.TabDriverComplaint.Where(t => t.DriverComplaintId == manageDriver.DriverCompalintID).FirstOrDefault();
                driverComplaintdtls.DriverComplaintTitle = manageDriver.DriverComplaintTitle;
                driverComplaintdtls.DriverComplaintType = manageDriver.DriverComplaintType;
                driverComplaintdtls.Zoneid = manageDriver.ZoneId;
                driverComplaintdtls.IsActive = true;
                driverComplaintdtls.UpdatedAt = DateTime.UtcNow;
                driverComplaintdtls.UpdatedBy = "Admin";
                content.TabDriverComplaint.Update(driverComplaintdtls);
                content.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "EditDriverComplainttemplate", content);
                return false;
            }
        }
        public bool IsActiveDriverComplaintTemplate(long usercomplaintid, bool activestatus, TaxiAppzDBContext content)
        {
            try
            {
                var driverComplaintdtls = content.TabDriverComplaint.Where(t => t.DriverComplaintId == usercomplaintid).FirstOrDefault();
                driverComplaintdtls.IsActive = activestatus;
                driverComplaintdtls.UpdatedAt = DateTime.UtcNow;
                driverComplaintdtls.UpdatedBy = "Admin";
                content.TabDriverComplaint.Update(driverComplaintdtls);
                content.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "IsActiveDriverComplaintTemplate", content);
                return false;
            }
        }
        public bool IsDeleteDriverComplaintTemplate(long usercomplaintid, TaxiAppzDBContext content)
        {
            try
            {
                var driverComplaintdtls = content.TabDriverComplaint.Where(t => t.DriverComplaintId == usercomplaintid).FirstOrDefault();
                driverComplaintdtls.IsDelete = true;
                driverComplaintdtls.DeletedAt = DateTime.UtcNow;
                driverComplaintdtls.DeletedBy = "Admin";
                content.TabDriverComplaint.Update(driverComplaintdtls);
                content.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "IsDeleteDriverComplaintTemplate", content);
                return false;
            }
        }
    }
     
}
