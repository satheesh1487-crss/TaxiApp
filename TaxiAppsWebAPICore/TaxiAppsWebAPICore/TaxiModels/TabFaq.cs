using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabFaq
    {
        public long Faqid { get; set; }
        public long? Servicelocid { get; set; }
        public string FaqQuestion { get; set; }
        public string FaqAnswer { get; set; }
        public string ComplaintType { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TabServicelocation Serviceloc { get; set; }
    }
}
