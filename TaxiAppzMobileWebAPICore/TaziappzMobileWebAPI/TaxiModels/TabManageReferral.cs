using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_Manage_Referral")]
    public partial class TabManageReferral
    {
        [Key]
        public long Managereferral { get; set; }
        [Column("ReferralWorth_Amount", TypeName = "decimal(8, 2)")]
        public decimal? ReferralWorthAmount { get; set; }
        [Column("ReferralGain_Amount_PerPerson", TypeName = "decimal(8, 2)")]
        public decimal? ReferralGainAmountPerPerson { get; set; }
        [Column("Trip_to_completed_torefer")]
        public int? TripToCompletedTorefer { get; set; }
        [Column("Trip_to_completed_toearn_refferalAmount", TypeName = "decimal(8, 2)")]
        public decimal? TripToCompletedToearnRefferalAmount { get; set; }
        [Column("Created_by")]
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [Column("Created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("Updated_by")]
        [StringLength(200)]
        public string UpdatedBy { get; set; }
        [Column("Updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
    }
}
