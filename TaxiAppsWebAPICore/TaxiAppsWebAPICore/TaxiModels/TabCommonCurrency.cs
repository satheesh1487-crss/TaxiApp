using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_common_currency")]
    public partial class TabCommonCurrency
    {
        [Key]
        [Column("currencyid")]
        public long Currencyid { get; set; }
        [Required]
        [Column("currencyname")]
        [StringLength(200)]
        public string Currencyname { get; set; }
        [Required]
        [Column("currency_symbol")]
        [StringLength(100)]
        public string CurrencySymbol { get; set; }
        [Column("currenciesid")]
        public long? Currenciesid { get; set; }
        [Column("isActive")]
        public int? IsActive { get; set; }
        [Column("isDeleted")]
        public int? IsDeleted { get; set; }
        [Column("Created_by")]
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column("Created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("Updated_by")]
        [StringLength(100)]
        public string UpdatedBy { get; set; }
        [Column("Updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("Deleted_by")]
        [StringLength(100)]
        public string DeletedBy { get; set; }
        [Column("Deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(Currenciesid))]
        [InverseProperty(nameof(TabCurrencies.TabCommonCurrency))]
        public virtual TabCurrencies Currencies { get; set; }
    }
}
