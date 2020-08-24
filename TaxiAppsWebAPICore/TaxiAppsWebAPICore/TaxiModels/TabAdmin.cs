using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabAdmin
    {
        public TabAdmin()
        {
            TabAdminDetails = new HashSet<TabAdminDetails>();
            TabAdminDocument = new HashSet<TabAdminDocument>();
            TabRefreshtoken = new HashSet<TabRefreshtoken>();
        }

        public long Id { get; set; }
        public string AdminKey { get; set; }
        public int? AdminReference { get; set; }
        public long? AreaName { get; set; }
        public int? Language { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string RegistrationCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyNumber { get; set; }
        public string RememberToken { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? IsActive { get; set; }
        public long? Role { get; set; }
        public string ProfilePic { get; set; }
        public long? ZoneAccess { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? IsDeleted { get; set; }
        public string DeletedBy { get; set; }

        public virtual TabServicelocation AreaNameNavigation { get; set; }
        public virtual TabCommonLanguages LanguageNavigation { get; set; }
        public virtual TabRoles RoleNavigation { get; set; }
        public virtual TabTimezone ZoneAccess1 { get; set; }
        public virtual TabCountry ZoneAccessNavigation { get; set; }
        public virtual ICollection<TabAdminDetails> TabAdminDetails { get; set; }
        public virtual ICollection<TabAdminDocument> TabAdminDocument { get; set; }
        public virtual ICollection<TabRefreshtoken> TabRefreshtoken { get; set; }
    }
}
