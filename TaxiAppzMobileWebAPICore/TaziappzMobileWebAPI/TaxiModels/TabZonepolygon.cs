using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_zonepolygon")]
    public partial class TabZonepolygon
    {
        [Key]
        [Column("zonepolygonid")]
        public long Zonepolygonid { get; set; }
        [Column("zoneid")]
        public long? Zoneid { get; set; }
        [Column("latitudes", TypeName = "decimal(8, 6)")]
        public decimal? Latitudes { get; set; }
        [Column("longitudes", TypeName = "decimal(9, 6)")]
        public decimal? Longitudes { get; set; }
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

        [ForeignKey(nameof(Zoneid))]
        [InverseProperty(nameof(TabZone.TabZonepolygon))]
        public virtual TabZone Zone { get; set; }
    }
}
