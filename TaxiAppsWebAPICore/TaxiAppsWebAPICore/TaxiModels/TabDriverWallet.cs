using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_driver_wallet")]
    public partial class TabDriverWallet
    {
        [Key]
        [Column("driverwalletid")]
        public long Driverwalletid { get; set; }
        public long? Driverid { get; set; }
        public long? Transactionid { get; set; }
        [Column("currencyid")]
        public long? Currencyid { get; set; }
        [Column("walletamount")]
        public double? Walletamount { get; set; }
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

        [ForeignKey(nameof(Currencyid))]
        [InverseProperty(nameof(TabCommonCurrency.TabDriverWallet))]
        public virtual TabCommonCurrency Currency { get; set; }
        [ForeignKey(nameof(Driverid))]
        [InverseProperty(nameof(TabDrivers.TabDriverWallet))]
        public virtual TabDrivers Driver { get; set; }
    }
}
