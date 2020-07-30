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
        public double Baseprice { get; set; }
        [Column("pricepertime")]
        public double Pricepertime { get; set; }
        [Column("basedistance")]
        public long Basedistance { get; set; }
        [Column("priceperdistance")]
        public double Priceperdistance { get; set; }
        [Column("freewaitingtime")]
        public long Freewaitingtime { get; set; }
        [Column("waitingcharges")]
        public double Waitingcharges { get; set; }
        [Column("cancellationfee")]
        public double? Cancellationfee { get; set; }
        [Column("dropfee")]
        public double? Dropfee { get; set; }
        [Column("admincommtype")]
        [StringLength(100)]
        public string Admincommtype { get; set; }
        [Column("admincommission")]
        public double? Admincommission { get; set; }
        public double? Driversavingper { get; set; }
        [Column("customseldrifee")]
        public double? Customseldrifee { get; set; }
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
