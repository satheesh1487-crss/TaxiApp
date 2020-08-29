using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_Manage_SMS")]
    public partial class TabManageSms
    {
        public TabManageSms()
        {
            TabManageSmsHints = new HashSet<TabManageSmsHints>();
        }

        [Key]
        [Column("ManageSMSid")]
        public long ManageSmsid { get; set; }
        [Required]
        [Column("SMStitle")]
        [StringLength(200)]
        public string Smstitle { get; set; }
        [StringLength(600)]
        public string Description { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("Created_by")]
        [StringLength(300)]
        public string CreatedBy { get; set; }
        [Column("Created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("Updated_By")]
        [StringLength(300)]
        public string UpdatedBy { get; set; }
        [Column("Updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("ManageSms")]
        public virtual ICollection<TabManageSmsHints> TabManageSmsHints { get; set; }
    }
}
