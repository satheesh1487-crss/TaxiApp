using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_promo")]
    public partial class TabPromo
    {
        [Key]
        [Column("promoid")]
        public long Promoid { get; set; }
        [Required]
        [Column("Coupon_code")]
        [StringLength(300)]
        public string CouponCode { get; set; }
        [Column("promo_estimate_amount")]
        public double? PromoEstimateAmount { get; set; }
        [Column("promo_value")]
        public long? PromoValue { get; set; }
        [Column("zoneid")]
        public long? Zoneid { get; set; }
        [Column("promo_type")]
        [StringLength(100)]
        public string PromoType { get; set; }
        [Column("promo_uses")]
        public long? PromoUses { get; set; }
        [Column("promo_users_repeateduse")]
        public long? PromoUsersRepeateduse { get; set; }
        [Column("start_date", TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column("end_date", TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("isDelete")]
        public bool? IsDelete { get; set; }
        [Column("created_by")]
        [StringLength(300)]
        public string CreatedBy { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_by")]
        [StringLength(300)]
        public string UpdatedBy { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_by")]
        [StringLength(300)]
        public string DeletedBy { get; set; }
        [Column("deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(Zoneid))]
        [InverseProperty(nameof(TabZone.TabPromo))]
        public virtual TabZone Zone { get; set; }
    }
}
