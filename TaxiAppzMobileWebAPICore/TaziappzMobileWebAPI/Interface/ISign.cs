using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Interface
{
   public interface ISign
    {
        public DetailsWithToken SignIn(SignInmodel signInmodel);
        public List<DetailsWithDriverToken> SignInDriver(SignInmodel signInmodel);
        public List<DetailsWithToken> SignUp(SignUpmodel signUpmodel);
        public bool SignUpDriver(SignUpDrivermodel signUpmodel);
        
        //  public DetailsWithToken RegisterUser(SignUpmodel signUpmodel);
    }
}
