using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.Interface;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.DALayer
{
    public class DAUserValidate : IValidate
    {
       private readonly  TaxiAppzDBContext context;
        public DAUserValidate(TaxiAppzDBContext _context)
        {
            context = _context;
        }
        public bool MobileValidation(SignInmodel signinmodel)
        {
            var isUserExist = context.TabUser.Where(t => t.PhoneNumber == signinmodel.Contactno && t.IsDelete == 0 && t.IsActive == 1).FirstOrDefault();
            return isUserExist != null ? true : false;
        }
    }
}
