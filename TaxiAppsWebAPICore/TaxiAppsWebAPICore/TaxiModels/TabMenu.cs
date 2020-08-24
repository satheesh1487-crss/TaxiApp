using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabMenu
    {
        public TabMenu()
        {
            TabMenuAccess = new HashSet<TabMenuAccess>();
        }

        public long Menuid { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public bool? IsActive { get; set; }
        public string Menukey { get; set; }

        public virtual ICollection<TabMenuAccess> TabMenuAccess { get; set; }
    }
}
