using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiAppsWebAPICore.Models
{
    public class LoggedInUser
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string RoleName { get; set; }

        public string Email { get; set; }

    }
}
