using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabDriverBonus
    {
        public long Driverbonusid { get; set; }
        public long? Driverid { get; set; }
        public double? Bonusamount { get; set; }
        public string BonusReason { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string Createdby { get; set; }
        public DateTime? Createdat { get; set; }
        public string Updatedby { get; set; }
        public DateTime? Updatedat { get; set; }
        public string Deletedby { get; set; }
        public DateTime? Deletedat { get; set; }

        public virtual TabDrivers Driver { get; set; }
    }
}
