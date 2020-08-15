using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI;
namespace TaziappzMobileWebAPI.Interface
{
   public  interface IValidate
    {
        public bool MobileValidation(SignInmodel signinmodel);
    }
}
