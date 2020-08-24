using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabZone
    {
        public TabZone()
        {
            TabDriverComplaint = new HashSet<TabDriverComplaint>();
            TabDrivers = new HashSet<TabDrivers>();
            TabPromo = new HashSet<TabPromo>();
            TabSurgeprice = new HashSet<TabSurgeprice>();
            TabUserComplaint = new HashSet<TabUserComplaint>();
            TabZonepolygon = new HashSet<TabZonepolygon>();
            TabZonetypeRelationship = new HashSet<TabZonetypeRelationship>();
        }

        public long Zoneid { get; set; }
        public string Zonename { get; set; }
        public long? Servicelocid { get; set; }
        public string Unit { get; set; }
        public int? IsActive { get; set; }
        public int? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TabServicelocation Serviceloc { get; set; }
        public virtual ICollection<TabDriverComplaint> TabDriverComplaint { get; set; }
        public virtual ICollection<TabDrivers> TabDrivers { get; set; }
        public virtual ICollection<TabPromo> TabPromo { get; set; }
        public virtual ICollection<TabSurgeprice> TabSurgeprice { get; set; }
        public virtual ICollection<TabUserComplaint> TabUserComplaint { get; set; }
        public virtual ICollection<TabZonepolygon> TabZonepolygon { get; set; }
        public virtual ICollection<TabZonetypeRelationship> TabZonetypeRelationship { get; set; }
    }
}
