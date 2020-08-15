using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_User_Complaint")]
    public partial class TabUserComplaint
    {
        [Key]
        [Column("User_ComplaintID")]
        public long UserComplaintId { get; set; }
        [Column("zoneid")]
        public long? Zoneid { get; set; }
        [Column("UserComplaint_type")]
        [StringLength(100)]
        public string UserComplaintType { get; set; }
        [Column("UserComplaint_title")]
        [StringLength(400)]
        public string UserComplaintTitle { get; set; }
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

        [ForeignKey(nameof(Zoneid))]
        [InverseProperty(nameof(TabZone.TabUserComplaint))]
        public virtual TabZone Zone { get; set; }
    }
}
