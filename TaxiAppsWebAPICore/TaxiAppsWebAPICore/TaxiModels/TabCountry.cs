using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_Country")]
    public partial class TabCountry
    {
        public TabCountry()
        {
            TabAdmin = new HashSet<TabAdmin>();
        }

        [Key]
        public long CountryId { get; set; }
        [StringLength(20)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Currency { get; set; }
        [Column("d_code")]
        [StringLength(20)]
        public string DCode { get; set; }
        [Column("time_zone")]
        [StringLength(200)]
        public string TimeZone { get; set; }
        [Column("Created_By")]
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column("Created_At", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("Updated_At", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("Deleted_At", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }

        [InverseProperty("ZoneAccessNavigation")]
        public virtual ICollection<TabAdmin> TabAdmin { get; set; }
    }
}
