using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_driver_fine")]
    public partial class TabDriverFine
    {
        [Key]
        [Column("driverfineid")]
        public long Driverfineid { get; set; }
        public long? Driverid { get; set; }
        [Column("fineamount")]
        public double? Fineamount { get; set; }
        [Column("fine_reason")]
        [StringLength(600)]
        public string FineReason { get; set; }
        [Column("finepaid_status")]
        public bool? FinepaidStatus { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("isDelete")]
        public bool? IsDelete { get; set; }
        [Column("createdby")]
        [StringLength(300)]
        public string Createdby { get; set; }
        [Column("createdat", TypeName = "datetime")]
        public DateTime? Createdat { get; set; }
        [Column("updatedby")]
        [StringLength(300)]
        public string Updatedby { get; set; }
        [Column("updatedat", TypeName = "datetime")]
        public DateTime? Updatedat { get; set; }
        [Column("deletedby")]
        [StringLength(300)]
        public string Deletedby { get; set; }
        [Column("deletedat", TypeName = "datetime")]
        public DateTime? Deletedat { get; set; }

        [ForeignKey(nameof(Driverid))]
        [InverseProperty(nameof(TabDrivers.TabDriverFine))]
        public virtual TabDrivers Driver { get; set; }
    }
}
