using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.DALayer
{
    public class DAOTP
    {
        public string GenerateOTP(OTPModel otpmodel, TaxiAppzDBContext context)
        {
            try
            {
                var otp = new Random().Next(100000, 999999);
                TabOtpUsers tabOtpUsers = new TabOtpUsers();
                var isexist = context.TabOtpUsers.Where(t => t.UserContactNo == otpmodel.Contactno && t.IsActive == true).FirstOrDefault();
                if (isexist == null)
                {
                    tabOtpUsers.UserContactNo = otpmodel.Contactno;
                    tabOtpUsers.UserDeviceName = otpmodel.DeviceName;
                    tabOtpUsers.UserDeviceIpaddress = otpmodel.DeviceIPAddress;
                    tabOtpUsers.UserOtp = otp;
                    tabOtpUsers.IsActive = true;
                    tabOtpUsers.UserOtpCreatedDate = DateTime.UtcNow;
                    tabOtpUsers.UserOtpExpireDate = DateTime.UtcNow.AddMinutes(2);
                    tabOtpUsers.CreatedBy = "Admin";
                    tabOtpUsers.CreatedAt = DateTime.UtcNow;
                    context.TabOtpUsers.Add(tabOtpUsers);
                    context.SaveChanges();
                    return otp.ToString();
                }
                else
                {
                    isexist.IsActive = false;
                    isexist.UpdatedBy = "Admin";
                    isexist.UpdatedAt = DateTime.UtcNow;
                    context.TabOtpUsers.Update(isexist);

                    tabOtpUsers.UserContactNo = otpmodel.Contactno;
                    tabOtpUsers.UserDeviceName = otpmodel.DeviceName;
                    tabOtpUsers.UserDeviceIpaddress = otpmodel.DeviceIPAddress;
                    tabOtpUsers.UserOtp = otp;
                    tabOtpUsers.IsActive = true;
                    tabOtpUsers.UserOtpCreatedDate = DateTime.UtcNow;
                    tabOtpUsers.UserOtpExpireDate = DateTime.UtcNow.AddMinutes(2);
                    tabOtpUsers.CreatedBy = "Admin";
                    tabOtpUsers.CreatedAt = DateTime.UtcNow;
                    context.TabOtpUsers.Add(tabOtpUsers);
                    context.SaveChanges();
                    return otp.ToString();
                }

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GenerateOTP", context);
                return "OTP Generation Failed";
            }
        }
        public UserInfo ValidateOTP(long OTP, TaxiAppzDBContext context)
        {
            var user = new UserInfo();
            try
            {
                var isOTPexist = context.TabOtpUsers.Where(t => t.UserOtp == OTP).FirstOrDefault();
                if (isOTPexist != null)
                {
                    int validation = DateTime.Compare((DateTime)isOTPexist.UserOtpExpireDate, DateTime.UtcNow);
                    if (validation >= 0)
                    {
                        var isUserExist = context.TabUser.Where(t => t.PhoneNumber == isOTPexist.UserContactNo.ToString() && t.IsDelete == 0).FirstOrDefault();
                        if (isUserExist != null)
                        {
                            var isUserActive = context.TabUser.Where(t => t.PhoneNumber == isOTPexist.UserContactNo.ToString() && t.IsActive == 1).FirstOrDefault();
                            if (isUserActive != null)
                            {
                             
                                var tokenString = Extention.GenerateJWTToken(isUserExist, context);
                                user = new UserInfo()
                                {
                                    Email = isUserExist.Email,
                                    RememberToken = tokenString,
                                    LastName = isUserExist.Lastname,
                                    FirstName = isUserExist.Lastname,
                                    ContactNo = isUserExist.PhoneNumber,
                                    ExpireDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.AddMinutes(300)),
                                    Status = "OTP Validation Success and Existing User"
                                };
                                bool updatetoken = Extention.UpdateUserToken(user.Email, user, context);
                                return user;
                            }
                            user.Status = "OTP Validation Success but User is in InActive";
                            return user;
                        }
                        user.Status = "OTP Validation Success but New User";
                        return user;
                    }
                    user.Status = "OTP Expired";
                    return user;
                }
                user.Status = "Invalid OTP";
                return user;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ValidateOTP", context);
                user.Status = "OTP Generation Failed";
                return user;
            }
        }

        public List<CountryModel> GetCountryList(TaxiAppzDBContext context)
        {
            List<CountryModel> countryModel = new List<CountryModel>();
            var countryData = context.TabCountry.ToList();
            foreach (var country in countryData)
            {
                countryModel.Add(new CountryModel()
                {
                    CountryId = country.CountryId,
                    CountryName = country.Name,

                });
            }
            return countryModel == null ? null : countryModel;
        }

        public List<ServiceLocationModel> ListService(TaxiAppzDBContext context)
        {
            try
            {
                List<ServiceLocationModel> serviceList = new List<ServiceLocationModel>();
                var listService = context.TabServicelocation.Include(t => t.Country).Where(t => t.Countryid == serviceList.).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var service in listService)
                {
                    serviceList.Add(new ServiceLocationModel()
                    {
                        CountryId = service.Countryid,
                        CountryName=service.Name
                    });
                }
                return serviceList != null ? serviceList : null;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListService", context);
                return null;
            }

        }
    }
}