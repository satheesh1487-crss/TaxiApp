using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.Interface;

namespace TaziappzMobileWebAPI.Helper
{
    public class MobileNumValidate
    {
        public static void validatecontactno(IValidate validate)
        {
            SignInmodel signInmodel = new SignInmodel();
            validate.MobileValidation(signInmodel);
        }
    }
}
