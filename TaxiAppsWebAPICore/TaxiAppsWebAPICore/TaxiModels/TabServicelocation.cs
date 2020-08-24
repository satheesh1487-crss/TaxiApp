using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabServicelocation
    {
        public TabServicelocation()
        {
            TabAdmin = new HashSet<TabAdmin>();
            TabDrivers = new HashSet<TabDrivers>();
            TabFaq = new HashSet<TabFaq>();
            TabZone = new HashSet<TabZone>();
        }

        public long Servicelocid { get; set; }
        public string Name { get; set; }
        public long? Countryid { get; set; }
        public long? Currencyid { get; set; }
        public long? Timezoneid { get; set; }
        public int? IsActive { get; set; }
        public int? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TabCountry Country { get; set; }
        public virtual TabCommonCurrency Currency { get; set; }
        public virtual TabTimezone Timezone { get; set; }
        public virtual ICollection<TabAdmin> TabAdmin { get; set; }
        public virtual ICollection<TabDrivers> TabDrivers { get; set; }
        public virtual ICollection<TabFaq> TabFaq { get; set; }
        public virtual ICollection<TabZone> TabZone { get; set; }
    }
}
