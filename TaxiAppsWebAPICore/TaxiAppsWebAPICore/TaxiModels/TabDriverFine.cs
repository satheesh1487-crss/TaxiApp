using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabDriverFine
    {
        public long Driverfineid { get; set; }
        public long? Driverid { get; set; }
        public double? Fineamount { get; set; }
        public string FineReason { get; set; }
        public bool? FinepaidStatus { get; set; }
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
