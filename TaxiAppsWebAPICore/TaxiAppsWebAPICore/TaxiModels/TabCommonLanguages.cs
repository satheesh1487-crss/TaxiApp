using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabCommonLanguages
    {
        public TabCommonLanguages()
        {
            TabAdmin = new HashSet<TabAdmin>();
        }

        public int Languageid { get; set; }
        public string ShortLang { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<TabAdmin> TabAdmin { get; set; }
    }
}
