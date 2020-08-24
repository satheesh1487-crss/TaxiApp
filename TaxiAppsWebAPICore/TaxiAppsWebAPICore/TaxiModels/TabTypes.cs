using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabTypes
    {
        public TabTypes()
        {
            TabDrivers = new HashSet<TabDrivers>();
            TabRequest = new HashSet<TabRequest>();
            TabZonetypeRelationship = new HashSet<TabZonetypeRelationship>();
        }

        public long Typeid { get; set; }
        public string Typename { get; set; }
        public string Imagename { get; set; }
        public int? IsActive { get; set; }
        public int? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<TabDrivers> TabDrivers { get; set; }
        public virtual ICollection<TabRequest> TabRequest { get; set; }
        public virtual ICollection<TabZonetypeRelationship> TabZonetypeRelationship { get; set; }
    }
}
