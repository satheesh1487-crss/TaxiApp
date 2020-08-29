using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_Document_ApporvalStatus")]
    public partial class TabDocumentApporvalStatus
    {
        public TabDocumentApporvalStatus()
        {
            TabDriverDocuments = new HashSet<TabDriverDocuments>();
        }

        [Key]
        [Column("Doc_ApprovalID")]
        public long DocApprovalId { get; set; }
        [Column("Doc_Status")]
        [StringLength(300)]
        public string DocStatus { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }

        [InverseProperty("DocApproval")]
        public virtual ICollection<TabDriverDocuments> TabDriverDocuments { get; set; }
    }
}
