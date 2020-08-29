using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_Driver_Complaint")]
    public partial class TabDriverComplaint
    {
        [Key]
        [Column("Driver_ComplaintID")]
        public long DriverComplaintId { get; set; }
        [Column("zoneid")]
        public long? Zoneid { get; set; }
        [Column("DriverComplaint_type")]
        [StringLength(100)]
        public string DriverComplaintType { get; set; }
        [Column("DriverComplaint_title")]
        [StringLength(400)]
        public string DriverComplaintTitle { get; set; }
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
        [InverseProperty(nameof(TabZone.TabDriverComplaint))]
        public virtual TabZone Zone { get; set; }
    }
}
