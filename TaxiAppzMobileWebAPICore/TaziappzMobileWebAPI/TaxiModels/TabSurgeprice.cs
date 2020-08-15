using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_surgeprice")]
    public partial class TabSurgeprice
    {
        [Key]
        [Column("surgeprice_id")]
        public long SurgepriceId { get; set; }
        [Column("zone_id")]
        public long? ZoneId { get; set; }
        [Column("surgeprice_type")]
        [StringLength(200)]
        public string SurgepriceType { get; set; }
        [Column("start_time")]
        [StringLength(10)]
        public string StartTime { get; set; }
        [Column("end_time")]
        [StringLength(10)]
        public string EndTime { get; set; }
        [Column("peak_type")]
        [StringLength(100)]
        public string PeakType { get; set; }
        [Column("surgeprice_value")]
        public double? SurgepriceValue { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("isDelete")]
        public bool? IsDelete { get; set; }
        [Column("created_by")]
        [StringLength(300)]
        public string CreatedBy { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_by")]
        [StringLength(300)]
        public string UpdatedBy { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_by")]
        [StringLength(300)]
        public string DeletedBy { get; set; }
        [Column("deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(ZoneId))]
        [InverseProperty(nameof(TabZone.TabSurgeprice))]
        public virtual TabZone Zone { get; set; }
    }
}
