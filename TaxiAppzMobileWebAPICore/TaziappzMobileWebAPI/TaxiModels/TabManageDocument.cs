using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_ManageDocument")]
    public partial class TabManageDocument
    {
        public TabManageDocument()
        {
            TabDriverDocuments = new HashSet<TabDriverDocuments>();
        }

        [Key]
        [Column("DocumentID")]
        public long DocumentId { get; set; }
        [Column("Document_Name")]
        [StringLength(100)]
        public string DocumentName { get; set; }
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

        [InverseProperty("Document")]
        public virtual ICollection<TabDriverDocuments> TabDriverDocuments { get; set; }
    }
}
