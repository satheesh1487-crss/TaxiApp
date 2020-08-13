using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_Manage_Email")]
    public partial class TabManageEmail
    {
        public TabManageEmail()
        {
            TabManageEmailHints = new HashSet<TabManageEmailHints>();
        }

        [Key]
        public long ManageEmailid { get; set; }
        [Required]
        [StringLength(200)]
        public string Emailtitle { get; set; }
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

        [InverseProperty("ManageEmail")]
        public virtual ICollection<TabManageEmailHints> TabManageEmailHints { get; set; }
    }
}
