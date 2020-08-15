using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_Driver_Documents")]
    public partial class TabDriverDocuments
    {
        [Key]
        [Column("DriverDoc_id")]
        public long DriverDocId { get; set; }
        public long? Driverid { get; set; }
        public long? Documentid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpireDate { get; set; }
        [Column("Uploaded_FileName")]
        [StringLength(300)]
        public string UploadedFileName { get; set; }
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

        [ForeignKey(nameof(Documentid))]
        [InverseProperty(nameof(TabManageDocument.TabDriverDocuments))]
        public virtual TabManageDocument Document { get; set; }
        [ForeignKey(nameof(Driverid))]
        [InverseProperty(nameof(TabDrivers.TabDriverDocuments))]
        public virtual TabDrivers Driver { get; set; }
    }
}
