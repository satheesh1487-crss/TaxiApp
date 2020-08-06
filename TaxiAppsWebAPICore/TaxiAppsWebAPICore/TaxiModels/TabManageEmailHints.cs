using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_manage_Email_Hints")]
    public partial class TabManageEmailHints
    {
        [Key]
        public long ManageEmailHint { get; set; }
        public long? ManageEmailid { get; set; }
        [Column("Hint_Keyword")]
        [StringLength(200)]
        public string HintKeyword { get; set; }
        [Column("Hint_Description")]
        [StringLength(300)]
        public string HintDescription { get; set; }

        [ForeignKey(nameof(ManageEmailid))]
        [InverseProperty(nameof(TabManageEmail.TabManageEmailHints))]
        public virtual TabManageEmail ManageEmail { get; set; }
    }
}
