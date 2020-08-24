using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabManageEmail
    {
        public TabManageEmail()
        {
            TabManageEmailHints = new HashSet<TabManageEmailHints>();
        }

        public long ManageEmailid { get; set; }
        public string Emailtitle { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<TabManageEmailHints> TabManageEmailHints { get; set; }
    }
}
