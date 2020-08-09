using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_Admin_Document")]
    public partial class TabAdminDocument
    {
        [Key]
        [Column("admindocumentid")]
        public long Admindocumentid { get; set; }
        [Column("adminid")]
        public long? Adminid { get; set; }
        [Required]
        [Column("document_name")]
        [StringLength(300)]
        public string DocumentName { get; set; }
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

        [ForeignKey(nameof(Adminid))]
        [InverseProperty(nameof(TabAdmin.TabAdminDocument))]
        public virtual TabAdmin Admin { get; set; }
    }
}
