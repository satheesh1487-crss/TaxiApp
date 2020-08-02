using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_zonetype_relationship")]
    public partial class TabZonetypeRelationship
    {
        public TabZonetypeRelationship()
        {
            TabDriverCancellation = new HashSet<TabDriverCancellation>();
            TabSetpriceZonetype = new HashSet<TabSetpriceZonetype>();
            TabUserCancellation = new HashSet<TabUserCancellation>();
        }

        [Key]
        [Column("zonetypeid")]
        public long Zonetypeid { get; set; }
        [Column("zoneid")]
        public long? Zoneid { get; set; }
        [Column("typeid")]
        public long? Typeid { get; set; }
        [Required]
        [Column("paymentmode")]
        [StringLength(200)]
        public string Paymentmode { get; set; }
        [Column("showbill")]
        public bool? Showbill { get; set; }
        [Column("isDefault")]
        public int? IsDefault { get; set; }
        [Column("created_by")]
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("isActive")]
        public int? IsActive { get; set; }
        [Column("isDelete")]
        public int? IsDelete { get; set; }
        [Column("updated_by")]
        [StringLength(100)]
        public string UpdatedBy { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_by")]
        [StringLength(100)]
        public string DeletedBy { get; set; }
        [Column("deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(Typeid))]
        [InverseProperty(nameof(TabTypes.TabZonetypeRelationship))]
        public virtual TabTypes Type { get; set; }
        [ForeignKey(nameof(Zoneid))]
        [InverseProperty(nameof(TabZone.TabZonetypeRelationship))]
        public virtual TabZone Zone { get; set; }
        [InverseProperty("Zonetype")]
        public virtual ICollection<TabDriverCancellation> TabDriverCancellation { get; set; }
        [InverseProperty("Zonetype")]
        public virtual ICollection<TabSetpriceZonetype> TabSetpriceZonetype { get; set; }
        [InverseProperty("Zonetype")]
        public virtual ICollection<TabUserCancellation> TabUserCancellation { get; set; }
    }
}
