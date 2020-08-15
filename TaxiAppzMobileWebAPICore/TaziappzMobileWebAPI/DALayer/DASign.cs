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
        public DASign(TaxiAppzDBContext _context,IToken token)
        {
            context = _context;
            _token = token;
        }
        public DetailsWithToken SignIn(SignInmodel signInmodel)
        {
            //TabUser tabUser = new TabUser();
            DetailsWithToken user = new DetailsWithToken();
            var tabusers = context.TabUser.Where(t => t.PhoneNumber == signInmodel.Contactno && t.IsActive == 1 && t.IsDelete == 0).FirstOrDefault();
            if(tabusers != null)
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
                    mobileno = tokenString.mobileno,
                    MailID = tokenString.MailID,
                    AccessToken = tokenString.AccessToken,
                    RefreshToken = tokenString.RefreshToken,
                    IsExist = tokenString.IsExist,
                    IsActive=tokenString.IsActive

                };
                return user;
            }
            user.IsExist = 0;
             return user;
        }
      //  public DetailsWithToken RegisterUser(SignUpmodel signUpmodel)
     //   {
           // TabUser tabUser = new TabUser();
            //DetailsWithToken user = new DetailsWithToken();
            //var tabusers = context.TabUser.Where(t => t.PhoneNumber == signInmodel.Contactno && t.IsActive == 1 && t.IsDelete == 0).FirstOrDefault();
            //if (tabusers != null)
            //{
            //    tabUser.LoginBy = signInmodel.LoginBy;
            //    tabUser.LoginMethod = signInmodel.LoginMethod;
            //    tabUser.DeviceToken = signInmodel.Devicetoken;
            //    context.TabUser.Update(tabUser);
            //    context.SaveChanges();
            //    var tokenString = _token.GenerateJWTTokenDtls(signInmodel);
            //    user = new DetailsWithToken()
            //    {
            //        FirstName = tokenString.FirstName,
            //        LastName = tokenString.LastName,
            //        mobileno = tokenString.mobileno,
            //        MailID = tokenString.MailID,
            //        AccessToken = tokenString.AccessToken,
            //        RefreshToken = tokenString.RefreshToken,
            //        Status = "User Data Found"
            //    };
            //    return user;
            //}
            //user.Status = "Details Not Found";
            //return user;
       // }
    }
}
