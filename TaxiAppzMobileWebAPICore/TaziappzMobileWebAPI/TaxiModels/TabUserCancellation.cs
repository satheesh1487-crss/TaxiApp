using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_User_cancellation")]
    public partial class TabUserCancellation
    {
        [Key]
        [Column("User_CancelId")]
        public long UserCancelId { get; set; }
        [Column("zonetypeid")]
        public long? Zonetypeid { get; set; }
        [Column("paymentstatus")]
        [StringLength(50)]
        public string Paymentstatus { get; set; }
        [Column("arrivalstatus")]
        [StringLength(100)]
        public string Arrivalstatus { get; set; }
        [Column("Cancellation_Reason_English")]
        [StringLength(400)]
        public string CancellationReasonEnglish { get; set; }
        [Column("Cancellation_Reason_Arabic")]
        [StringLength(400)]
        public string CancellationReasonArabic { get; set; }
        [Column("Cancellation_Reason_Spanish")]
        [StringLength(400)]
        public string CancellationReasonSpanish { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("isDelete")]
        public bool? IsDelete { get; set; }
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
        [Column("Deleted_by")]
        [StringLength(200)]
        public string DeletedBy { get; set; }
        [Column("Deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(Zonetypeid))]
        [InverseProperty(nameof(TabZonetypeRelationship.TabUserCancellation))]
        public virtual TabZonetypeRelationship Zonetype { get; set; }
    }
}
