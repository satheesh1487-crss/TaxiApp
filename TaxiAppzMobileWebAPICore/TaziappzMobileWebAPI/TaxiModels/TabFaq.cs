using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_FAQ")]
    public partial class TabFaq
    {
        [Key]
        [Column("FAQid")]
        public long Faqid { get; set; }
        [Column("servicelocid")]
        public long? Servicelocid { get; set; }
        [Required]
        [Column("FAQ_Question")]
        [StringLength(600)]
        public string FaqQuestion { get; set; }
        [Required]
        [Column("FAQ_Answer")]
        [StringLength(1000)]
        public string FaqAnswer { get; set; }
        [Column("Complaint_Type")]
        [StringLength(200)]
        public string ComplaintType { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("isDelete")]
        public bool? IsDelete { get; set; }
        [Column("Created_by")]
        [StringLength(300)]
        public string CreatedBy { get; set; }
        [Column("Created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_by")]
        [StringLength(300)]
        public string UpdatedBy { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("Deleted_by")]
        [StringLength(300)]
        public string DeletedBy { get; set; }
        [Column("Deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(Servicelocid))]
        [InverseProperty(nameof(TabServicelocation.TabFaq))]
        public virtual TabServicelocation Serviceloc { get; set; }
    }
}
