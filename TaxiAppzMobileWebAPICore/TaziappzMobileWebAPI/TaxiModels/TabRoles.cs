using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_roles")]
    public partial class TabRoles
    {
        public TabRoles()
        {
            SetPrivilege = new HashSet<SetPrivilege>();
            TabAdmin = new HashSet<TabAdmin>();
            TabMenuAccess = new HashSet<TabMenuAccess>();
        }

        [Key]
        public long Roleid { get; set; }
        [StringLength(30)]
        public string RoleName { get; set; }
        [Column("Display_Name")]
        [StringLength(30)]
        public string DisplayName { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Column("ALL_Rights")]
        public int? AllRights { get; set; }
        public int? Locked { get; set; }
        [Column("Created_By")]
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column("Created_At", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("Updated_At", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        public int? IsActive { get; set; }
        [Column("updated_by")]
        [StringLength(150)]
        public string UpdatedBy { get; set; }
        [Column("Deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }
        [Column("deleted_by")]
        [StringLength(150)]
        public string DeletedBy { get; set; }
        [Column("isDelete")]
        public int? IsDelete { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<SetPrivilege> SetPrivilege { get; set; }
        [InverseProperty("RoleNavigation")]
        public virtual ICollection<TabAdmin> TabAdmin { get; set; }
        [InverseProperty("Role")]
        public virtual ICollection<TabMenuAccess> TabMenuAccess { get; set; }
    }
}
