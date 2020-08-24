using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabAdminDetails
    {
        public long Admindtlsid { get; set; }
        public long? AdminId { get; set; }
        public string Address { get; set; }
        public long? CountryId { get; set; }
        public long? PostalCode { get; set; }
        public string DocumentName { get; set; }
        public string Document { get; set; }
        public int? DriverDocumentCount { get; set; }
        public string LastLoginIpAddress { get; set; }
        public int? Block { get; set; }
        public long? LoginAttempt { get; set; }
        public int? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string UpdatedBy { get; set; }
        public int? IsDeleted { get; set; }
        public string DeletedBy { get; set; }

        public virtual TabAdmin Admin { get; set; }
        public virtual TabCountry Country { get; set; }
    }
}
