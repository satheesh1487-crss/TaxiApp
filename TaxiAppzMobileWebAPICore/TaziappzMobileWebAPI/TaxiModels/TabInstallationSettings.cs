﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaziappzMobileWebAPI.TaxiModels
{
    [Table("tab_installation_settings")]
    public partial class TabInstallationSettings
    {
        [Key]
        [Column("trip_installation_id")]
        public int TripInstallationId { get; set; }
        [Required]
        [Column("trip_installation_question")]
        [StringLength(300)]
        public string TripInstallationQuestion { get; set; }
        [Column("trip_Installation_answer")]
        [StringLength(500)]
        public string TripInstallationAnswer { get; set; }
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
