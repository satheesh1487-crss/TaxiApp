using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_request_rating")]
    public partial class TabRequestRating
    {
        [Key]
        [Column("rating_id")]
        public long RatingId { get; set; }
        [Column("user_id")]
        public long? UserId { get; set; }
        [Column("driver_id")]
        public long? DriverId { get; set; }
        [Column("rating_by")]
        [StringLength(20)]
        public string RatingBy { get; set; }
        [Column("comments")]
        [StringLength(500)]
        public string Comments { get; set; }
        [Column("request_id")]
        public long? RequestId { get; set; }
        [Column("user_rating")]
        public double? UserRating { get; set; }
        [Column("driver_rating")]
        public double? DriverRating { get; set; }
        [Column("created_by")]
        [StringLength(300)]
        public string CreatedBy { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }

        [ForeignKey(nameof(DriverId))]
        [InverseProperty(nameof(TabDrivers.TabRequestRating))]
        public virtual TabDrivers Driver { get; set; }
        [ForeignKey(nameof(RequestId))]
        [InverseProperty(nameof(TabRequest.TabRequestRating))]
        public virtual TabRequest Request { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(TabUser.TabRequestRating))]
        public virtual TabUser User { get; set; }
    }
}
