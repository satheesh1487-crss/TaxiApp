using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_trip_settings")]
    public partial class TabTripSettings
    {
        [Key]
        [Column("trip_settings_id")]
        public int TripSettingsId { get; set; }
        [Required]
        [Column("trip_settings_question")]
        [StringLength(300)]
        public string TripSettingsQuestion { get; set; }
        [Column("trip_settings_answer")]
        [StringLength(500)]
        public string TripSettingsAnswer { get; set; }
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
