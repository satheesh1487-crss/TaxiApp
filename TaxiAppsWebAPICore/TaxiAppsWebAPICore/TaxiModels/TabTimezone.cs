using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_timezone")]
    public partial class TabTimezone
    {
        public TabTimezone()
        {
            TabAdmin = new HashSet<TabAdmin>();
            TabUser = new HashSet<TabUser>();
        }

        [Key]
        [Column("timezoneid")]
        public long Timezoneid { get; set; }
        [Column("countryid")]
        public long? Countryid { get; set; }
        [Column("zonedescription")]
        [StringLength(200)]
        public string Zonedescription { get; set; }
        public int? IsActive { get; set; }
        [Column("isDelete")]
        public int? IsDelete { get; set; }
        [Column("created_By")]
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [Column("Created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_by")]
        [StringLength(200)]
        public string UpdatedBy { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_by")]
        [StringLength(200)]
        public string DeletedBy { get; set; }
        [Column("deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(Countryid))]
        [InverseProperty(nameof(TabCountry.TabTimezone))]
        public virtual TabCountry Country { get; set; }
        [InverseProperty("ZoneAccess1")]
        public virtual ICollection<TabAdmin> TabAdmin { get; set; }
        [InverseProperty("Timezone")]
        public virtual ICollection<TabUser> TabUser { get; set; }
    }
}
