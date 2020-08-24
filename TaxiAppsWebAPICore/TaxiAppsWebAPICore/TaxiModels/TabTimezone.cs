using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabTimezone
    {
        public TabTimezone()
        {
            TabAdmin = new HashSet<TabAdmin>();
            TabServicelocation = new HashSet<TabServicelocation>();
            TabUser = new HashSet<TabUser>();
        }

        public long Timezoneid { get; set; }
        public long? Countryid { get; set; }
        public string Zonedescription { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TabCountry Country { get; set; }
        public virtual ICollection<TabAdmin> TabAdmin { get; set; }
        public virtual ICollection<TabServicelocation> TabServicelocation { get; set; }
        public virtual ICollection<TabUser> TabUser { get; set; }
    }
}
