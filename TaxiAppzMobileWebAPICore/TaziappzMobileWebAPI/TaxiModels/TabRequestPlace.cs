using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_request_place")]
    public partial class TabRequestPlace
    {
        [Key]
        [Column("request_place_id")]
        public long RequestPlaceId { get; set; }
        [Column("pick_latitude", TypeName = "decimal(8, 6)")]
        public decimal PickLatitude { get; set; }
        [Column("pick_longitude", TypeName = "decimal(9, 6)")]
        public decimal PickLongitude { get; set; }
        [Column("drop_latitude", TypeName = "decimal(8, 6)")]
        public decimal? DropLatitude { get; set; }
        [Column("drop_longitude", TypeName = "decimal(9, 6)")]
        public decimal? DropLongitude { get; set; }
        [Column("pick_location")]
        [StringLength(300)]
        public string PickLocation { get; set; }
        [Column("drop_location")]
        [StringLength(300)]
        public string DropLocation { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("isDelete")]
        public bool? IsDelete { get; set; }
        [Column("created_by")]
        [StringLength(400)]
        public string CreatedBy { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_by")]
        [StringLength(400)]
        public string UpdatedBy { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_by")]
        [StringLength(400)]
        public string DeletedBy { get; set; }
        [Column("deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }
    }
}
