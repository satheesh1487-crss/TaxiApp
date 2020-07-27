using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_servicelocation")]
    public partial class TabServicelocation
    {
        public TabServicelocation()
        {
            TabAdmin = new HashSet<TabAdmin>();
            TabZone = new HashSet<TabZone>();
        }

        [Key]
        [Column("servicelocid")]
        public long Servicelocid { get; set; }
        [StringLength(300)]
        public string Name { get; set; }
        [Column("countryid")]
        public long? Countryid { get; set; }
        [Column("currencyid")]
        public long? Currencyid { get; set; }
        [Column("timezoneid")]
        public long? Timezoneid { get; set; }
        [Column("isActive")]
        public int? IsActive { get; set; }
        [Column("isDeleted")]
        public int? IsDeleted { get; set; }
        [Column("Created_by")]
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column("Created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("Updated_by")]
        [StringLength(100)]
        public string UpdatedBy { get; set; }
        [Column("Updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("Deleted_by")]
        [StringLength(100)]
        public string DeletedBy { get; set; }
        [Column("Deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(Countryid))]
        [InverseProperty(nameof(TabCountry.TabServicelocation))]
        public virtual TabCountry Country { get; set; }
        [ForeignKey(nameof(Currencyid))]
        [InverseProperty(nameof(TabCommonCurrency.TabServicelocation))]
        public virtual TabCommonCurrency Currency { get; set; }
        [ForeignKey(nameof(Timezoneid))]
        [InverseProperty(nameof(TabTimezone.TabServicelocation))]
        public virtual TabTimezone Timezone { get; set; }
        [InverseProperty("AreaNameNavigation")]
        public virtual ICollection<TabAdmin> TabAdmin { get; set; }
        [InverseProperty("Serviceloc")]
        public virtual ICollection<TabZone> TabZone { get; set; }
    }
}
