using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_manage_SMS_Hints")]
    public partial class TabManageSmsHints
    {
        [Key]
        [Column("ManageSMSHint")]
        public long ManageSmshint { get; set; }
        [Column("ManageSMSid")]
        public long? ManageSmsid { get; set; }
        [Column("Hint_Keyword")]
        [StringLength(200)]
        public string HintKeyword { get; set; }
        [Column("Hint_Description")]
        [StringLength(300)]
        public string HintDescription { get; set; }

        [ForeignKey(nameof(ManageSmsid))]
        [InverseProperty(nameof(TabManageSms.TabManageSmsHints))]
        public virtual TabManageSms ManageSms { get; set; }
    }
}
