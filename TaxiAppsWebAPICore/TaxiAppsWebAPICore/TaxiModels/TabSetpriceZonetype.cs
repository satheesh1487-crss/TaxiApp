using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_setprice_zonetype")]
    public partial class TabSetpriceZonetype
    {
        [Key]
        [Column("setpriceid")]
        public long Setpriceid { get; set; }
        [Column("zonetypeid")]
        public long? Zonetypeid { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? Baseprice { get; set; }
        [Column("pricepertime", TypeName = "decimal(8, 2)")]
        public decimal? Pricepertime { get; set; }
        [Column("basedistance")]
        public long Basedistance { get; set; }
        [Column("priceperdistance", TypeName = "decimal(8, 2)")]
        public decimal? Priceperdistance { get; set; }
        [Column("freewaitingtime")]
        public long Freewaitingtime { get; set; }
        [Column("waitingcharges", TypeName = "decimal(8, 2)")]
        public decimal? Waitingcharges { get; set; }
        [Column("cancellationfee", TypeName = "decimal(8, 2)")]
        public decimal? Cancellationfee { get; set; }
        [Column("dropfee", TypeName = "decimal(8, 2)")]
        public decimal? Dropfee { get; set; }
        [Column("admincommtype")]
        [StringLength(100)]
        public string Admincommtype { get; set; }
        [Column("admincommission", TypeName = "decimal(8, 2)")]
        public decimal? Admincommission { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? Driversavingper { get; set; }
        [Column("customseldrifee", TypeName = "decimal(8, 2)")]
        public decimal? Customseldrifee { get; set; }
        [StringLength(50)]
        public string RideType { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("isDelete")]
        public bool? IsDelete { get; set; }
        [Column("Created_by")]
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [Column("created_at", TypeName = "datetime")]
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

        [ForeignKey(nameof(Zonetypeid))]
        [InverseProperty(nameof(TabZonetypeRelationship.TabSetpriceZonetype))]
        public virtual TabZonetypeRelationship Zonetype { get; set; }
    }
}
