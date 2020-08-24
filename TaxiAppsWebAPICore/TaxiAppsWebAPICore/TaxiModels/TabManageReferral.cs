using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabManageReferral
    {
        public long Managereferral { get; set; }
        public decimal? ReferralWorthAmount { get; set; }
        public decimal? ReferralGainAmountPerPerson { get; set; }
        public int? TripToCompletedTorefer { get; set; }
        public decimal? TripToCompletedToearnRefferalAmount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsActive { get; set; }
    }
}
