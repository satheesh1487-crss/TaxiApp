using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_menu")]
    public partial class TabMenu
    {
        public TabMenu()
        {
            TabMenuAccess = new HashSet<TabMenuAccess>();
        }

        [Key]
        public long Menuid { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Column("parentID")]
        public long? ParentId { get; set; }
        public bool? IsActive { get; set; }
        [Column("menukey")]
        [StringLength(100)]
        public string Menukey { get; set; }

        [InverseProperty("Menu")]
        public virtual ICollection<TabMenuAccess> TabMenuAccess { get; set; }
    }
}
