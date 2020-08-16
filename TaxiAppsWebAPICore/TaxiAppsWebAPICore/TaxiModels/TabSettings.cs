using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiAppsWebAPICore.TaxiModels
{
    [Table("tab_settings")]
    public partial class TabSettings
    {
        [Key]
        [Column("settings_id")]
        public int SettingsId { get; set; }
        [Required]
        [Column("settings_name")]
        [StringLength(300)]
        public string SettingsName { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        [Column("created_by")]
        [StringLength(300)]
        public string CreatedBy { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_by")]
        [StringLength(300)]
        public string UpdatedBy { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
    }
}
