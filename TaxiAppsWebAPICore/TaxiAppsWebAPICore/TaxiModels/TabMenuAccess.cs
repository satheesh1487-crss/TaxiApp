using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabMenuAccess
    {
        public long Accessid { get; set; }
        public long? Menuid { get; set; }
        public long? Roleid { get; set; }
        public bool? Viewstatus { get; set; }
        public DateTime? Createdby { get; set; }
        public DateTime? Updatedby { get; set; }

        public virtual TabMenu Menu { get; set; }
        public virtual TabRoles Role { get; set; }
    }
}
