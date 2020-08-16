using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_General_settings")]
    public partial class TabGeneralSettings
    {
        [Key]
        [Column("trip_General_id")]
        public int TripGeneralId { get; set; }
        [Required]
        [Column("trip_General_question")]
        [StringLength(300)]
        public string TripGeneralQuestion { get; set; }
        [Column("trip_General_answer")]
        [StringLength(500)]
        public string TripGeneralAnswer { get; set; }
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
