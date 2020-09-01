using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Models;

namespace TaxiAppsWebAPICore.Helper
{
    public class Validator
    {
        public static void validateZoneAdd(ManageZoneAdd manageZone)
        {
            if (!string.IsNullOrEmpty(manageZone.ZoneName))
            {
                throw new DataValidationException($"ZoneName does not exists");
            }
            if (!string.IsNullOrEmpty(manageZone.Unit))
            {
                throw new DataValidationException($"Unit does not exists");
            }
            if (manageZone.Serviceslocid == 0)
            {
                throw new DataValidationException($"Serviceslocid does not exists");
            }
        }

        public static void validateZoneRel(ZoneTypeRelation zoneTypeRelation)
        {
            if (zoneTypeRelation.Relationid == 0)
            {
                throw new DataValidationException($"Relationid does not exists");
            }
            if (zoneTypeRelation.Zoneid == 0)
            {
                throw new DataValidationException($"Zoneid does not exists");
            }
            if (zoneTypeRelation.Typeid == 0)
            {
                throw new DataValidationException($"Typeid does not exists");
            }
            if (!string.IsNullOrEmpty(zoneTypeRelation.Paymentmode))
            {
                throw new DataValidationException($"Paymentmode does not exists");
            }
            if (!string.IsNullOrEmpty(zoneTypeRelation.Showbill))
            {
                throw new DataValidationException($"Showbill does not exists");
            }
        }

        public static void validataeCancelUser(CancelUserInfo cancelUserInfo)
        {
            if (cancelUserInfo.Id == 0)
            {
                throw new DataValidationException($"Id does not exists");
            }
            if (cancelUserInfo.Zonetypeid == 0)
            {
                throw new DataValidationException($"Zonetypeid does not exists");
            }
            if (!string.IsNullOrEmpty(cancelUserInfo.PaymentStatus))
            {
                throw new DataValidationException($"PaymentStatus does not exists");
            }
            if (!string.IsNullOrEmpty(cancelUserInfo.ArrivalStatus))
            {
                throw new DataValidationException($"ArrivalStatus does not exists");
            }
            if (!string.IsNullOrEmpty(cancelUserInfo.CancelReasonArabic))
            {
                throw new DataValidationException($"CancelReasonArabic does not exists");
            }
            if (!string.IsNullOrEmpty(cancelUserInfo.CancelReasonEnglish))
            {
                throw new DataValidationException($"CancelReasonEnglish does not exists");
            }
            if (!string.IsNullOrEmpty(cancelUserInfo.CancelReasonSpanish))
            {
                throw new DataValidationException($"CancelReasonSpanish does not exists");
            }
        }

        public static void validateCancelDriver(CancelDriverInfo cancelDriverInfo)
        {
            if (cancelDriverInfo.Id == 0)
            {
                throw new DataValidationException($"Id does not exists");
            }
            if (cancelDriverInfo.Zonetypeid == 0)
            {
                throw new DataValidationException($"Zonetypeid does not exists");
            }
            if (!string.IsNullOrEmpty(cancelDriverInfo.PaymentStatus))
            {
                throw new DataValidationException($"PaymentStatus does not exists");
            }
            if (!string.IsNullOrEmpty(cancelDriverInfo.ArrivalStatus))
            {
                throw new DataValidationException($"ArrivalStatus does not exists");
            }
            if (!string.IsNullOrEmpty(cancelDriverInfo.CancelReasonArabic))
            {
                throw new DataValidationException($"CancelReasonArabic does not exists");
            }
            if (!string.IsNullOrEmpty(cancelDriverInfo.CancelReasonEnglish))
            {
                throw new DataValidationException($"CancelReasonEnglish does not exists");
            }
            if (!string.IsNullOrEmpty(cancelDriverInfo.CancelReasonSpanish))
            {
                throw new DataValidationException($"CancelReasonSpanish does not exists");
            }
        }
        public static void validateUserComplaint(ManageUserComplaint managePromo)
        {
            if (managePromo.ZoneId == 0)
            {
                throw new DataValidationException($"ZoneId does not exists");
            }
            if (managePromo.UserCompalintID == 0)
            {
                throw new DataValidationException($"UserCompalintID does not exists");
            }
            if (!string.IsNullOrEmpty(managePromo.UserComplaintTitle))
            {
                throw new DataValidationException($"UserComplaintTitle does not exists");
            }
            if (!string.IsNullOrEmpty(managePromo.UserComplaintType))
            {
                throw new DataValidationException($"UserComplaintType does not exists");
            }
        }

        public static void validateDriverComplaint(ManageDriverComplaint managePromo)
        {
            if (managePromo.ZoneId == 0)
            {
                throw new DataValidationException($"ZoneId does not exists");
            }
            if (managePromo.DriverCompalintID == 0)
            {
                throw new DataValidationException($"DriverCompalintID does not exists");
            }
            if (!string.IsNullOrEmpty(managePromo.DriverComplaintTitle))
            {
                throw new DataValidationException($"DriverComplaintTitle does not exists");
            }
            if (!string.IsNullOrEmpty(managePromo.DriverComplaintType))
            {
                throw new DataValidationException($"DriverComplaintType does not exists");
            }
        }

        public static void validateCurrency(CurrencyInfo currencyInfo)
        {
            if (currencyInfo.CurrencyID == 0)
            {
                throw new DataValidationException($"CurrencyID does not exists");
            }
            if (currencyInfo.StandardId == 0)
            {
                throw new DataValidationException($"StandardId does not exists");
            }
            if (!string.IsNullOrEmpty(currencyInfo.CurrencyName))
            {
                throw new DataValidationException($"CurrencyName does not exists");
            }
            if (!string.IsNullOrEmpty(currencyInfo.CurrencySymbol))
            {
                throw new DataValidationException($"CurrencySymbol does not exists");
            }
        }

        public static void validateRewardPoint(EditReward editReward)
        {
            if (editReward.DriverId == 0)
            {
                throw new DataValidationException($"DriverId does not exists");
            }
            if (editReward.RewardPoint == 0)
            {
                throw new DataValidationException($"RewardPoint does not exists");
            }
        }
        public static void validateDriver(EditDriver editDriver)
        {
            if (editDriver.DriverId == 0)
            {
                throw new DataValidationException($"DriverId does not exists");
            }
            if (editDriver.Country == 0)
            {
                throw new DataValidationException($"Country does not exists");
            }
            if (editDriver.DriverArea == 0)
            {
                throw new DataValidationException($"DriverArea does not exists");
            }
            if (editDriver.DriverType == 0)
            {
                throw new DataValidationException($"DriverType does not exists");
            }
            if (editDriver.ZoneId == 0)
            {
                throw new DataValidationException($"ZoneId does not exists");
            }
            if (!string.IsNullOrEmpty(editDriver.State))
            {
                throw new DataValidationException($"State does not exists");
            }
            if (!string.IsNullOrEmpty(editDriver.ProfilePic))
            {
                throw new DataValidationException($"ProfilePic does not exists");
            }
            if (!string.IsNullOrEmpty(editDriver.Password))
            {
                throw new DataValidationException($"Password does not exists");
            }
            if (!string.IsNullOrEmpty(editDriver.NationalId))
            {
                throw new DataValidationException($"NationalId does not exists");
            }
            if (!string.IsNullOrEmpty(editDriver.LastName))
            {
                throw new DataValidationException($"LastName does not exists");
            }
            if (!string.IsNullOrEmpty(editDriver.Address))
            {
                throw new DataValidationException($"Address does not exists");
            }
            if (!string.IsNullOrEmpty(editDriver.City))
            {
                throw new DataValidationException($"City does not exists");
            }
            if (!string.IsNullOrEmpty(editDriver.Company))
            {
                throw new DataValidationException($"Company does not exists");
            }
            if (!string.IsNullOrEmpty(editDriver.ContactNo))
            {
                throw new DataValidationException($"ContactNo does not exists");
            }
            if (!string.IsNullOrEmpty(editDriver.Email))
            {
                throw new DataValidationException($"Email does not exists");
            }
            if (!string.IsNullOrEmpty(editDriver.Gender))
            {
                throw new DataValidationException($"Gender does not exists");
            }
            if (!string.IsNullOrEmpty(editDriver.FirstName))
            {
                throw new DataValidationException($"FirstName does not exists");
            }
        }
        public static void validateDriverInfo(DriverInfo driverInfo)
        {
            if (driverInfo.DriverId == 0)
            {
                throw new DataValidationException($"DriverId does not exists");
            }
            if (driverInfo.Country == 0)
            {
                throw new DataValidationException($"Country does not exists");
            }
            if (driverInfo.DriverArea == 0)
            {
                throw new DataValidationException($"DriverArea does not exists");
            }
            if (driverInfo.DriverType == 0)
            {
                throw new DataValidationException($"DriverType does not exists");
            }
            if (driverInfo.ZoneId == 0)
            {
                throw new DataValidationException($"ZoneId does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.State))
            {
                throw new DataValidationException($"State does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.ProfilePic))
            {
                throw new DataValidationException($"ProfilePic does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.Password))
            {
                throw new DataValidationException($"Password does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.NationalId))
            {
                throw new DataValidationException($"NationalId does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.LastName))
            {
                throw new DataValidationException($"LastName does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.Address))
            {
                throw new DataValidationException($"Address does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.City))
            {
                throw new DataValidationException($"City does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.Company))
            {
                throw new DataValidationException($"Company does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.ContactNo))
            {
                throw new DataValidationException($"ContactNo does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.Email))
            {
                throw new DataValidationException($"Email does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.Gender))
            {
                throw new DataValidationException($"Gender does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.FirstName))
            {
                throw new DataValidationException($"FirstName does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.CarColour))
            {
                throw new DataValidationException($"CarColour does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.CarManu))
            {
                throw new DataValidationException($"CarManu does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.CarModel))
            {
                throw new DataValidationException($"CarModel does not exists");
            }
            if (!string.IsNullOrEmpty(driverInfo.CarNumber))
            {
                throw new DataValidationException($"CarNumber does not exists");
            }
            if (driverInfo.CarYear == 0)
            {
                throw new DataValidationException($"CarYear does not exists");
            }
        }
        public static void validateDriverWallet(DriverAddWallet driverAddWallet)
        {
            if (driverAddWallet.DriverId == 0)
            {
                throw new DataValidationException($"DriverId does not exists");
            }
            if (driverAddWallet.Transactionid == 0)
            {
                throw new DataValidationException($"Transactionid does not exists");
            }
            if (driverAddWallet.Currencyid == 0)
            {
                throw new DataValidationException($"Currencyid does not exists");
            }
            if (driverAddWallet.Walletamount == 0)
            {
                throw new DataValidationException($"Walletamount does not exists");
            }
        }
        public static void validateDriverFine(DriverFineInfo driverFineInfo)
        {
            if (driverFineInfo.Driverid == 0)
            {
                throw new DataValidationException($"DriverId does not exists");
            }
            if (driverFineInfo.Currencyid == 0)
            {
                throw new DataValidationException($"Currencyid does not exists");
            }
            if (driverFineInfo.DriverFineId == 0)
            {
                throw new DataValidationException($"DriverFineId does not exists");
            }
            if (driverFineInfo.Fineamount == 0)
            {
                throw new DataValidationException($"Fineamount does not exists");
            }
            if (!string.IsNullOrEmpty(driverFineInfo.Fine_reason))
            {
                throw new DataValidationException($"Fine_reason does not exists");
            }
        }
        public static void validateDriverBonus(DriverBonusInfo driverBonusInfo)
        {
            if (driverBonusInfo.Driverid == 0)
            {
                throw new DataValidationException($"DriverId does not exists");
            }           
            if (driverBonusInfo.DriverFineId == 0)
            {
                throw new DataValidationException($"DriverFineId does not exists");
            }
            if (driverBonusInfo.Amount == 0)
            {
                throw new DataValidationException($"Amount does not exists");
            }
            if (!string.IsNullOrEmpty(driverBonusInfo.Reason))
            {
                throw new DataValidationException($"Reason does not exists");
            }
        }
    }
}
