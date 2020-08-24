using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabGeneralSettings
    {
        public int TripGeneralId { get; set; }
        public string TripGeneralQuestion { get; set; }
        public string TripGeneralAnswer { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
