using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Helper;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DADriver
    {
        public List<DriverList> List(TaxiAppzDBContext context)
        {
            try
            {

                List<DriverList> driverListModel = new List<DriverList>();
                var driverlist = context.TabDrivers.Where(t => t.IsDelete == false).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var drivers in driverlist)
                {
                    driverListModel.Add(new DriverList()
                    {
                        DriverId = drivers.Driverid,
                        RegistrationCode = drivers.Driverregno,
                        AcceptanceRatio = "",
                        DriverName = drivers.FirstName + " " + drivers.LastName,
                        Email = drivers.Email,
                        PhoneNumber = drivers.ContactNo,
                        Document = "",
                        Rating = "",
                        IsActive = drivers.IsActive
                    });
                }
                return driverListModel;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "List", context);
                return null;
            }
        }

        public List<DriverList> BlockedList(TaxiAppzDBContext context)
        {
            try
            {
                List<DriverList> driverListModel = new List<DriverList>();
                var driverlist = context.TabDrivers.Where(u => u.IsActive == false && u.IsDelete == false).ToList();
                foreach (var drivers in driverlist)
                {
                    driverListModel.Add(new DriverList()
                    {
                        DriverId = drivers.Driverid,
                        RegistrationCode = drivers.Driverregno,
                        AcceptanceRatio = "",
                        DriverName = drivers.FirstName + " " + drivers.LastName,
                        Email = drivers.Email,
                        PhoneNumber = drivers.ContactNo,
                        Document = "",
                        Rating = "",
                        IsActive = drivers.IsActive
                    });
                }
                return driverListModel == null ? null : driverListModel;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "BlockedList", context);
                return null;
            }
        }

        public DriverInfo GetbyId(long driverId, TaxiAppzDBContext context)
        {
            try
            {
                DriverInfo tabDrivers = new DriverInfo();
                var driverInfo = context.TabDrivers.Where(u => u.Driverid == driverId && u.IsDelete == false).FirstOrDefault();
                if (driverInfo != null)
                {
                    tabDrivers.FirstName = driverInfo.FirstName;
                    tabDrivers.LastName = driverInfo.LastName;
                    tabDrivers.Email = driverInfo.Email;
                    tabDrivers.ContactNo = driverInfo.ContactNo;
                    tabDrivers.Gender = driverInfo.Gender;
                    tabDrivers.Address = driverInfo.Address;
                    tabDrivers.City = driverInfo.City;
                    tabDrivers.State = driverInfo.State;
                    tabDrivers.Country = driverInfo.Countryid;
                    tabDrivers.Company = "";
                    tabDrivers.DriverArea = driverInfo.Servicelocid;
                    tabDrivers.Password = driverInfo.Password;
                    tabDrivers.DriverType = driverInfo.Typeid = 1;
                    tabDrivers.CarModel = driverInfo.Carmodel;
                    tabDrivers.CarColour = driverInfo.Carcolor;
                    tabDrivers.CarNumber = driverInfo.Carnumber;
                    tabDrivers.CarManu = driverInfo.Carmanufacturer;
                    tabDrivers.CarYear = driverInfo.Caryear;
                    tabDrivers.NationalId = driverInfo.NationalId;
                }
                return tabDrivers == null ? null : tabDrivers;

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
                var updatedate = context.TabDrivers.Where(u => u.Driverid == id && u.IsDelete == false).FirstOrDefault();
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

        public bool Save(TaxiAppzDBContext context, DriverInfo driverInfo, LoggedInUser loggedInUser)
        {
            var emailid = context.TabDrivers.FirstOrDefault(t => t.IsDelete == false && t.Email.ToLower() == driverInfo.Email.ToLower() && t.Driverid != driverInfo.DriverId);
            if (emailid != null)
                throw new DataValidationException($"Email id '{emailid.Email}' already exists.");

            TabDrivers tabDrivers = new TabDrivers();
            tabDrivers.FirstName = driverInfo.FirstName;
            tabDrivers.LastName = driverInfo.LastName;
            tabDrivers.Email = driverInfo.Email;
            tabDrivers.ContactNo = driverInfo.ContactNo;
            tabDrivers.Gender = driverInfo.Gender;
            tabDrivers.Address = driverInfo.Address;
            tabDrivers.City = driverInfo.City;
            tabDrivers.State = driverInfo.State;
            tabDrivers.Countryid = driverInfo.Country;
            tabDrivers.Company = "";
            tabDrivers.Servicelocid = driverInfo.DriverArea;
            tabDrivers.Password = driverInfo.Password;
            tabDrivers.Typeid = driverInfo.DriverType;
            tabDrivers.Carmodel = driverInfo.CarModel;
            tabDrivers.Carcolor = driverInfo.CarColour;
            tabDrivers.Carnumber = driverInfo.CarNumber;
            tabDrivers.Carmanufacturer = driverInfo.CarManu;
            tabDrivers.Caryear = driverInfo.CarYear;
            tabDrivers.NationalId = driverInfo.NationalId;
            tabDrivers.Driverregno = (context.TabDrivers.Count() + 1).ToString();
            tabDrivers.CreatedAt = tabDrivers.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            tabDrivers.CreatedBy = tabDrivers.UpdatedBy = loggedInUser.Email;
            tabDrivers.IsDelete = false;
            tabDrivers.IsActive = true;
            context.Add(tabDrivers);
            context.SaveChanges();
            return true;
        }

        public bool Edit(TaxiAppzDBContext context, EditDriver editDriver, LoggedInUser loggedInUser)
        {
            var emailid = context.TabDrivers.FirstOrDefault(t => t.IsDelete == false && t.Email.ToLower() == editDriver.Email.ToLower() && t.Driverid != editDriver.DriverId);
            if (emailid != null)
                throw new DataValidationException($"Email id '{emailid.Email}' already exists.");

            var tabDrivers = context.TabDrivers.Where(r => r.Driverid == editDriver.DriverId && r.IsDelete == false).FirstOrDefault();
            if (tabDrivers != null)
            {
                tabDrivers.FirstName = editDriver.FirstName;
                tabDrivers.LastName = editDriver.LastName;
                tabDrivers.Email = editDriver.Email;
                tabDrivers.ContactNo = editDriver.ContactNo;
                tabDrivers.Gender = editDriver.Gender;
                tabDrivers.Address = editDriver.Address;
                tabDrivers.City = editDriver.City;
                tabDrivers.State = editDriver.State;
                tabDrivers.Countryid = editDriver.Country;
                tabDrivers.Company = "";
                tabDrivers.Servicelocid = editDriver.DriverArea;
                tabDrivers.Password = editDriver.Password;
                tabDrivers.Typeid = editDriver.DriverType;
                tabDrivers.NationalId = editDriver.NationalId;
                //tabDrivers.Driverregno = (context.TabDrivers.Count() + 1).ToString();
                tabDrivers.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                tabDrivers.UpdatedBy = loggedInUser.Email;
                context.Update(tabDrivers);
                context.SaveChanges();
                return true;
                   
            }
            return false;
        }

        internal bool AddBonus(TaxiAppzDBContext context, DriverBonusInfo driverBonusInfo, LoggedInUser loggedInUser)
        {
            try
            {
                TabDriverBonus tabDriverBonus = new TabDriverBonus();
                tabDriverBonus.Driverid = driverBonusInfo.Driverid;
                tabDriverBonus.Bonusamount = driverBonusInfo.Amount;
                tabDriverBonus.BonusReason = driverBonusInfo.Reason;

                tabDriverBonus.Createdat = tabDriverBonus.Updatedat = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                tabDriverBonus.Createdby = tabDriverBonus.Updatedby = loggedInUser.Email;
                tabDriverBonus.IsDelete = false;
                tabDriverBonus.IsActive = true;
                context.Add(tabDriverBonus);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "Save", context);
                return false;
            }
        }

        internal bool EditBonus(TaxiAppzDBContext context, DriverBonusInfo driverBonusInfo, LoggedInUser loggedInUser)
        {
            try
            {
                var tabDriverBonus = context.TabDriverBonus.Where(r => r.Driverid == driverBonusInfo.Driverid && r.IsDelete == false).FirstOrDefault();
                if (tabDriverBonus != null)
                {

                    tabDriverBonus.Driverid = driverBonusInfo.Driverid;
                    tabDriverBonus.Bonusamount = driverBonusInfo.Amount;
                    tabDriverBonus.BonusReason = driverBonusInfo.Reason;

                    tabDriverBonus.Updatedat = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    tabDriverBonus.Updatedby = loggedInUser.Email;
                    tabDriverBonus.IsDelete = false;
                    tabDriverBonus.IsActive = true;
                    context.Update(tabDriverBonus);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "Save", context);
                return false;
            }
        }

        internal bool DeleteBonus(TaxiAppzDBContext context, long driverId, LoggedInUser loggedInUser)
        {
            try
            {
                var tabDriverBonus = context.TabDriverBonus.Where(r => r.Driverid == driverId && r.IsDelete == false).FirstOrDefault();
                if (tabDriverBonus != null)
                {


                    tabDriverBonus.Updatedat = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    tabDriverBonus.Updatedby = loggedInUser.Email;
                    tabDriverBonus.IsDelete = false;

                    context.Update(tabDriverBonus);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "Save", context);
                return false;
            }
        }

        internal List<DriverBonusList> ListBonus(TaxiAppzDBContext context)
        {
            try
            {

                List<DriverBonusList> driverfine = new List<DriverBonusList>();
                var fineList = context.TabDriverBonus.Include(t => t.Driver).Where(t => t.IsDelete == false).ToList().OrderByDescending(t => t.Updatedat);
                foreach (var fine in fineList)
                {
                    driverfine.Add(new DriverBonusList()
                    {
                        DriverFineId = fine.Driverbonusid,
                        Driverid = fine.Driverid,
                        Amount = fine.Bonusamount,
                        Reason = fine.BonusReason,
                        DriverName = fine.Driver.FirstName + ' ' + fine.Driver.LastName,
                        PhoneNumber = fine.Driver.ContactNo,
                        RegistrationCode = fine.Driver.Driverregno

                    });
                }
                return driverfine;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListFine", context);
                return null;
            }
        }

        public bool DisableUser(TaxiAppzDBContext context, long id, bool status, LoggedInUser loggedInUser)
        {
            try
            {
                var updatedate = context.TabDrivers.Where(u => u.Driverid == id && u.IsDelete == false).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    updatedate.UpdatedBy = loggedInUser.Email;
                    updatedate.IsActive = status;
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "DisableUser", context);
                return false;
            }
        }

        public bool AddWallet(TaxiAppzDBContext context, DriverAddWallet driverAddWallet, LoggedInUser loggedInUser)
        {
            try
            {
                // if (context.TabDrivers.Any(t => t.Email.ToLowerInvariant() == driverInfo.Email.ToLowerInvariant()))
                //    throw new DataValidationException($"Artifact with name '{driverInfo.Email}' already exists.");
                TabDriverWallet tabDriverWallet = new TabDriverWallet();
                tabDriverWallet.Driverid = driverAddWallet.DriverId;
                tabDriverWallet.Currencyid = driverAddWallet.Currencyid;
                tabDriverWallet.Transactionid = driverAddWallet.Transactionid;
                tabDriverWallet.Walletamount = driverAddWallet.Walletamount;

                tabDriverWallet.Createdat = tabDriverWallet.Updatedat = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                tabDriverWallet.Createdby = tabDriverWallet.Updatedby = loggedInUser.Email;
                tabDriverWallet.IsDelete = false;
                tabDriverWallet.IsActive = true;
                context.Add(tabDriverWallet);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "AddWallet", context);
                return false;
            }
        }

        public DriverListWallet ListWallet(TaxiAppzDBContext context, long driverid)
        {
            try
            {
                DriverListWallet driverLists = new DriverListWallet();

                List<DriverAddWallet> driverListWallet = new List<DriverAddWallet>();
                var Walletlist = context.TabDriverWallet.Where(t => t.IsDelete == false && t.Driverid == driverid).ToList().OrderByDescending(t => t.Updatedat);
                foreach (var wallet in Walletlist)
                {
                    driverListWallet.Add(new DriverAddWallet()
                    {
                        Currencyid = wallet.Currencyid,
                        Transactionid = wallet.Transactionid,
                        Walletamount = wallet.Walletamount,
                        TransactionDate = wallet.Createdat
                    });
                }
                driverLists.WalletList = driverListWallet;
                driverLists.Amountadded = driverListWallet.Sum(t => t.Walletamount);
                driverLists.Amountbalance = driverListWallet.Sum(t => t.Walletamount);
                driverLists.Amountspent = driverListWallet.Sum(t => t.Walletamount);
                return driverLists;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListWallet", context);
                return null;
            }
        }

        public List<DriverFineInfo> ListFine(TaxiAppzDBContext context)
        {
            try
            {
                List<DriverFineInfo> driverfine = new List<DriverFineInfo>();
                var fineList = context.TabDriverFine.Include(t => t.Driver).Where(t => t.IsDelete == false).ToList().OrderByDescending(t => t.Updatedat);
                foreach (var fine in fineList)
                {
                    driverfine.Add(new DriverFineInfo()
                    {
                        DriverFineId = fine.Driverfineid,
                        Driverid = fine.Driverid,
                        Fineamount = fine.Fineamount,
                        Finepaid_status = fine.FinepaidStatus,
                        Fine_reason = fine.FineReason,
                        DriverName = fine.Driver.FirstName + ' ' + fine.Driver.LastName,
                        PhoneNumber = fine.Driver.ContactNo,
                        RegistrationCode = fine.Driver.Driverregno

                    });
                }
                return driverfine;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListFine", context);
                return null;
            }
        }

        public bool AddFine(TaxiAppzDBContext context, DriverFineInfo driverFineInfo, LoggedInUser loggedInUser)
        {
            try
            {
                TabDriverFine tabDriverFine = new TabDriverFine();

                tabDriverFine.Fineamount = driverFineInfo.Fineamount;
                tabDriverFine.FineReason = driverFineInfo.Fine_reason;
                //tabDriverFine.Currencyid = driverFineInfo.Currencyid;
                tabDriverFine.Driverid = driverFineInfo.Driverid;
                tabDriverFine.FinepaidStatus = false;
                tabDriverFine.Createdat = tabDriverFine.Updatedat = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                tabDriverFine.Createdby = tabDriverFine.Updatedby = loggedInUser.Email;
                tabDriverFine.IsDelete = false;
                tabDriverFine.IsActive = true;
                context.Add(tabDriverFine);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "AddFine", context);
                return false;
            }
        }

        public DriverFineInfo GetbyFineId(long driverId, TaxiAppzDBContext context)
        {
            try
            {
                DriverFineInfo driverFineList = new DriverFineInfo();
                var fines = context.TabDriverFine.Include(t => t.Driver).Where(u => u.Driverid == driverId && u.IsDelete == false).FirstOrDefault();

                driverFineList.Driverid = fines.Driverid;
                driverFineList.DriverName = fines.Driver.FirstName + ' ' + fines.Driver.LastName;
                driverFineList.Fineamount = fines.Fineamount;
                driverFineList.Fine_reason = fines.FineReason;
                driverFineList.Finepaid_status = fines.FinepaidStatus;
                driverFineList.RegistrationCode = fines.Driver.Driverregno;
                driverFineList.PhoneNumber = fines.Driver.ContactNo;

                return driverFineList == null ? null : driverFineList;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbyFineId", context);
                return null;
            }

        }

        public bool EditFine(TaxiAppzDBContext context, DriverFineInfo driverFineInfo, LoggedInUser loggedInUser)
        {
            try
            {
                var tabDriverFine = context.TabDriverFine.Where(r => r.Driverid == driverFineInfo.DriverFineId && r.IsDelete == false).FirstOrDefault();
                if (tabDriverFine != null)
                {
                    tabDriverFine.Fineamount = driverFineInfo.Fineamount;
                    tabDriverFine.FinepaidStatus = driverFineInfo.Finepaid_status;
                    tabDriverFine.FineReason = driverFineInfo.Fine_reason;

                    tabDriverFine.Updatedat = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                    tabDriverFine.Updatedby = loggedInUser.Email;
                    context.Update(tabDriverFine);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "EditFine", context);
                return false;
            }
        }

        internal bool DeleteFine(TaxiAppzDBContext context, long id, LoggedInUser loggedInUser)
        {
            var updatedate = context.TabDriverFine.Where(u => u.Driverid == id && u.IsDelete == false).FirstOrDefault();
            if (updatedate != null)
            {
                updatedate.Updatedat = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                updatedate.Updatedby = loggedInUser.Email;
                updatedate.IsDelete = true;
                context.Update(updatedate);
                context.SaveChanges();
                return true;

            }
            return false;
        }

        public DriverBonusInfo GetByBonusId(long driverId, TaxiAppzDBContext context)
        {
            try
            {
                DriverBonusInfo driverBonusInfo = new DriverBonusInfo();
                var drivers = context.TabDriverBonus.Where(u => u.Driverid == driverId && u.IsDelete == false).FirstOrDefault();
                if (drivers != null)
                {
                    driverBonusInfo.Amount = drivers.Bonusamount;
                    driverBonusInfo.Reason = drivers.BonusReason;
                    driverBonusInfo.Driverid = drivers.Driverid;
                }
                return driverBonusInfo == null ? null : driverBonusInfo;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbyId", context);
                return null;
            }

        }
    }

}