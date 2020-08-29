using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_request_meta")]
    public partial class TabRequestMeta
    {
        [Key]
        [Column("meta_id")]
        public long MetaId { get; set; }
        [Column("Request_id")]
        public long? RequestId { get; set; }
        [Column("user_id")]
        public long? UserId { get; set; }
        [Column("driver_id")]
        public long? DriverId { get; set; }
        [Column("is_active")]
        public bool? IsActive { get; set; }
        [Column("assign_method")]
        [StringLength(100)]
        public string AssignMethod { get; set; }
        [Column("notification")]
        [StringLength(50)]
        public string Notification { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(DriverId))]
        [InverseProperty(nameof(TabDrivers.TabRequestMeta))]
        public virtual TabDrivers Driver { get; set; }
        [ForeignKey(nameof(RequestId))]
        [InverseProperty(nameof(TabRequest.TabRequestMeta))]
        public virtual TabRequest Request { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(TabUser.TabRequestMeta))]
        public virtual TabUser User { get; set; }
    }
}
