using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_driver_bonus")]
    public partial class TabDriverBonus
    {
        [Key]
        [Column("driverbonusid")]
        public long Driverbonusid { get; set; }
        public long? Driverid { get; set; }
        [Column("bonusamount")]
        public double? Bonusamount { get; set; }
        [Column("bonus_reason")]
        [StringLength(600)]
        public string BonusReason { get; set; }
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
        [InverseProperty(nameof(TabDrivers.TabDriverBonus))]
        public virtual TabDrivers Driver { get; set; }
    }
}
