using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabZonetypeRelationship
    {
        public TabZonetypeRelationship()
        {
            TabDriverCancellation = new HashSet<TabDriverCancellation>();
            TabSetpriceZonetype = new HashSet<TabSetpriceZonetype>();
            TabUserCancellation = new HashSet<TabUserCancellation>();
        }

        public long Zonetypeid { get; set; }
        public long? Zoneid { get; set; }
        public long? Typeid { get; set; }
        public string Paymentmode { get; set; }
        public bool? Showbill { get; set; }
        public int? IsDefault { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TabTypes Type { get; set; }
        public virtual TabZone Zone { get; set; }
        public virtual ICollection<TabDriverCancellation> TabDriverCancellation { get; set; }
        public virtual ICollection<TabSetpriceZonetype> TabSetpriceZonetype { get; set; }
        public virtual ICollection<TabUserCancellation> TabUserCancellation { get; set; }
    }
}
