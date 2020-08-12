using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore;
using TaxiAppsWebAPICore.Models;

namespace TaxiAppsWebAPICore.Services
{
   public interface IToken
    {
        UserInfo GenerateJWTTokenDtls(LoginRequest loginRequest);
        UserInfo ReGenerateJWTTokenDtls(string refreshtoken,string mailid);
    }
}
