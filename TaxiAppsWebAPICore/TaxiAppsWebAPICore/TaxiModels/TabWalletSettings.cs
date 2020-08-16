using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_wallet_settings")]
    public partial class TabWalletSettings
    {
        [Key]
        [Column("trip_wallet_id")]
        public int TripWalletId { get; set; }
        [Required]
        [Column("trip_wallet_question")]
        [StringLength(300)]
        public string TripWalletQuestion { get; set; }
        [Column("trip_wallet_answer")]
        [StringLength(500)]
        public string TripWalletAnswer { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
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
    }
}
