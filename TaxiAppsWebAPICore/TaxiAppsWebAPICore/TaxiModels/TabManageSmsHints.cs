using System;
using System.Collections.Generic;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TabManageSmsHints
    {
        public long ManageSmshint { get; set; }
        public long? ManageSmsid { get; set; }
        public string HintKeyword { get; set; }
        public string HintDescription { get; set; }

        public virtual TabManageSms ManageSms { get; set; }
    }
}
