using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabManageSms
    {
        public TabManageSms()
        {
            TabManageSmsHints = new HashSet<TabManageSmsHints>();
        }

        public long ManageSmsid { get; set; }
        public string Smstitle { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<TabManageSmsHints> TabManageSmsHints { get; set; }
    }
}
