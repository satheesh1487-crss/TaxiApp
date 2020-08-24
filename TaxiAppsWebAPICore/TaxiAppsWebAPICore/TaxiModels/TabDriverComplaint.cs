﻿using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabDriverComplaint
    {
        public long DriverComplaintId { get; set; }
        public long? Zoneid { get; set; }
        public string DriverComplaintType { get; set; }
        public string DriverComplaintTitle { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual TabZone Zone { get; set; }
    }
}
