using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabDriverCancellation
    {
        public long DriverCancelId { get; set; }
        public long? Zonetypeid { get; set; }
        public string Paymentstatus { get; set; }
        public string Arrivalstatus { get; set; }
        public string CancellationReasonEnglish { get; set; }
        public string CancellationReasonArabic { get; set; }
        public string CancellationReasonSpanish { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TabZonetypeRelationship Zonetype { get; set; }
    }
}
