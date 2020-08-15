using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_countries")]
    public partial class TabCountries
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("full_name")]
        [StringLength(255)]
        public string FullName { get; set; }
        [Column("capital")]
        [StringLength(255)]
        public string Capital { get; set; }
        [Column("citizenship")]
        [StringLength(255)]
        public string Citizenship { get; set; }
        [Column("currency")]
        [StringLength(255)]
        public string Currency { get; set; }
        [Column("currency_code")]
        [StringLength(255)]
        public string CurrencyCode { get; set; }
        [Column("currency_sub_unit")]
        [StringLength(255)]
        public string CurrencySubUnit { get; set; }
        [Column("currency_symbol")]
        [StringLength(3)]
        public string CurrencySymbol { get; set; }
        [Required]
        [Column("country_code")]
        [StringLength(3)]
        public string CountryCode { get; set; }
        [Required]
        [Column("region_code")]
        [StringLength(3)]
        public string RegionCode { get; set; }
        [Required]
        [Column("sub_region_code")]
        [StringLength(3)]
        public string SubRegionCode { get; set; }
        [Column("eea")]
        public int Eea { get; set; }
        [Column("calling_code")]
        [StringLength(3)]
        public string CallingCode { get; set; }
        [Required]
        [Column("iso_3166_2")]
        [StringLength(2)]
        public string Iso31662 { get; set; }
        [Required]
        [Column("iso_3166_3")]
        [StringLength(3)]
        public string Iso31663 { get; set; }
        [Column("currency_decimals", TypeName = "decimal(18, 0)")]
        public decimal CurrencyDecimals { get; set; }
        [Column("flag")]
        [StringLength(191)]
        public string Flag { get; set; }
        [Column("active")]
        public int Active { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
    }
}
