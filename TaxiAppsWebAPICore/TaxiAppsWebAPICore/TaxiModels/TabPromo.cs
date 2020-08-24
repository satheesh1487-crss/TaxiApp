using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabPromo
    {
        public long Promoid { get; set; }
        public string CouponCode { get; set; }
        public double? PromoEstimateAmount { get; set; }
        public long? PromoValue { get; set; }
        public long? Zoneid { get; set; }
        public string PromoType { get; set; }
        public long? PromoUses { get; set; }
        public long? PromoUsersRepeateduse { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
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
