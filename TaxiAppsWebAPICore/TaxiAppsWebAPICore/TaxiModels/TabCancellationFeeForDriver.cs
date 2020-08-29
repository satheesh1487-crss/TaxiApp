using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_cancellation_fee_for_driver")]
    public partial class TabCancellationFeeForDriver
    {
        [Key]
        [Column("cancellation_id")]
        public long CancellationId { get; set; }
        public long? Driverid { get; set; }
        [Column("request_id")]
        public long? RequestId { get; set; }
        [Column("amount")]
        public double? Amount { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(Driverid))]
        [InverseProperty(nameof(TabDrivers.TabCancellationFeeForDriver))]
        public virtual TabDrivers Driver { get; set; }
        [ForeignKey(nameof(RequestId))]
        [InverseProperty(nameof(TabRequest.TabCancellationFeeForDriver))]
        public virtual TabRequest Request { get; set; }
    }
}
