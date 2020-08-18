using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Interface
{
   public interface ISign
    {
        public List<DetailsWithToken> SignIn(SignInmodel signInmodel,string Access);
        public bool SignUp(SignUpmodel signUpmodel);
        //  public DetailsWithToken RegisterUser(SignUpmodel signUpmodel);
    }
}
