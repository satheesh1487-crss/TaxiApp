using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.Interface;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.DALayer
{
    public class DADriverValidate : IValidate
    {
        private readonly TaxiAppzDBContext context;
        public DADriverValidate(TaxiAppzDBContext _context)
        {
            context = _context;
        }
        public bool MobileValidation(SignInmodel signinmodel)
        {
            var isUserExist = context.TabDrivers.Where(t => t.ContactNo == signinmodel.Contactno && t.IsDelete == false && t.IsActive == true ).FirstOrDefault();
            return isUserExist != null ? true : false;
        }
    }
}
