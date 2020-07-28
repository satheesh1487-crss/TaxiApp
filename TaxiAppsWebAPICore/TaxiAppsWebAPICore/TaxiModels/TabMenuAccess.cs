using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_MenuAccess")]
    public partial class TabMenuAccess
    {
        [Key]
        public long Accessid { get; set; }
        public long? Menuid { get; set; }
        public long? Roleid { get; set; }
        [Column("viewstatus")]
        public bool? Viewstatus { get; set; }
        [Column("createdby", TypeName = "datetime")]
        public DateTime? Createdby { get; set; }
        [Column("updatedby", TypeName = "datetime")]
        public DateTime? Updatedby { get; set; }

        [ForeignKey(nameof(Menuid))]
        [InverseProperty(nameof(TabMenu.TabMenuAccess))]
        public virtual TabMenu Menu { get; set; }
        [ForeignKey(nameof(Roleid))]
        [InverseProperty(nameof(TabRoles.TabMenuAccess))]
        public virtual TabRoles Role { get; set; }
    }
}
