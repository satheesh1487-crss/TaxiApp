using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabSurgeprice
    {
        public long SurgepriceId { get; set; }
        public long? ZoneId { get; set; }
        public string SurgepriceType { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string PeakType { get; set; }
        public double? SurgepriceValue { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TabZone Zone { get; set; }
    }
}
