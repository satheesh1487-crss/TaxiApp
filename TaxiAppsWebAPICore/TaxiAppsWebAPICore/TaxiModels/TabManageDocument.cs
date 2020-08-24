using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabManageDocument
    {
        public TabManageDocument()
        {
            TabDriverDocuments = new HashSet<TabDriverDocuments>();
        }

        public long DocumentId { get; set; }
        public string DocumentName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<TabDriverDocuments> TabDriverDocuments { get; set; }
    }
}
