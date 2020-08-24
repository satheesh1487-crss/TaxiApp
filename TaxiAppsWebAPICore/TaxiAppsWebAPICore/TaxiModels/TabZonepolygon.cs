using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabZonepolygon
    {
        public long Zonepolygonid { get; set; }
        public long? Zoneid { get; set; }
        public decimal? Latitudes { get; set; }
        public decimal? Longitudes { get; set; }
        public int? IsActive { get; set; }
        public int? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TabZone Zone { get; set; }
    }
}
