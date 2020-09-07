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
        public DetailsWithToken SignUp(SignUpmodel signUpmodel);
        public List<DetailsWithDriverToken> SignUpDriver(SignUpDrivermodel signUpmodel);
        
        //  public DetailsWithToken RegisterUser(SignUpmodel signUpmodel);
    }
}
