using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_currencies")]
    public partial class TabCurrencies
    {
        public TabCurrencies()
        {
            TabServicelocation = new HashSet<TabServicelocation>();
            TabUser = new HashSet<TabUser>();
        }

        [Key]
        [Column("currencyid")]
        public long Currencyid { get; set; }
        [Column("countryid")]
        public long? Countryid { get; set; }
        [Column("currency")]
        [StringLength(100)]
        public string Currency { get; set; }
        [Column("code")]
        [StringLength(25)]
        public string Code { get; set; }
        [Column("symbol")]
        [StringLength(25)]
        public string Symbol { get; set; }
        [Column("thousand_separator")]
        [StringLength(10)]
        public string ThousandSeparator { get; set; }
        [Column("decimal_separator")]
        [StringLength(10)]
        public string DecimalSeparator { get; set; }
        public int? IsActive { get; set; }
        [Column("isDelete")]
        public int? IsDelete { get; set; }
        [Column("created_By")]
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [Column("Created_at", TypeName = "datetime")]
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

        [ForeignKey(nameof(Countryid))]
        [InverseProperty(nameof(TabCountry.TabCurrencies))]
        public virtual TabCountry Country { get; set; }
        [InverseProperty("Currency")]
        public virtual ICollection<TabServicelocation> TabServicelocation { get; set; }
        [InverseProperty("Currency")]
        public virtual ICollection<TabUser> TabUser { get; set; }
    }
}
