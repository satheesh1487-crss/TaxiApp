using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_types")]
    public partial class TabTypes
    {
        public TabTypes()
        {
            TabZonetypeRelationship = new HashSet<TabZonetypeRelationship>();
        }

        [Key]
        [Column("typeid")]
        public long Typeid { get; set; }
        [Required]
        [Column("typename")]
        [StringLength(100)]
        public string Typename { get; set; }
        [Required]
        [Column("imagename")]
        [StringLength(150)]
        public string Imagename { get; set; }
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

        [InverseProperty("Type")]
        public virtual ICollection<TabZonetypeRelationship> TabZonetypeRelationship { get; set; }
    }
}
