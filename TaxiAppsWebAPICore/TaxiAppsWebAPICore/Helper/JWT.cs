using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppsWebAPICore.Helper
{
    public class JWT
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public Double AccessTokenDuration { get; set; }
        public Double RefreshTokenDuration { get; set; }
    }
}
