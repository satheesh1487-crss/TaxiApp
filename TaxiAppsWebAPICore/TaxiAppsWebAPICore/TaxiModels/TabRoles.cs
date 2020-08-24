using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabRoles
    {
        public TabRoles()
        {
            TabAdmin = new HashSet<TabAdmin>();
            TabMenuAccess = new HashSet<TabMenuAccess>();
        }

        public long Roleid { get; set; }
        public string RoleName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int? AllRights { get; set; }
        public int? Locked { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? IsActive { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public int? IsDelete { get; set; }

        public virtual ICollection<TabAdmin> TabAdmin { get; set; }
        public virtual ICollection<TabMenuAccess> TabMenuAccess { get; set; }
    }
}
