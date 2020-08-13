using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaziappzMobileWebAPI.Interface
{
   public interface ISign
    {
        public DetailsWithToken SignIn(SignInmodel signInmodel);
        public DetailsWithToken RegisterUser(SignUpmodel signUpmodel);
    }
}
