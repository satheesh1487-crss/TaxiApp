using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DACancel
    {
        public List<CancelUser> UserList(TaxiAppzDBContext context)
        {
            try
            {

                List<CancelUser> cancelUsers = new List<CancelUser>();
                var userlist = context.TabUserCancellation.Where(t => t.IsDelete == false).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var users in userlist)
                {
                    cancelUsers.Add(new CancelUser()
                    {
                        Id=users.UserCancelId,
                        ArrivalStatus=users.Arrivalstatus,
                        CancellationList=users.CancellationReasonEnglish,
                        PayingStatus=users.Paymentstatus,
                        Type="user", 
                        IsActive=users.IsActive
                    });
                }
                return cancelUsers;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "UserList", context);
                return null;
            }
        }

        public CancelUserInfo GetbyUserCancelId(long userCancelId, TaxiAppzDBContext context)
        {
            try
            {
                CancelUserInfo cancelUserInfo = new CancelUserInfo();
                var users = context.TabUserCancellation.Where(u => u.UserCancelId == userCancelId && u.IsDelete == false).FirstOrDefault();
                if (users != null)
                {
                    cancelUserInfo.Id = users.UserCancelId;
                    cancelUserInfo.Zonetypeid = users.Zonetypeid;
                    cancelUserInfo.PaymentStatus = users.Paymentstatus;
                    cancelUserInfo.CancelReasonEnglish = users.CancellationReasonEnglish;
                    cancelUserInfo.CancelReasonArabic = users.CancellationReasonArabic;
                    cancelUserInfo.CancelReasonSpanish = users.CancellationReasonSpanish;
                    cancelUserInfo.ArrivalStatus = users.Arrivalstatus;
                }
                return cancelUserInfo == null ? null : cancelUserInfo;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbyUserCancelId", context);
                return null;
            }

        }

        public bool SaveCancelUser(TaxiAppzDBContext context, CancelUserInfo cancelUserInfo, LoggedInUser loggedInUser)
        {
            try
            {
                // if (context.TabDrivers.Any(t => t.Email.ToLowerInvariant() == driverInfo.Email.ToLowerInvariant()))
                //    throw new DataValidationException($"Artifact with name '{driverInfo.Email}' already exists.");
                TabUserCancellation tabUserCancellation = new TabUserCancellation();
                tabUserCancellation.Arrivalstatus = cancelUserInfo.ArrivalStatus;
                tabUserCancellation.CancellationReasonArabic = cancelUserInfo.CancelReasonArabic;
                tabUserCancellation.CancellationReasonEnglish = cancelUserInfo.CancelReasonEnglish;
                tabUserCancellation.CancellationReasonSpanish = cancelUserInfo.CancelReasonSpanish;
                tabUserCancellation.Paymentstatus = cancelUserInfo.PaymentStatus;                
                tabUserCancellation.Zonetypeid = cancelUserInfo.Zonetypeid;

                tabUserCancellation.CreatedAt = tabUserCancellation.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                tabUserCancellation.CreatedBy = tabUserCancellation.UpdatedBy = loggedInUser.Email;
                tabUserCancellation.IsDelete = false;
                tabUserCancellation.IsActive = true;
                context.Add(tabUserCancellation);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "SaveCancelUser", context);
                return false;
            }
        }

        public bool EditUser(TaxiAppzDBContext context, CancelUserInfo cancelUserInfo, LoggedInUser loggedInUser)
        {
            try
            {
                var tabUserCancellation = context.TabUserCancellation.Where(r => r.UserCancelId == cancelUserInfo.Id && r.IsDelete == false).FirstOrDefault();
                if (tabUserCancellation != null)
                {
                    tabUserCancellation.Arrivalstatus = cancelUserInfo.ArrivalStatus;
                    tabUserCancellation.CancellationReasonArabic = cancelUserInfo.CancelReasonArabic;
                    tabUserCancellation.CancellationReasonEnglish = cancelUserInfo.CancelReasonEnglish;
                    tabUserCancellation.CancellationReasonSpanish = cancelUserInfo.CancelReasonSpanish;
                    tabUserCancellation.Paymentstatus = cancelUserInfo.PaymentStatus;                
                    tabUserCancellation.Zonetypeid = cancelUserInfo.Zonetypeid;
                    tabUserCancellation.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    tabUserCancellation.UpdatedBy = loggedInUser.Email;
                    context.Update(tabUserCancellation);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "Edit", context);
                return false;
            }
        }

        public bool DeleteUser(TaxiAppzDBContext context, long id, LoggedInUser loggedInUser)
        {
            try
            {
                var updatedate = context.TabUserCancellation.Where(u => u.UserCancelId == id && u.IsDelete == false).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.DeletedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    updatedate.DeletedBy = loggedInUser.Email;
                    updatedate.IsDelete = true;
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "Delete", context);
                return false;
            }
        }

        public bool StatusUser(TaxiAppzDBContext context, long id, bool isStatus, LoggedInUser loggedInUser)
        {
            try
            {

                var updatedate = context.TabUserCancellation.Where(r => r.UserCancelId == id && r.IsDelete == false).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.IsActive = isStatus == true;
                    updatedate.UpdatedAt = DateTime.UtcNow;
                    updatedate.UpdatedBy = "admin";
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "StatusType", context);
                return false;
            }
        }

        public List<CancelDriver> DriverList(TaxiAppzDBContext context)
        {
            try
            {

                List<CancelDriver> cancelDrivers = new List<CancelDriver>();
                var driverlist = context.TabDriverCancellation.Where(t => t.IsDelete == false).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var drivers in driverlist)
                {
                    cancelDrivers.Add(new CancelDriver()
                    {
                        Id = drivers.DriverCancelId,
                        ArrivalStatus = drivers.Arrivalstatus,
                        CancellationList = drivers.CancellationReasonEnglish,
                        PayingStatus = drivers.Paymentstatus,
                        Type = "driver",
                        IsActive = drivers.IsActive
                    });
                }
                return cancelDrivers;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "DriverList", context);
                return null;
            }
        }

        public CancelDriverInfo GetbyDriverCancelId(long driverCancelId, TaxiAppzDBContext context)
        {
            try
            {
                CancelDriverInfo cancelDriverInfo = new CancelDriverInfo();
                var drivers = context.TabDriverCancellation.Where(u => u.DriverCancelId == driverCancelId && u.IsDelete == false).FirstOrDefault();
                if (drivers != null)
                {
                    cancelDriverInfo.Id = drivers.DriverCancelId;
                    cancelDriverInfo.Zonetypeid = drivers.Zonetypeid;
                    cancelDriverInfo.PaymentStatus = drivers.Paymentstatus;
                    cancelDriverInfo.CancelReasonEnglish = drivers.CancellationReasonEnglish;
                    cancelDriverInfo.CancelReasonArabic = drivers.CancellationReasonArabic;
                    cancelDriverInfo.CancelReasonSpanish = drivers.CancellationReasonSpanish;
                    cancelDriverInfo.ArrivalStatus = drivers.Arrivalstatus;
                }
                return cancelDriverInfo == null ? null : cancelDriverInfo;           

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbyDriverCancelId", context);
                return null;
            }

        }

        public bool SaveCancelDriver(TaxiAppzDBContext context, CancelDriverInfo cancelDriverInfo, LoggedInUser loggedInUser)
        {
            try
            {
                // if (context.TabDrivers.Any(t => t.Email.ToLowerInvariant() == driverInfo.Email.ToLowerInvariant()))
                //    throw new DataValidationException($"Artifact with name '{driverInfo.Email}' already exists.");
                TabDriverCancellation tabDriverCancellation = new TabDriverCancellation();
                tabDriverCancellation.Arrivalstatus = cancelDriverInfo.ArrivalStatus;
                tabDriverCancellation.CancellationReasonArabic = cancelDriverInfo.CancelReasonArabic;
                tabDriverCancellation.CancellationReasonEnglish = cancelDriverInfo.CancelReasonEnglish;
                tabDriverCancellation.CancellationReasonSpanish = cancelDriverInfo.CancelReasonSpanish;
                tabDriverCancellation.Paymentstatus = cancelDriverInfo.PaymentStatus;
                tabDriverCancellation.Zonetypeid = cancelDriverInfo.Zonetypeid;

                tabDriverCancellation.CreatedAt = tabDriverCancellation.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                tabDriverCancellation.CreatedBy = tabDriverCancellation.UpdatedBy = loggedInUser.Email;
                tabDriverCancellation.IsDelete = false;
                tabDriverCancellation.IsActive = true;
                context.Add(tabDriverCancellation);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "SaveCancelDriver", context);
                return false;
            }
        }

        public bool EditDriver(TaxiAppzDBContext context, CancelDriverInfo cancelDriverInfo, LoggedInUser loggedInUser)
        {
            try
            {
                var tabDriverCancellation = context.TabDriverCancellation.Where(r => r.DriverCancelId == cancelDriverInfo.Id && r.IsDelete == false).FirstOrDefault();
                if (tabDriverCancellation != null)
                {
                    tabDriverCancellation.Arrivalstatus = cancelDriverInfo.ArrivalStatus;
                    tabDriverCancellation.CancellationReasonArabic = cancelDriverInfo.CancelReasonArabic;
                    tabDriverCancellation.CancellationReasonEnglish = cancelDriverInfo.CancelReasonEnglish;
                    tabDriverCancellation.CancellationReasonSpanish = cancelDriverInfo.CancelReasonSpanish;
                    tabDriverCancellation.Paymentstatus = cancelDriverInfo.PaymentStatus;
                    tabDriverCancellation.Zonetypeid = cancelDriverInfo.Zonetypeid;
                    tabDriverCancellation.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    tabDriverCancellation.UpdatedBy = loggedInUser.Email;
                    context.Update(tabDriverCancellation);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "EditDriver", context);
                return false;
            }
        }

        public bool DeleteDriver(TaxiAppzDBContext context, long id, LoggedInUser loggedInUser)
        {
            try
            {
                var updatedate = context.TabDriverCancellation.Where(u => u.DriverCancelId == id && u.IsDelete == false).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.DeletedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    updatedate.DeletedBy = loggedInUser.Email;
                    updatedate.IsDelete = true;
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "DeleteDriver", context);
                return false;
            }
        }

        public bool StatusDriver(TaxiAppzDBContext context, long id, bool isStatus, LoggedInUser loggedInUser)
        {
            try
            {

                var updatedate = context.TabDriverCancellation.Where(r => r.DriverCancelId == id && r.IsDelete == false).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.IsActive = isStatus == true;
                    updatedate.UpdatedAt = DateTime.UtcNow;
                    updatedate.UpdatedBy = "admin";
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "StatusDriver", context);
                return false;
            }
        }
    }
}
