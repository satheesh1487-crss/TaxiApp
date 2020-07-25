using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_zone")]
    public partial class TabZone
    {
        public TabZone()
        {
            TabZonepolygon = new HashSet<TabZonepolygon>();
        }

        [Key]
        [Column("zoneid")]
        public long Zoneid { get; set; }
        [Required]
        [Column("zonename")]
        [StringLength(200)]
        public string Zonename { get; set; }
        [Column("servicelocid")]
        public long? Servicelocid { get; set; }
        [Column("unit")]
        [StringLength(50)]
        public string Unit { get; set; }
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

        [ForeignKey(nameof(Servicelocid))]
        [InverseProperty(nameof(TabServicelocation.TabZone))]
        public virtual TabServicelocation Serviceloc { get; set; }
        [InverseProperty("Zone")]
        public virtual ICollection<TabZonepolygon> TabZonepolygon { get; set; }
    }
}
