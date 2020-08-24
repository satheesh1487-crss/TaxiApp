using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabDriverDocuments
    {
        public long DriverDocId { get; set; }
        public long? Driverid { get; set; }
        public long? Documentid { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string UploadedFileName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DocumentIdNumber { get; set; }
        public string Comments { get; set; }
        public long? DocApprovalId { get; set; }

        public virtual TabDocumentApporvalStatus DocApproval { get; set; }
        public virtual TabManageDocument Document { get; set; }
        public virtual TabDrivers Driver { get; set; }
    }
}
