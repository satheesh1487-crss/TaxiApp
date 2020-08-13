using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_Common_Languages")]
    public partial class TabCommonLanguages
    {
        public TabCommonLanguages()
        {
            TabAdmin = new HashSet<TabAdmin>();
        }

        [Key]
        public int Languageid { get; set; }
        [Column("Short_Lang")]
        [StringLength(50)]
        public string ShortLang { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [Column("Created_By")]
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column("Created_At", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("Updated_At", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("Deleted_At", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }

        [InverseProperty("LanguageNavigation")]
        public virtual ICollection<TabAdmin> TabAdmin { get; set; }
    }
}
