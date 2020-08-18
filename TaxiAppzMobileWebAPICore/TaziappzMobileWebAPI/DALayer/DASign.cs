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
        public List<DetailsWithToken> SignIn(SignInmodel signInmodel,string Access)
        {
            //TabUser tabUser = new TabUser();
            List<DetailsWithToken> user = new List<DetailsWithToken>();
            if (Access == "USER")
            {
                var tabusers = context.TabUser.Where(t => t.PhoneNumber == signInmodel.Contactno && t.IsActive == 1 && t.IsDelete == 0).FirstOrDefault();
                if (tabusers != null)
                {
                    tabusers.LoginBy = signInmodel.LoginBy;
                    tabusers.LoginMethod = signInmodel.LoginMethod;
                    tabusers.DeviceToken = signInmodel.Devicetoken;
                    context.TabUser.Update(tabusers);
                    context.SaveChanges();
                    var tokenString = _token.GenerateJWTTokenDtls(signInmodel,Access);
                    user.Add(new DetailsWithToken()
                    {
                        FirstName = tokenString[0].FirstName,
                        LastName = tokenString[0].LastName,
                        Mobileno = tokenString[0].Mobileno,
                        Emailid = tokenString[0].Emailid,
                        AccessToken = tokenString[0].AccessToken,
                        RefreshToken = tokenString[0].RefreshToken,
                        IsExist = tokenString[0].IsExist,
                        IsActive = tokenString[0].IsActive

                    });
                    return user;
                }
            }
            else
            {
                var tabDrivers = context.TabDrivers.Where(t => t.ContactNo == signInmodel.Contactno && t.IsActive == true && t.IsDelete == false).FirstOrDefault();
                if (tabDrivers != null)
                {
                    //tabDrivers.Lo = signInmodel.LoginBy;
                    //tabDrivers.LoginMethod = signInmodel.LoginMethod;
                    //tabDrivers.DeviceToken = signInmodel.Devicetoken;
                    //context.TabUser.Update(tabusers);
                    //context.SaveChanges();
                    var tokenString = _token.GenerateJWTTokenDtls(signInmodel, Access);
                    user.Add(new DetailsWithToken()
                    {
                        FirstName = tokenString[0].FirstName,
                        LastName = tokenString[0].LastName,
                        Mobileno = tokenString[0].Mobileno,
                        Emailid = tokenString[0].Emailid,
                        AccessToken = tokenString[0].AccessToken,
                        RefreshToken = tokenString[0].RefreshToken,
                        IsExist = tokenString[0].IsExist,
                        IsActive = tokenString[0].IsActive

                    });
                    return user;
                }
            }

          
            return user;
        }
        public bool SignUp(SignUpmodel signUpmodel)
        {
            TabUser tabUser = new TabUser();
            DetailsWithToken detailsWithToken = new DetailsWithToken();
            var isServiceLocExist = context.TabServicelocation.Where(t => t.Servicelocid == signUpmodel.Servicelocationid && t.IsActive == 1 && t.IsDeleted == 0).FirstOrDefault();
            if (isServiceLocExist == null)
                return false;
            var timezone = context.TabTimezone.Where(t => t.Timezoneid == isServiceLocExist.Timezoneid && t.IsActive == 1 && t.IsDelete == 0).FirstOrDefault();
            var country = context.TabCountry.Where(t => t.CountryId == isServiceLocExist.Countryid && t.IsActive == true && t.IsDelete == false).FirstOrDefault();
            var isUserExist = context.TabUser.Where(t => t.PhoneNumber == signUpmodel.Mobileno).FirstOrDefault();
            if (timezone == null || country == null || isUserExist != null || isServiceLocExist == null)
                 return false;
            tabUser.Firstname = signUpmodel.FirstName;
            tabUser.Lastname = signUpmodel.LastName;
            tabUser.Email = signUpmodel.Emailid;
            tabUser.PhoneNumber = signUpmodel.Mobileno;
            tabUser.Countryid = isServiceLocExist.Countryid;
            tabUser.Timezoneid = isServiceLocExist.Timezoneid;
            tabUser.Currencyid = isServiceLocExist.Currencyid;
            context.TabUser.Add(tabUser);
            context.SaveChanges();
            return true;
        }
    }
}
 
