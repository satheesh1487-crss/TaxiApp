using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Services;
using TaziappzMobileWebAPI.Interface;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.DALayer
{
    public class DASign : ISign
    {
        private readonly TaxiAppzDBContext context;
        private readonly IToken _token;
        public DASign(TaxiAppzDBContext _context, IToken token)
        {
            context = _context;
            _token = token;
        }
        public DetailsWithToken  SignIn(SignInmodel signInmodel)
        {
            //TabUser tabUser = new TabUser();
             DetailsWithToken  user = new  DetailsWithToken();
           var tabusers = context.TabUser.Where(t => t.PhoneNumber == signInmodel.Contactno && t.IsActive == true && t.IsDelete == 0).FirstOrDefault();
            if (tabusers != null)
            {
                tabusers.LoginBy = signInmodel.LoginBy;
                tabusers.LoginMethod = signInmodel.LoginMethod;
                tabusers.DeviceToken = signInmodel.Devicetoken;
                context.TabUser.Update(tabusers);
                context.SaveChanges();
                var tokenString = _token.GenerateJWTTokenDtls(signInmodel);

                user.FirstName = tokenString[0].FirstName;
                user.LastName = tokenString[0].LastName;
                user.Mobileno = tokenString[0].Mobileno;
                user.Emailid = tokenString[0].Emailid;
                user.AccessToken = tokenString[0].AccessToken;
                user.RefreshToken = tokenString[0].RefreshToken;
                user.IsExist = tokenString[0].IsExist;
                user.IsActive = tokenString[0].IsActive;
 
                return user;
            }
               return user;
        }

        public List<DetailsWithDriverToken> SignInDriver(SignInmodel signInmodel)
        {
            List<DetailsWithDriverToken> driver = new List<DetailsWithDriverToken>();
            var tabDrivers = context.TabDrivers.Include( x => x.Serviceloc).Where(t => t.ContactNo == signInmodel.Contactno && t.IsActive == true && t.IsDelete == false).FirstOrDefault();
            if (tabDrivers == null)
                return driver;
                var Types = context.TabTypes.Where(t => t.Typeid == tabDrivers.Typeid && t.IsActive == 1 && t.IsDeleted == 0).FirstOrDefault();
                if (Types == null)
                    return driver;
            tabDrivers.LoginBy = signInmodel.LoginBy;
            tabDrivers.LoginMethod = signInmodel.LoginMethod;
            tabDrivers.DeviceToken = signInmodel.Devicetoken;
            context.TabDrivers.Update(tabDrivers);
            context.SaveChanges();
            var tokenString = _token.GenerateJWTDriverTokenDtls(signInmodel);
            driver.Add(new DetailsWithDriverToken()
            {
                FirstName = tokenString[0].FirstName,
                LastName = tokenString[0].LastName,
                Mobileno = tokenString[0].Mobileno,
                Emailid = tokenString[0].Emailid,
                Id = tabDrivers.Driverid,
                Login_by = tabDrivers.LoginBy,
                Login_method = tabDrivers.LoginMethod,
                Token = tokenString[0].Token,
                Is_approve = tabDrivers.IsApproved,
                Is_available = tabDrivers.IsAvailable,
                Car_model = tabDrivers.Carmodel,
                Car_number = tabDrivers.Carnumber,
                RefreshToken = tokenString[0].RefreshToken,
                Type = Types.Typename,
                IsExist = 1,
                IsActive = tabDrivers.IsActive,
                Servicelocationid= tabDrivers.Serviceloc.Servicelocid
            }) ;
                return driver;
            
        }
            public DetailsWithToken SignUp(SignUpmodel signUpmodel)
        {
            TabUser tabUser = new TabUser();
           DetailsWithToken user = new DetailsWithToken();
            var isServiceLocExist = context.TabServicelocation.Where(t => t.Servicelocid == signUpmodel.Servicelocationid && t.IsActive == 1 && t.IsDeleted == 0).FirstOrDefault();
            if (isServiceLocExist == null)
            {
                user.IsExist = 0;
                return user;
            }
            var timezone = context.TabTimezone.Where(t => t.Timezoneid == isServiceLocExist.Timezoneid && t.IsActive == 1 && t.IsDelete == 0).FirstOrDefault();
            var country = context.TabCountry.Where(t => t.CountryId == isServiceLocExist.Countryid && t.IsActive == true && t.IsDelete == false).FirstOrDefault();
            var isUserExist = context.TabUser.Where(t => t.PhoneNumber == signUpmodel.Mobileno).FirstOrDefault();
            if (timezone == null || country == null || isUserExist != null || isServiceLocExist == null)
            {
                user.IsExist = 0;
                return user;
            }
            tabUser.Firstname = signUpmodel.FirstName;
            tabUser.Lastname = signUpmodel.LastName;
            tabUser.Email = signUpmodel.Emailid;
            tabUser.PhoneNumber = signUpmodel.Mobileno;
            tabUser.Countryid = isServiceLocExist.Countryid;
            tabUser.Timezoneid = isServiceLocExist.Timezoneid;
            tabUser.Currencyid = isServiceLocExist.Currencyid;
            tabUser.DeviceToken = signUpmodel.Devicetoken;
            tabUser.LoginBy = signUpmodel.LoginBy;
            tabUser.LoginMethod = signUpmodel.LoginMethod;
            context.TabUser.Add(tabUser);
            context.SaveChanges();
           SignInmodel signInmodel = new SignInmodel();
            signInmodel.LoginBy = signUpmodel.LoginBy;
            signInmodel.LoginMethod = signUpmodel.LoginMethod;
            signInmodel.Devicetoken = signUpmodel.Devicetoken;
            signInmodel.Contactno = signUpmodel.Mobileno;
            var tokenString = _token.GenerateJWTTokenDtls(signInmodel);

            user.FirstName = tokenString[0].FirstName;
            user.LastName = tokenString[0].LastName;
            user.Mobileno = tokenString[0].Mobileno;
            user.Emailid = tokenString[0].Emailid;
            user.AccessToken = tokenString[0].AccessToken;
            user.RefreshToken = tokenString[0].RefreshToken;
            user.IsExist = tokenString[0].IsExist;
            user.IsActive = tokenString[0].IsActive;

            return user;
            
        }
        public List<DetailsWithDriverToken> SignUpDriver(SignUpDrivermodel signUpmodel)
        {
            TabDrivers tabDrivers = new TabDrivers();
             List<DetailsWithDriverToken> driver = new List<DetailsWithDriverToken>();
            var isServiceLocExist = context.TabServicelocation.Where(t => t.Servicelocid == signUpmodel.Servicelocationid && t.IsActive == 1 && t.IsDeleted == 0).FirstOrDefault();
            if (isServiceLocExist == null)
                return driver;
            var country = context.TabCountry.Where(t => t.CountryId == isServiceLocExist.Countryid && t.IsActive == true && t.IsDelete == false).FirstOrDefault();
            var Types = context.TabTypes.Where(t => t.Typeid == Convert.ToInt32(signUpmodel.Type) && t.IsActive == 1 && t.IsDeleted == 0).FirstOrDefault();
            var isDriverExist = context.TabDrivers.Where(t => t.ContactNo == signUpmodel.Mobileno).FirstOrDefault();
            if (country == null || isDriverExist != null || isServiceLocExist == null || Types == null)
                return driver;
            tabDrivers.FirstName = signUpmodel.FirstName;
            tabDrivers.LastName = signUpmodel.LastName;
            tabDrivers.Email = signUpmodel.Emailid;
            tabDrivers.ContactNo = signUpmodel.Mobileno;
            tabDrivers.Countryid = isServiceLocExist.Countryid;
            tabDrivers.Servicelocid = isServiceLocExist.Servicelocid;
            tabDrivers.Typeid = Types.Typeid;
            tabDrivers.Carnumber = signUpmodel.Car_number;
            tabDrivers.Carmodel = signUpmodel.Car_model;
            tabDrivers.LoginBy = signUpmodel.Login_by;
            tabDrivers.LoginMethod = signUpmodel.Login_method;
            tabDrivers.IsApproved = true;
            tabDrivers.IsAvailable = true;
            tabDrivers.OnlineStatus = true;
            tabDrivers.NationalId = signUpmodel.National_id;
            context.TabDrivers.Add(tabDrivers);
            context.SaveChanges();
            SignInmodel signInmodel = new SignInmodel();
            signInmodel.LoginBy = signUpmodel.Login_by;
            signInmodel.LoginMethod = signUpmodel.Login_method;
            signInmodel.Devicetoken = signUpmodel.Devicetoken;
            signInmodel.Contactno = signUpmodel.Mobileno;
            var tokenString = _token.GenerateJWTDriverTokenDtls(signInmodel);
            driver.Add(new DetailsWithDriverToken()
            {
                FirstName = tokenString[0].FirstName,
                LastName = tokenString[0].LastName,
                Mobileno = tokenString[0].Mobileno,
                Emailid = tokenString[0].Emailid,
                Id = tabDrivers.Driverid,
                Login_by = tabDrivers.LoginBy,
                Login_method = tabDrivers.LoginMethod,
                Token = tokenString[0].Token,
                Is_approve = tabDrivers.IsApproved,
                Is_available = tabDrivers.IsAvailable,
                Car_model = tabDrivers.Carmodel,
                Car_number = tabDrivers.Carnumber,
                RefreshToken = tokenString[0].RefreshToken,
                Type = Types.Typename,
                IsExist = 1,
                IsActive = tabDrivers.IsActive,
                Servicelocationid = tabDrivers.Serviceloc.Servicelocid,
                National_id=tabDrivers.NationalId
            });
            return driver;
            
        }

    }
}
 
