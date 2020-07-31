﻿using System;
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

        public DriverList GetbyId(long driverId, TaxiAppzDBContext context)
        {
            try
            {
                DriverList driverList = new DriverList();
                var drivers = context.TabDrivers.Where(u => u.Driverid == driverId && u.IsDelete == false).FirstOrDefault();

                driverList.Email = drivers.Email;
                driverList.AcceptanceRatio = "";
                driverList.Document = "";
                driverList.DriverName = drivers.FirstName + " " + drivers.LastName;
                driverList.Email = drivers.Email;
                driverList.RegistrationCode = drivers.Driverregno;
                driverList.Rating = "";
                driverList.IsActive = drivers.IsActive;
                driverList.PhoneNumber = drivers.ContactNo;

                return driverList == null ? null : driverList;

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
            try
            {
                // if (context.TabDrivers.Any(t => t.Email.ToLowerInvariant() == driverInfo.Email.ToLowerInvariant()))
                //    throw new DataValidationException($"Artifact with name '{driverInfo.Email}' already exists.");
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
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "Save", context);
                return false;
            }
        }

        public bool Edit(TaxiAppzDBContext context, EditDriver editDriver, LoggedInUser loggedInUser)
        {
            try
            {
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
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.Email, "Edit", context);
                return false;
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

        public List<DriverAddWallet> ListWallet(TaxiAppzDBContext context)
        {
            try
            {

                List<DriverAddWallet> driverListWallet = new List<DriverAddWallet>();
                var Walletlist = context.TabDriverWallet.Where(t => t.IsDelete == false).ToList().OrderByDescending(t => t.Updatedat);
                foreach (var wallet in Walletlist)
                {
                    driverListWallet.Add(new DriverAddWallet()
                    {
                        Currencyid=wallet.Currencyid,
                        Transactionid=wallet.Transactionid,
                        Walletamount=wallet.Walletamount,                        
                    });
                }
                return driverListWallet;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListWallet", context);
                return null;
            }
        }
    }

}