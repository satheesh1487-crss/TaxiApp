using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabCountry
    {
        public TabCountry()
        {
            TabAdmin = new HashSet<TabAdmin>();
            TabAdminDetails = new HashSet<TabAdminDetails>();
            TabCurrencies = new HashSet<TabCurrencies>();
            TabDrivers = new HashSet<TabDrivers>();
            TabServicelocation = new HashSet<TabServicelocation>();
            TabTimezone = new HashSet<TabTimezone>();
            TabUser = new HashSet<TabUser>();
        }

        public long CountryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string DCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }

        public virtual ICollection<TabAdmin> TabAdmin { get; set; }
        public virtual ICollection<TabAdminDetails> TabAdminDetails { get; set; }
        public virtual ICollection<TabCurrencies> TabCurrencies { get; set; }
        public virtual ICollection<TabDrivers> TabDrivers { get; set; }
        public virtual ICollection<TabServicelocation> TabServicelocation { get; set; }
        public virtual ICollection<TabTimezone> TabTimezone { get; set; }
        public virtual ICollection<TabUser> TabUser { get; set; }
    }
}
