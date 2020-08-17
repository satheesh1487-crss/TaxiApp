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
        public DetailsWithToken SignIn(SignInmodel signInmodel)
        {
            //TabUser tabUser = new TabUser();
            DetailsWithToken user = new DetailsWithToken();
            var tabusers = context.TabUser.Where(t => t.PhoneNumber == signInmodel.Contactno && t.IsActive == 1 && t.IsDelete == 0).FirstOrDefault();
            if (tabusers != null)
            {
                tabusers.LoginBy = signInmodel.LoginBy;
                tabusers.LoginMethod = signInmodel.LoginMethod;
                tabusers.DeviceToken = signInmodel.Devicetoken;
                context.TabUser.Update(tabusers);
                context.SaveChanges();
                var tokenString = _token.GenerateJWTTokenDtls(signInmodel);
                user = new DetailsWithToken()
                {
                    FirstName = tokenString.FirstName,
                    LastName = tokenString.LastName,
                    Mobileno = tokenString.Mobileno,
                    Emailid = tokenString.Emailid,
                    AccessToken = tokenString.AccessToken,
                    RefreshToken = tokenString.RefreshToken,
                    IsExist = tokenString.IsExist,
                    IsActive = tokenString.IsActive

                };
                return user;
            }
            user.IsExist = 0;
            return user;
        }
        public bool SignUp(SignUpmodel signUpmodel)
        {
            TabUser tabUser = new TabUser();
            DetailsWithToken detailsWithToken = new DetailsWithToken();
            var timezone = context.TabTimezone.Where(t => t.Timezoneid == signUpmodel.Timezone && t.IsActive == 1 && t.IsDelete == 0).FirstOrDefault();
            var country = context.TabCountry.Where(t => t.CountryId == signUpmodel.countryid && t.IsActive == true && t.IsDelete == false).FirstOrDefault();
            var isUserExist = context.TabUser.Where(t => t.PhoneNumber == signUpmodel.Mobileno).FirstOrDefault();
            var isServiceLocExist = context.TabServicelocation.Where(t => t.Countryid == signUpmodel.countryid && t.Timezoneid == signUpmodel.Timezone && t.IsActive == 1 && t.IsDeleted == 0).FirstOrDefault();
            if (timezone == null || country == null || isUserExist != null || isServiceLocExist == null)
            {
                return false;
            }
            tabUser.Firstname = signUpmodel.FirstName;
            tabUser.Lastname = signUpmodel.LastName;
            tabUser.Email = signUpmodel.Emailid;
            tabUser.PhoneNumber = signUpmodel.Mobileno;
            tabUser.Countryid = signUpmodel.countryid;
            tabUser.Timezoneid = signUpmodel.Timezone;
            tabUser.Currencyid = isServiceLocExist.Currencyid;
            context.TabUser.Add(tabUser);
            context.SaveChanges();
            return true;
        }
    }
}
 
